using Business.FlashCardImmortals.Exstensions;
using Data.FlashCardImmortals.Interfaces;
using Data.FlashCardImmortals.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashCardImmortals.Pages
{
    public class ManipulateFlashModel : PageModel
    {
        #region Fields
        ISubCategoriesDataOperations _subCategoryData;

        IFlashcardsDataOperations _flashcardsData;

        Guid _mainCategoryId = Guid.Empty;

        Guid _userId = Guid.Empty;
        #endregion

        #region Properties
        public List<SubCategories> SubCategoriesList { get; set; }

        public Dictionary<Guid, List<Flashcards>> FlashcardsInSubcategories { get; set; } = new();
        #endregion

        #region Constructors
        //public ManipulateFalshModel(string mainCategoryId, ISubCategoriesDataOperations subCategoryData) => _subCategoryData = subCategoryData;

        public ManipulateFlashModel(ISubCategoriesDataOperations subCategoryData, IFlashcardsDataOperations flashcardsData)
        {
            _subCategoryData = subCategoryData;
            _flashcardsData = flashcardsData;
        }
        #endregion

        public void OnGet()
        {
            if (!GuidExstender.TryParseGuid("807E3B0D-C532-40C8-A606-A09B99839B7E", out _mainCategoryId))
                throw new ArgumentException("Main Category Id was not a valid guid");

            string userIdString = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdString) || !GuidExstender.TryParseGuid(userIdString, out _userId))
                throw new ArgumentException("User is not authenticated.");

            SetSubCategoriesInScope();
            SetFlashcardsInSubcategories();
        }

        #region Public Methods
        public IActionResult OnPostRegisterSubCategory([FromBody] SubCategories newSubCategory)
        {
            if (newSubCategory == null)
                return new JsonResult(new { success = false, error = "Invalid sub category data." });

            try
            {
                newSubCategory.MainCategoryId = _mainCategoryId;
                newSubCategory.UserId = _userId;

                _subCategoryData.RegisterSubCategory(newSubCategory);

                return new JsonResult(new { success = true });
            }
            catch
            {
                return new JsonResult(new { success = false, error = "An error occurred while creating the new sub category." });
            }
        }

        public IActionResult OnPostRegisterNewFlashCard([FromBody] Flashcards newFlashCard)
        {
            //TODO: Figure out how to retrieve the subCategoryId from the UI.
            if(newFlashCard == null)
                return new JsonResult(new { success = false, error = "Invalid flash card." });

            try
            {
                _flashcardsData.RegisterNewFlashCard(newFlashCard);

                return new JsonResult(new { success = true });
            }
            catch
            {
                return new JsonResult(new { success = false, error = "An error occurred while creating the new flash card." });
            }
        }
        #endregion

        #region Private Methods
        private void SetSubCategoriesInScope() =>
            SubCategoriesList = _subCategoryData.RetrieveAllSubCategoriesFromIds(_userId, _mainCategoryId)?.ToList();

        private void SetFlashcardsInSubcategories()
        {
            foreach(SubCategories subCategory in SubCategoriesList)
                FlashcardsInSubcategories.Add(subCategory.Id, _flashcardsData.RetrieveAllFlashcardsFormSubCategory(subCategory.Id));
        }
        #endregion
    }
}