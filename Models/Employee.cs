using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(50,ErrorMessage ="Name should Contain Maximum 50 charecter")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Email should Contain Maximum 50 charecter")]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        
        public string phone { get; set; }
        [Required(ErrorMessage = "Age is required")]
       
        public string age { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string designation { get; set; }
    }
}
