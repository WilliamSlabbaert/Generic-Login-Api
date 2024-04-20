namespace Generic_Login_Api.Response
{
    public class ResponseObjects : ResponseBase
    {
        public IEnumerable<object> Data { get; private set; }
        public ResponseObjects(IEnumerable<object> myData, int status, string message)
        {
            this.Data = myData;
            SetMessage(message);
            SetStatusCode(status);
        }
    }
}
