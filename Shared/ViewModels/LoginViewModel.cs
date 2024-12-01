using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HysonMaintainXOrders.Shared.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter User Name")]
        public string? NumberOrEmail { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password")]
        public string? Password { get; set; }

    }
}
