using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using LeaveSystem.Domain.Concrete;
using LeaveSystem.Domain.Infrastructure;

namespace LeaveSystem.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        //[Remote("ValidateUsername", "Account")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [Display(Name = "Password")]
        //[StringLength(10, MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please re-type to confirm password")]
        [Display(Name = "Re-Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string PasswordCompare { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "DOB")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [Display(Name = "Email App")]
        public string Email { get; set; }

        public Address Address { set; get; }

        //Terms and Conditions
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms")]
        //adopted customised attribute
        [AttributeMustBeTrue(ErrorMessage="You must accept the terms")]
        public bool TermsAccepted { set; get; }

        //whether it is an approved user or not, by default it is NO
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        
        public bool IsApproved { set; get; }

        /*
         * perform validation if the user is registered
         * 
         * */
        public bool IsValidUser(string thisUsername, string thisPassword)
        {
            string hashedPassword = Helpers.SHA1Encode(thisPassword);
            /*
            EFProductRepository repo2 = new EFProductRepository();

            Product product = repo2.Products
                .Where(p => p.ProductID == 5)
                .FirstOrDefault();
            */
            EFUserRepository repo = new EFUserRepository();

            User user = repo.Users
                .Where(u => u.Username.Equals(thisUsername) && u.Password.Equals(hashedPassword))
                .FirstOrDefault();
            //Message=The 'Gender' property on 'User' could not be set to a 'System.String' value. You must set this property to a non-null value of type 'LeaveSystem.Domain.Entities.Gender'. 
            //change data type in database from String to Int for enum
            

            return (user != null) ? true : false;
        }
    }

    public enum Gender
    {
        Male, Female
    }

    public class Address
    {
        [Display(Name="Line One")]
        public string Line1 { set; get; }

        [Display(Name = "Line Two")]
        public string Line2 { set; get; }
        public string City { set; get; }
        public string PostCode { set; get; }
        public string StateName { set; get; }
    }
}
