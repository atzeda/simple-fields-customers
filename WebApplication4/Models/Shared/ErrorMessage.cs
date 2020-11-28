namespace WebApplication4.Models.Shared
{
    public class ErrorMessage
    {
        public string Message { get; }
        public string TransactionId { get; }

        public ErrorMessage(string message, string transactionId)
        {
            Message = message;
            TransactionId = transactionId;
        }

        public ErrorMessage(string message)
        {
            Message = message;
        }
    }
}
