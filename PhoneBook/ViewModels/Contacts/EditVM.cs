using DataAccess.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.ViewModels.Contacts
{
    public class EditVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("Full Name:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string FullName { get; set; }
        [DisplayName("Email:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Email { get; set; }

        public EditVM() { }

        public EditVM(Contact item)
        {
            Id = item.Id;
            UserId = item.UserId;
            FullName = item.FullName;
            Email = item.Email;
        }

        public void PopulateEntity(Contact item)
        {
            item.Id = Id;
            item.UserId = UserId;
            item.FullName = FullName;
            item.Email = Email;
        }
    }
}