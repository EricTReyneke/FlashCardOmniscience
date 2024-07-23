using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Data.FlashCardImmortals.Models.Models
{
    public class SubCategories
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Users")]
        public Guid UserId { get; set; }

        [ForeignKey("MainCategory")]
        public Guid MainCategoryId { get; set; }

        public string Name { get; set; }

        //[IgnoreDataMember]
        //public IEnumerable<Users> Users { get; set; }

        //[IgnoreDataMember]
        //public IEnumerable<MainCategories> MainCategories { get; set; }
    }
}

//CREATE TABLE SubCategories (
//    Id UniqueIdentifier PRIMARY KEY,
//    UserId UniqueIdentifier NOT NULL,
//    MainCategoryId UniqueIdentifier NOT NULL,
//    Name NVARCHAR(50) NOT NULL,
//    FOREIGN KEY (UserId) REFERENCES Users(Id),
//    FOREIGN KEY(MainCategoryId) REFERENCES MainCategories(Id)
//);