//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineToDo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class users
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Confirm password and password doesn't match!")]
        public string ConfirmPassword { get; set; }
    }
}
