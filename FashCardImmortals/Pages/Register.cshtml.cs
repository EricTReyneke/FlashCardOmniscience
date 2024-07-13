using Data.FlashCardImmortals.Interfaces;
using Data.FlashCardImmortals.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashCardImmortals.Pages
{
    public class RegisterModel : PageModel
    {
        #region Fields
        IUsersDataOperations _usersData;
        #endregion

        #region Constructors
        public RegisterModel(IUsersDataOperations usersData) => _usersData = usersData;
        #endregion

        #region Public Methods
        public IActionResult OnPostRegisterNewUser([FromBody] Users newUser)
        {
            try
            {
                ValidateUserNameAndEmailAddress validateUserNameAndEmailAddress = _usersData.IsUserNameAndEmailValid(newUser.UserName, newUser.Email);

                if (validateUserNameAndEmailAddress == ValidateUserNameAndEmailAddress.Valid)
                {
                    _usersData.RegisterUser(newUser);
                    return new JsonResult(new { success = true, redirectUrl = "/Login" });
                }
                else if (validateUserNameAndEmailAddress == ValidateUserNameAndEmailAddress.UserName)
                    return new JsonResult(new { success = false, error = "This user name is already taken. Please try another user name." });
                else
                    return new JsonResult(new { success = false, error = "This email is already taken. Please try another email address." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, error = $"Error Message: {ex.Message}" });
            }
        }
        #endregion
    }
}