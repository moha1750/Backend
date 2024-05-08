


namespace BackendTeamwork.Exceptions
{
    public class CustomErrorException : Exception
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public CustomErrorException(int statusCode, string message)
        {
            Message = message;
            StatusCode = statusCode;
        }

        static public CustomErrorException NotFound(string message)
        {
            return new CustomErrorException(404, message);
        }

        static public CustomErrorException InvalidData(string message)
        {
            return new CustomErrorException(400, message);
        }

    }
}