using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modbus.Data;
using Modbus.Device;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;
using System.Net.Sockets;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Net.Configuration;
using System.Net;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Globalization;
using System.Windows.Documents;
using NLog.Time;

namespace BeldenCableInspection
{
    public class ModbusSlave
    {
        private ModbusTcpSlave slave;
        private TcpListener listener;
        //Camera status and angle
        public bool CamOK = false, WireOK = false, ready = false, Bit, moving = false, monitoring = false;
        private ushort WordLowC, WordHighC, WordLowA, WordHighA;
        private int ReceivedData = 1007, SendData = 1005;
        private Int32 Righ, HighPart; public Int32 poscamera, posangle;
        private int sum;

        //Low and high part status
        private ushort low, high, Low, High;
        // Events
        
        // Emergency Stop
        private bool emergencyStopActive;
        private bool emergencyStopSignal1 = false;
        private bool emergencyStopSignal2 = false;
        public event EventHandler EmergencyStopActivated;
        public event EventHandler EmergencyStopRestored;

        //Home
        private bool homeActive = false;
        public bool homebit = false;


        //Other Events
        public event EventHandler ConfigureTimeout;
        public event EventHandler ModbusMovingError;
        public event EventHandler LostTestConnection;
        public event EventHandler FirstConnection;
        public event EventHandler ReceivedBit;
      

        public DataStore DataStore
        {
            get
            {
                if (slave == null)
                    return null;
                else
                    return slave.DataStore;
            }
            set
            {
                if (slave != null)
                    slave.DataStore = value;
            }
        }
        public ModbusSlave(IPAddress ipAddr, int tcpPort)
        {
            // Create a TCP listener for the ip and port
            listener = new TcpListener(ipAddr, tcpPort);
            // Create a slave device for the TCP listener
            slave = ModbusTcpSlave.CreateTcp(0, listener);
            // Assign an event handler for the slave request received event
            // Will be fired whenever a new read/write request is made to the slave device
            slave.ModbusSlaveRequestReceived += Slave_ModbusSlaveRequestReceived;
            slave.Listen();
            Console.WriteLine("Modbus Listen");
        }
        public bool firstConnection = true;
       
        private void Slave_ModbusSlaveRequestReceived(object sender, ModbusSlaveRequestEventArgs e)
        {
            try
            {
                if (firstConnection)
                {
                    firstConnection = false;
                    FirstConnection?.Invoke(sender, EventArgs.Empty);
                    if (emergencyStopSignal1 == true && emergencyStopSignal2 == true) OnEmergencyStop(this, new EventArgs());
                    if (emergencyStopSignal1 == false && emergencyStopSignal2 == false && emergencyStopActive == true) OnEmergencyStopEnd(this, new EventArgs());
                    if (emergencyStopActive == false) OnHome(sender, new EventArgs());
                    if (homeActive == true) OnHomeEnd(sender, new EventArgs());
                }
                ModbusTcpSlave slave = sender as ModbusTcpSlave;
                #region Debugging
                /*
                string data = String.Empty;
                data += String.Format("CoilDiscretes (Device 0)    -- {0}", String.Join(",", slave.DataStore.CoilDiscretes.Skip(7).Take(3)));
                data += String.Format("DataStore.InputDiscretes (Device 1)   -- {0}\n", String.Join(" | ", slave.DataStore.InputDiscretes.Skip(1).Take(10)));
                data += String.Format("DataStore.HoldingRegisters (Device 4) -- {0}\n", String.Join(" | ", slave.DataStore.HoldingRegisters.Skip(1001).Take(60)));
                Console.WriteLine(data);
                Console.WriteLine(data + Environment.NewLine + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture));
                 */
                #endregion
                //Bit monitoring
                if (ready != slave.DataStore.CoilDiscretes[2]) ready = !ready;
                if (CamOK != slave.DataStore.CoilDiscretes[5]) CamOK = !CamOK;
                if (WireOK = slave.DataStore.CoilDiscretes[6]) WireOK = !WireOK;
                if (moving != slave.DataStore.CoilDiscretes[8])
                {
                    moving = !moving;
                    Console.WriteLine("8====================D~'-, Moving");
                }
                
                if(monitoring != slave.DataStore.CoilDiscretes[9]) monitoring = !monitoring;

                //Home bit monitoring
                if (homebit != slave.DataStore.CoilDiscretes[1]) homebit = !homebit;
                //Emergency bit monitoring 
                emergencyStopSignal1 = slave.DataStore.CoilDiscretes[3];
                emergencyStopSignal2 = slave.DataStore.CoilDiscretes[4];
                emergencyStopActive = slave.DataStore.InputDiscretes[5];
                //Camera bit monitoring 
                WordLowC = DataStore.HoldingRegisters[1009];
                WordHighC = DataStore.HoldingRegisters[1010];
                HighPart = WordHighC << 16;
                poscamera = HighPart | WordLowC;

                //Angle bit monitoring 
                WordLowA = DataStore.HoldingRegisters[1011];
                WordHighA = DataStore.HoldingRegisters[1012];
                HighPart = WordHighA << 16;
                posangle = HighPart | WordLowA;

                if ((emergencyStopSignal1 == true && emergencyStopSignal2 == true) || (emergencyStopSignal1 == true || emergencyStopSignal2 == true))
                    OnEmergencyStop(this, new EventArgs());
                if (emergencyStopSignal1 == false && emergencyStopSignal2 == false && emergencyStopActive == true) OnEmergencyStopEnd(this, new EventArgs());

            }
            catch(Exception ex)
            {
                var logger = new ErrorLogger();
                logger.LogError(ex.Message, ex);
                ErrorHandler.AutoRestart = true;
                ErrorHandler.HandlerError(ex);
            }
        }

        

        public void OnHome(object sender, EventArgs e) => homeActive = slave.DataStore.InputDiscretes[1] = true;

        public async void OnHomeEnd(object sender, EventArgs e) 
        {
            await Task.Delay(500);
            homeActive = slave.DataStore.InputDiscretes[1] = false;
            Console.WriteLine("Home: " + homeActive);
        }
        public void OffBit()
        {
            slave.DataStore.InputDiscretes[8] = false;
            slave.DataStore.InputDiscretes[9] = false;
            slave.DataStore.InputDiscretes[11] = false;
            slave.DataStore.InputDiscretes[12] = false;
            slave.DataStore.InputDiscretes[13] = false;
        }
        protected virtual void OnEmergencyStop(object sender, EventArgs e)
        {
            emergencyStopActive = slave.DataStore.InputDiscretes[5] = true;
            EmergencyStopActivated?.Invoke(sender, e);
            Console.WriteLine("Emergency Stop Active: " + emergencyStopActive);
        }
        protected virtual void OnEmergencyStopEnd(object sender, EventArgs e)
        {
            emergencyStopActive = slave.DataStore.InputDiscretes[5] = false;
            EmergencyStopRestored?.Invoke(sender, e);   
            Console.WriteLine("Emergency Stop Active: " + emergencyStopActive);
        }

        private void SpeedCam()
        {
            Int32 speed = 35000;
            ushort WordLow = Convert.ToUInt16(speed & 0xffff);
            ushort WordHigh = Convert.ToUInt16((speed & 0xffff0000) >> 16);
            slave.DataStore.HoldingRegisters[1013] = WordLow;
            slave.DataStore.HoldingRegisters[1014] = WordHigh;
            HighPart = WordHigh << 16;
            Righ = HighPart | WordLow;
        }
        private void SpeedWire()
        {
            Int32 speed = 40000;
            ushort WordLow = Convert.ToUInt16(speed & 0xffff);
            ushort WordHigh = Convert.ToUInt16((speed & 0xffff0000) >> 16);
            slave.DataStore.HoldingRegisters[1015] = WordLow;
            slave.DataStore.HoldingRegisters[1016] = WordHigh;
            HighPart = WordHigh << 16;
            Righ = HighPart | WordLow;
        }
        

        public async Task HomeWire()
        {
            Int32 left = 0;
            Stopwatch timer = new Stopwatch(); Stopwatch move = new Stopwatch(); Stopwatch bitSend = new Stopwatch();
            timer.Start();
            await Ready();
            ushort WordLow = Convert.ToUInt16(left & 0xffff);
            ushort WordHigh = Convert.ToUInt16((left & 0xffff0000) >> 16);
            Low = slave.DataStore.HoldingRegisters[SendData] = WordLow;
            High = slave.DataStore.HoldingRegisters[(SendData + 1)] = WordHigh;
            SpeedWire();
            move.Start();
            do
            {
                low = DataStore.HoldingRegisters[ReceivedData];
                high = DataStore.HoldingRegisters[(ReceivedData + 1)];
                if (move.ElapsedMilliseconds > 3000)
                    break;
                await Task.Delay(1);
            } while (low != Low && high != High);
            move.Stop();
            if (move.ElapsedMilliseconds > 3000)
                ConfigureTimeout?.Invoke(this, EventArgs.Empty);
            WordLow = DataStore.HoldingRegisters[ReceivedData];
            WordHigh = DataStore.HoldingRegisters[(ReceivedData + 1)];
            HighPart = WordHigh << 16;
            Righ = HighPart | WordLow;
            bitSend.Start();
            if (left == Righ)
            {
                slave.DataStore.InputDiscretes[3] = true;

                do
                {
                    WireOK = slave.DataStore.CoilDiscretes[6];
                    if (bitSend.ElapsedMilliseconds > 3000)
                        break;
                    await Task.Delay(1);
                } while (!WireOK);
                bitSend.Stop();
                if (bitSend.ElapsedMilliseconds > 3000)
                    ReceivedBit?.Invoke(this, EventArgs.Empty);
                slave.DataStore.InputDiscretes[3] = false;
            }
            else
            {
                slave.DataStore.InputDiscretes[3] = false;
            }
            timer.Stop();
        }

        ushort positionsLow, positionHigh, lowposition, highposition;
        public async Task<int> AllMov(List<List<int>> positions, ushort nopackages)
        {
            Stopwatch receivedPostion = new Stopwatch(); Stopwatch bitSend = new Stopwatch(); Stopwatch timer = new Stopwatch(); 
            await Ready();
            int position;
            Console.WriteLine("Home: " + homebit + " and Ready " + ready);
            timer.Start(); 
            slave.DataStore.HoldingRegisters[1019] = 0;
            bitSend.Start();
            do
            {
                Console.WriteLine("Zero: " + slave.DataStore.HoldingRegisters[1017]);
                if (bitSend.ElapsedMilliseconds > 3000)
                    break;
                await Task.Delay(1);
                if (slave.DataStore.HoldingRegisters[1017] != 0)
                    Console.WriteLine();
            } while (slave.DataStore.HoldingRegisters[1017] != 0);
            bitSend.Stop();
            if (bitSend.ElapsedMilliseconds > 3000)
            {
                ReceivedBit?.Invoke(this, EventArgs.Empty);
                return 0;
            }
            /*
             */

            int i = 1023, x = 1; sum = 0;
            SpeedCam(); SpeedWire();

            foreach (List<int> fila in positions)
            {
                foreach (Int32 valor in fila)
                {
                    lowposition = Convert.ToUInt16(valor & 0xffff);
                    highposition = Convert.ToUInt16((valor & 0xffff0000) >> 16);
                    ushort DataLow = slave.DataStore.HoldingRegisters[i] = lowposition;
                    ushort DataHigh = slave.DataStore.HoldingRegisters[i + 1] = highposition;
                    i = i + 2;
                    sum += valor;
                }
                x++;
            }

            slave.DataStore.HoldingRegisters[1019] = nopackages;
            Console.WriteLine("Register: " + 1019 + " Number Packages: " + slave.DataStore.HoldingRegisters[1019]);
            Console.WriteLine(" ");
            ushort PackData;
            do
            {
                PackData = slave.DataStore.HoldingRegisters[1017];
                Console.WriteLine("Number Package Received: " + PackData);
                await Task.Delay(1);
                if (PackData != nopackages)
                    Console.WriteLine();
            } while (PackData != nopackages);

            lowposition = Convert.ToUInt16(sum & 0xffff);
            highposition = Convert.ToUInt16((sum & 0xffff0000) >> 16);
            receivedPostion.Start();
            do
            {
                //Word Low and High to Camera
                positionsLow = slave.DataStore.HoldingRegisters[999];
                positionHigh = slave.DataStore.HoldingRegisters[1000];
                await Task.Delay(1);
                if (receivedPostion.ElapsedMilliseconds > 3000) break;
            } while (positionsLow != lowposition && positionHigh != highposition);
            receivedPostion.Stop();
            if (receivedPostion.ElapsedMilliseconds > 3000)
            {
                if(PackData == nopackages)
                    return sum;
                else
                {
                    ConfigureTimeout?.Invoke(this, EventArgs.Empty);
                    return 0;
                }
            }

            positionsLow = slave.DataStore.HoldingRegisters[999];
            positionHigh = slave.DataStore.HoldingRegisters[1000];
            Int32 HighPartC = positionHigh << 16;
            position = HighPartC | positionsLow;
            Console.WriteLine("Computer send Total Sum of Positions #1: " + sum + " and PLC send Total Sum of Positions: " + position);
            timer.Stop();
            return position;
        }
      
        public void Started() => slave.DataStore.InputDiscretes[11] = true;
        public void Finished()
        {
            slave.DataStore.InputDiscretes[11] = false;
            slave.DataStore.InputDiscretes[12] = false;
        }
        public void NextON() => slave.DataStore.InputDiscretes[12] = true;
        public void NextOFF() => slave.DataStore.InputDiscretes[12] = false;

        public async Task Next()
        {
            slave.DataStore.InputDiscretes[12] = true;
            do
            {
                await Task.Delay(1);
            } while (!moving);
            slave.DataStore.InputDiscretes[12] = false;
        }

        public void MoveRight(bool value) => slave.DataStore.InputDiscretes[8] = value;
        public void MoveLeft(bool value) => slave.DataStore.InputDiscretes[9] = value;
        private async Task<bool> Ready()
        {
            Stopwatch bitSend = new Stopwatch();
            bitSend.Start();
            do
            {
                await Task.Delay(1);
                if (bitSend.ElapsedMilliseconds > 3000)
                    break;
            } while (!ready);
            if (bitSend.ElapsedMilliseconds > 3000)
                ReceivedBit?.Invoke(this, EventArgs.Empty);
            return true;
        }
        public async Task<int> PositionCamera(Int32 left)
        {
            TriggerModOFF();
            await Ready();
            ushort WordLow = Convert.ToUInt16(left & 0xffff);
            ushort WordHigh = Convert.ToUInt16((left & 0xffff0000) >> 16);
            Low = slave.DataStore.HoldingRegisters[1001] = WordLow;
            High = slave.DataStore.HoldingRegisters[1002] = WordHigh;
            SpeedCam();
            await Task.Delay(200);
            do
            {
                low = DataStore.HoldingRegisters[1003];
                Console.WriteLine("Low: " + low);
                high = DataStore.HoldingRegisters[1004];
                Console.WriteLine("High: " + high);

            } while (low != Low || high != High);

            WordLow = DataStore.HoldingRegisters[1003];
            WordHigh = DataStore.HoldingRegisters[1004];
            HighPart = WordHigh << 16;
            Righ = HighPart | WordLow;
            if (left == Righ)
            {
                slave.DataStore.InputDiscretes[2] = true;
                do
                {
                    await Task.Delay(1);
                } while (!CamOK);
                slave.DataStore.InputDiscretes[2] = false;
            }
            else
            {
                slave.DataStore.InputDiscretes[2] = false;
            }
            
            TriggerModON();
            return poscamera;
        }
        public void TriggerModON() => slave.DataStore.InputDiscretes[13] = true;
        public void TriggerModOFF() => slave.DataStore.InputDiscretes[13] = false;
        public async Task<int> ReceivedPositionWire()
        {
            await Task.Delay(1);
            ushort WordLow = DataStore.HoldingRegisters[1011];
            ushort WordHigh = DataStore.HoldingRegisters[1012];
            HighPart = WordHigh << 16;
            posangle = HighPart | WordLow;
            return posangle;
        }
        /*
        */
        public bool EmergencyStopActive { get => emergencyStopActive; set => emergencyStopActive = value; }
    }
}