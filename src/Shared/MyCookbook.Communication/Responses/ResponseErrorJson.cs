namespace MyCookbook.Communication.Responses
{
    public class ResponseErrorJson
    {
        public IList<string> ErrorMessages { get; set; }
        public bool Success { get; set; }

        public ResponseErrorJson(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public ResponseErrorJson(string errorMessage)
        {
            ErrorMessages = new List<string> { errorMessage };
        }
    }
}
