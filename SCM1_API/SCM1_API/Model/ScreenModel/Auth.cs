using System.Runtime.Serialization;

namespace SCM1_API.Model.ScreenModel.Auth
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public string EmpNo { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    public class Response
    {
        public bool Authenticated { get; set; }
        public string Token { get; set; }
    }
}