using System.ComponentModel.DataAnnotations;

namespace Data.FlashCardImmortals.Models.Models
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

//Create table Users(
//Id UniqueIdentifier Primary Key,
//FullName varChar(50) Not Null,
//UserName VarChar(50) Not Null,
//Email VarChar(50) Not Null,
//Password VarChar(50) not null)