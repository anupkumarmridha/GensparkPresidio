namespace ApparelShoppingAppAPI.Controllers
{
    internal class ErrorModel
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorModel(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

    }
}