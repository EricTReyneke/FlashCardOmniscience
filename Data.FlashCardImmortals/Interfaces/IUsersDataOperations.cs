using Business.DynamicModelReflector.Models;
using Data.FlashCardImmortals.Models.Models;

namespace Data.FlashCardImmortals.Interfaces
{
    public interface IUsersDataOperations
    {
        /// <summary>
        /// Writes the new user information to the database.
        /// </summary>
        /// <param name="newUser">New Users data.</param>
        /// <returns>Primary key information.</returns>
        ICollection<PrimaryKeyInfo> RegisterUser(Users newUser);

        /// <summary>
        /// Validates if the user existed in the database.
        /// </summary>
        /// <param name="userName">Users, Username or Email.</param>
        /// <param name="password">Users Password.</param>
        /// <returns>Logged in User data.</returns>
        Users ValidateUserLogin(string userName, string password);

        /// <summary>
        /// Validates if the userName of email address is Unique.
        /// </summary>
        /// <param name="userName">User Name in question.</param>
        /// <param name="emailAddress">Email address in Question.</param>
        /// <returns>Return ValidateUserNameAndEmailAddress.</returns>
        ValidateUserNameAndEmailAddress IsUserNameAndEmailValid(string userName, string emailAddress);
    }
}