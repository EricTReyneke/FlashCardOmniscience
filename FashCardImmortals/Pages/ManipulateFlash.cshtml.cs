using Data.FlashCardImmortals.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashCardImmortals.Pages
{
    public class ManipulateFalshModel : PageModel
    {
        #region Fields
        ISubCategoriesDataOperations _subCategoryData;
        #endregion

        #region Constructors
        public ManipulateFalshModel(ISubCategoriesDataOperations subCategoryData) => _subCategoryData = subCategoryData;
        #endregion

        #region Public Methods
        public void OnGet()
        {
        }
        #endregion

        #region Private Methods

        #endregion
    }
}
