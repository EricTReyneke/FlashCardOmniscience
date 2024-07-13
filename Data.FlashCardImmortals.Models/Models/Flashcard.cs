using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.FlashCardImmortals.Models.Models
{
    public class Flashcard
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("SubCategory")]
        public Guid SubCategoryId { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public ICollection<SubCategories> SubCategory { get; set; }
    }
}

//CREATE TABLE Flashcards (
//    Id UniqueIdentifier PRIMARY KEY,
//    SubCategoryId UniqueIdentifier NOT NULL,
//    Question NVARCHAR(Max) NOT NULL,
//    Answer NVARCHAR(Max) NOT NULL,
//    FOREIGN KEY (SubCategoryId) REFERENCES SubCategories(Id)
//);