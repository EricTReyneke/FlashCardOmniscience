using Business.DynamicModelReflector.Interfaces;
using Business.DynamicModelReflector.Models;
using Data.FlashCardImmortals.Base;
using Data.FlashCardImmortals.Interfaces;
using Data.FlashCardImmortals.Models.Models;

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
        public ICollection<PrimaryKeyInfo> RegisterNewFlashCard(FlashCards newFlashCard)
        {
            try
            {
                return
                _reflector
                    .Create(newFlashCard)
                    .Execute();
            }
            catch
            {
                throw;
            }
        }

        public List<FlashCards> RetrieveAllFlashcardsFormSubCategory(Guid subCategoryId)
        {
            try
            {
                IEnumerable<FlashCards> flashcards = new List<FlashCards>();

                _reflector
                    .Load(flashcards)
                    .Where(flashcards => flashcards.SubCategoryId == subCategoryId)
                    .Execute();

                return flashcards?.ToList();
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}