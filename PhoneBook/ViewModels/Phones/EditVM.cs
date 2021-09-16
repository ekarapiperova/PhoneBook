using DataAccess.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.ViewModels.Phones
{
    public class EditVM
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        [DisplayName("Phone Number:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string PhoneNumber { get; set; }

        public EditVM() { }

        public EditVM(Phone item)
        {
            Id = item.Id;
            ContactId = item.ContactId;
            PhoneNumber = item.PhoneNumber;
        }

        public void PopulateEntity(Phone item)
        {
            item.Id = Id;
            item.ContactId = ContactId;
            item.PhoneNumber = PhoneNumber;
        }
    }
}