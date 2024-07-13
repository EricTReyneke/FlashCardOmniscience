using Business.FlashCardImmortals.Exstensions;
using Data.FlashCardImmortals.Interfaces;
using Data.FlashCardImmortals.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashCardImmortals.Pages
{
    public class ManipulateFalshModel : PageModel
    {
        #region Fields
        ISubCategoriesDataOperations _subCategoryData;

        Guid _mainCategoryId = Guid.Empty;
        #endregion

        #region Constructors
        //public ManipulateFalshModel(string mainCategoryId, ISubCategoriesDataOperations subCategoryData) => _subCategoryData = subCategoryData;

        public ManipulateFalshModel(ISubCategoriesDataOperations subCategoryData)
        {
            _subCategoryData = subCategoryData;

            if (!GuidExstender.TryParseGuid("807E3B0D-C532-40C8-A606-A09B99839B7E", out _mainCategoryId))
                throw new ArgumentException("Main Category Id was not a valid guid");
        }
        #endregion

        #region Public Methods
        public IActionResult OnPostRegisterSubCategory([FromBody] SubCategories newSubCategory)
        {
            if (newSubCategory == null)
                return new JsonResult(new { success = false, error = "Invalid sub category data." });

            try
            {
                string userIdString = HttpContext.Session.GetString("UserId");
                Guid userGuid = Guid.Empty;

                if (string.IsNullOrEmpty(userIdString) || !GuidExstender.TryParseGuid(userIdString, out userGuid))
                    return new JsonResult(new { success = false, error = "User is not authenticated." });

                newSubCategory.MainCategoryId = _mainCategoryId;
                newSubCategory.UserId = userGuid;

                _subCategoryData.RegisterSubCategory(newSubCategory);

                return new JsonResult(new { success = true });
            }
            catch
            {
                return new JsonResult(new { success = false, error = "An error occurred while creating the new sub category." });
            }
        }
        #endregion
    }
}