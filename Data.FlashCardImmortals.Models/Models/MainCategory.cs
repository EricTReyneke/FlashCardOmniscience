using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Data.FlashCardImmortals.Models.Models
{
    public class MainCategory
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Users")]
        public Guid UserId { get; set; }

        public string Name { get; set; }

        [IgnoreDataMember]
        public ICollection<Users> Users { get; set; }
    }
}

//CREATE TABLE MainCategories (
//    Id UniqueIdentifier PRIMARY KEY,
//    UserId UniqueIdentifier NOT NULL,
//    Name NVARCHAR(50) NOT NULL,
//    FOREIGN KEY (UserId) REFERENCES Users(Id)
//);