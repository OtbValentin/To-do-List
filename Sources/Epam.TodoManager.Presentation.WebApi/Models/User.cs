using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.TodoManager.Presentation.WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public class NewUser
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UpdatedUser
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}