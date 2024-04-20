namespace Generic_Login_Api.Response
{
    public class ResponseBase
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }

        public void SetStatusCode(int status)
        {
            this.StatusCode = status;
        }
        public void SetMessage(string message)
        {
            this.Message = message;
        }
    }
}
