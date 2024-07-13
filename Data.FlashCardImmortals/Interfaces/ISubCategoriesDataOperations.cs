using Data.FlashCardImmortals.Models.Models;

namespace Data.FlashCardImmortals.Interfaces
{
    public interface ISubCategoriesDataOperations
    {
        /// <summary>
        /// Created the new SubCategory in the database.
        /// </summary>
        /// <param name="newSubCategory">New Sub Category data.</param>
        void RegisterSubCategory(SubCategory newSubCategory);

        /// <summary>
        /// Retrieves all the SubCategories connected to the UserId and MainCategoryId supplied.
        /// </summary>
        /// <param name="userId">Users Id.</param>
        /// <param name="mainCategoryId">Main Category Id.</param>
        void RetrieveAllSubCategoriesFromIds(Guid userId, Guid mainCategoryId);
    }
}