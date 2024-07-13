namespace Business.FlashCardImmortals.Exstensions
{
    public static class GuidExstender
    {
        #region Public Methods
        public static bool TryParseGuid(this string input, out Guid guid) =>
            Guid.TryParse(input, out guid);
        #endregion
    }
}