using Newtonsoft.Json;

namespace FinalTask.TestData
{
    [JsonObject("User")]
    public class User
    {
        public string EmailValue { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string MobilePhone { get; set; }
        public string AdressAlias { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
