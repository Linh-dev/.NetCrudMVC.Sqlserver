using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Customer
    {

        public Customer() { }
        public Customer(int id, string name, int age, string address, string email)
        {
            this.Id = id;
            this.Age = age;
            this.Name = name;
            this.Address = address;
            this.Email = email;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Ban Can Nhap Ten")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Ban Can Nhap tuoi")]
        [Display(Name ="Age")]
        public int Age { get ; set ; }
        [Required(ErrorMessage ="Ban can nhap dia chi")]
        [Display(Name ="Address")]
        public string Address { get ; set ; }
        [Required(ErrorMessage ="Ban can nhap email")]
        [Display(Name="Email")]
        public string Email { get ; set ; }
    }
}