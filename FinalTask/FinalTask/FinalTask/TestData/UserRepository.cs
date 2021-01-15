using FinalTask.Helpers;
using FinalTask.TestData;
using Newtonsoft.Json;
using System.IO;

namespace FinalTask
{
    public static class UserRepository
    {
        private static User GetUserFromJson()
        {
            var user = new User();

            using (var st = new StreamReader("testData.json"))
            {
                var json = st.ReadToEnd();
                user = JsonConvert.DeserializeObject<User>(json);
            }

            return user;
        }

        public static User GetNewUserForRegister()
        {
            var user = GetUserFromJson();           

            user.EmailValue = EmailGenerator.RandomEmail(10);

            return user;
        }

        public static User GetLoginUser()
        {
            return GetUserFromJson();
        }
    }
}
