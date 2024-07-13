using Business.DynamicModelReflector.Interfaces;
using Data.FlashCardImmortals.Base;
using Data.FlashCardImmortals.Interfaces;
using Data.FlashCardImmortals.Models.Models;

namespace Data.FlashCardImmortals.DataOperations
{
    public class OpsSubCategoriesDataOperations : OpsDataOperations, ISubCategoriesDataOperations
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpsSubCategoriesDataOperations"/> class.
        /// </summary>
        /// <param name="dataOperations">The data operations instance.</param>
        public OpsSubCategoriesDataOperations(IModelReflector dataOperations) : base(dataOperations) { }
        #endregion

        #region Public Methods
        public void RegisterSubCategory(SubCategory newSubCategory)
        {
            try
            {
                _reflector
                    .Create(newSubCategory)
                    .Execute();
            }
            catch
            {
                throw;
            }
        }

        public void RetrieveAllSubCategoriesFromIds(Guid userId, Guid mainCategoryId)
        {
            try
            {
                IEnumerable<SubCategory> subCategories = new List<SubCategory>();
                _reflector
                    .Load(subCategories)
                    .Where(subCategories => subCategories.UserId == userId && subCategories.MainCategoryId == mainCategoryId)
                    .Execute();
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}