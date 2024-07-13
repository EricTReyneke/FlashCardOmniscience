using Data.FlashCardImmortals.Interfaces;
using Data.FlashCardImmortals.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashCardImmortals.Pages
{
    public class LoginModel : PageModel
    {
        #region Fields
        IUsersDataOperations _usersData;
        #endregion

        #region Constructors
        public LoginModel(IUsersDataOperations usersData) => _usersData = usersData;
        #endregion

        #region Public Methods
        public IActionResult OnPostValidateUserInfo(string userName, string password)
        {
            try
            {
                Users userInfo = _usersData.ValidateUserLogin(userName, password);

                if (userInfo.Id != Guid.Empty)
                {
                    HttpContext.Session.SetString("UserId", userInfo.Id.ToString());
                    return new JsonResult(new { success = true, redirectUrl = "/Dashboard" });
                }

                return new JsonResult(new { success = false, error = "This user does not exist. Please try again." });
            }
            catch (Exception error)
            {
                return new JsonResult(new { success = false, error = $"Error Occurred: {error.Message}" });
            }
        }
        #endregion
    }
}