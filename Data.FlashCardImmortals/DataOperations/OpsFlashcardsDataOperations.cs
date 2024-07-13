using Business.DynamicModelReflector.Interfaces;
using Data.FlashCardImmortals.Base;
using Data.FlashCardImmortals.Interfaces;

namespace Data.FlashCardImmortals.DataOperations
{
    public class OpsFlashcardsDataOperations : OpsDataOperations, IFlashcardsDataOperations
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpsFlashcardsDataOperations"/> class.
        /// </summary>
        /// <param name="dataOperations">The data operations instance.</param>
        public OpsFlashcardsDataOperations(IModelReflector dataOperations) : base(dataOperations) { }
        #endregion

        #region Public Methods

        #endregion
    }
}