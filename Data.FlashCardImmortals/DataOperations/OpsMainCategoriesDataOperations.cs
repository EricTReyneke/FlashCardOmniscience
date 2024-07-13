using Business.DynamicModelReflector.Interfaces;
using Data.FlashCardImmortals.Base;
using Data.FlashCardImmortals.Interfaces;

namespace Data.FlashCardImmortals.DataOperations
{
    public class OpsMainCategoriesDataOperations : OpsDataOperations, IMainCategoriesDataOperations
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpsMainCategoriesDataOperations"/> class.
        /// </summary>
        /// <param name="dataOperations">The data operations instance.</param>
        public OpsMainCategoriesDataOperations(IModelReflector dataOperations) : base(dataOperations) { }
        #endregion

        #region Public Methods

        #endregion
    }
}