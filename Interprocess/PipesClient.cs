using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text.Json;


public class PipesClient
{
    public void CreateClient(string response)
    {
        try
        {
            using (var clientPipe = new NamedPipeClientStream(".", "ServicePipeHyson", PipeDirection.InOut))
            {
                Debug.WriteLine("Created client pipe. Connecting to the server...");
                clientPipe.Connect(); 
                var sw = new StreamWriter(clientPipe); 
                sw.AutoFlush = true;
                sw.WriteLine(response);
                Debug.WriteLine("Connected. Sending data... " + response);
            }
        }
        catch (TimeoutException ex)
        {
            Debug.WriteLine("Timeout exception: " + ex.Message);
        }
        catch (IOException ex)
        {
            Debug.WriteLine("IO exception: " + ex.Message);
        }
    }
   
}

