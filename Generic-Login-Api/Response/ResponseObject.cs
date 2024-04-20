namespace Generic_Login_Api.Response
{
    public class ResponseObject : ResponseBase
    {
        public object Data { get; private set; }
        public ResponseObject(object myData, int status, string message)
        {
            this.Data = myData;

            SetMessage(message);
            SetStatusCode(status);
        }
    }
}
