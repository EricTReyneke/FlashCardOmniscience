using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Data.FlashCardImmortals.Models.Models
{
    public class FlashCards
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("SubCategories")]
        public Guid SubCategoryId { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        [IgnoreDataMember]
        public IEnumerable<SubCategories> SubCategories { get; set; }
    }
}

//CREATE TABLE FlashCards (
//    Id UniqueIdentifier PRIMARY KEY,
//    SubCategoryId UniqueIdentifier NOT NULL,
//    Question NVARCHAR(Max) NOT NULL,
//    Answer NVARCHAR(Max) NOT NULL,
//    FOREIGN KEY (SubCategoryId) REFERENCES SubCategories(Id)
//);