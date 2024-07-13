using Data.FlashCardImmortals.Models.Models;

namespace Data.FlashCardImmortals.Interfaces
{
    public interface IFlashcardsDataOperations
    {
        /// <summary>
        /// Inserts new Flashcard into the database.
        /// </summary>
        /// <param name="newFlashCard">New falsh card.</param>
        void RegisterNewFlashCard(Flashcards newFlashCard);

        /// <summary>
        /// Retrieves all the flashcards in a sub category.
        /// </summary>
        /// <param name="subCategoryId">Sub category in scope.</param>
        /// <returns>List of all the flashcards in a sub category.</returns>
        List<Flashcards> RetrieveAllFlashcardsFormSubCategory(Guid subCategoryId);
    }
}