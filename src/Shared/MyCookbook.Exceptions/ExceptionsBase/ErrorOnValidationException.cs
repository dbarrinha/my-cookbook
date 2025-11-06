namespace MyCookbook.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException: MyCookbookException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
