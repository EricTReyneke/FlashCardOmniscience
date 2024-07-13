using Data.FlashCardImmortals.Models.Models;

namespace Data.FlashCardImmortals.Interfaces
{
    public interface ISubCategoriesDataOperations
    {
        /// <summary>
        /// Created the new SubCategory in the database.
        /// </summary>
        /// <param name="newSubCategory">New Sub Category data.</param>
        void RegisterSubCategory(SubCategories newSubCategory);

        /// <summary>
        /// Retrieves all the SubCategories connected to the UserId and MainCategoryId supplied.
        /// </summary>
        /// <param name="userId">Users Id.</param>
        /// <param name="mainCategoryId">Main Category Id.</param>
        /// <returns>List of SubCategories in Scope.</returns>
        IEnumerable<SubCategories> RetrieveAllSubCategoriesFromIds(Guid userId, Guid mainCategoryId);
    }
}