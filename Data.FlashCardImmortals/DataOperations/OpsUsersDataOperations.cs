using Business.DynamicModelReflector.Interfaces;
using Business.DynamicModelReflector.Models;
using Data.FlashCardImmortals.Base;
using Data.FlashCardImmortals.Interfaces;
using Data.FlashCardImmortals.Models.Models;
using System.Reflection;

namespace Data.FlashCardImmortals.DataOperations
{
    /// <summary>
    /// Operations for user data.
    /// </summary>
    public class OpsUsersDataOperations : OpsDataOperations, IUsersDataOperations
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpsUsersDataOperations"/> class.
        /// </summary>
        /// <param name="dataOperations">The data operations instance.</param>
        public OpsUsersDataOperations(IModelReflector dataOperations) : base(dataOperations) { }
        #endregion

        #region Public Methods
        public ICollection<PrimaryKeyInfo> RegisterUser(Users newUser)
        {
            try
            {
                ICollection<PrimaryKeyInfo> primaryKeyInfo = _reflector
                    .Create(newUser)
                    .Execute();

                return primaryKeyInfo;
            }
            catch
            {
                throw;
            }
        }

        public Users ValidateUserLogin(string userName, string password)
        {
            try
            {
                Users logedInUser = new();
                _reflector
                    .Load(logedInUser)
                    .Where(logedInUser => (logedInUser.UserName == userName || logedInUser.Email == userName) && logedInUser.Password == password)
                    .Execute();

                return logedInUser;
            }
            catch
            {
                throw;
            }
        }

        public ValidateUserNameAndEmailAddress IsUserNameAndEmailValid(string userName, string emailAddress)
        {
            Users userInformation = new();

            _reflector
                .Load(userInformation)
                .Where(userLogin => userLogin.UserName == userName)
                .Execute();

            if (!string.IsNullOrEmpty(userInformation.UserName))
                return ValidateUserNameAndEmailAddress.UserName;

            _reflector
                .Load(userInformation)
                .Where(userLogin => userLogin.Email == emailAddress)
                .Execute();

            if (!string.IsNullOrEmpty(userInformation.Email))
                return ValidateUserNameAndEmailAddress.Email;

            return ValidateUserNameAndEmailAddress.Valid;
        }
        #endregion
    }
}