using Business.DynamicModelReflector.Interfaces;
using Business.DynamicModelReflector.Models;
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
        public ICollection<PrimaryKeyInfo> RegisterSubCategory(SubCategories newSubCategory)
        {
            try
            {
                return
                _reflector
                    .Create(newSubCategory)
                    .Execute();
            }
            catch
            {
                throw;
            }
        }

        public void ValidateIfSubCategoryNameIsTaken(Guid userId, Guid mainCategoryId, string newSubName)
        {
            try
            {
                SubCategories Validation = new();
                _reflector
                    .Load(Validation).Where(Validate => Validate.UserId == userId && Validate.MainCategoryId == mainCategoryId && Validate.Name == newSubName)
                    .Execute();

                if (Validation.Id == Guid.Empty)
                    return;

                throw new Exception("NO duplicate sub-category names allowed.");
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<SubCategories> RetrieveAllSubCategoriesFromIds(Guid userId, Guid mainCategoryId)
        {
            try
            {
                IEnumerable<SubCategories> subCategories = new List<SubCategories>();
                _reflector
                    .Load(subCategories)
                    .Where(subCategories => subCategories.UserId == userId && subCategories.MainCategoryId == mainCategoryId)
                    .Execute();

                return subCategories;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}