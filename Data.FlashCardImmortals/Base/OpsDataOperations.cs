using Business.DynamicModelReflector.Interfaces;

namespace Data.FlashCardImmortals.Base
{
    /// <summary>
    /// Base class for data operations.
    /// </summary>
    public class OpsDataOperations
    {
        #region Fields
        /// <summary>
        /// Data operations interface instance.
        /// </summary>
        protected IModelReflector _reflector;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpsDataOperations"/> class.
        /// </summary>
        /// <param name="dataOperations">The data operations instance.</param>
        public OpsDataOperations(IModelReflector dataOperations)
        {
            _reflector = dataOperations;
        }
        #endregion
    }
}