using System;
using System.Linq;

namespace FinalTask.Helpers
{
    public static class EmailGenerator
    {
        private static readonly Random random = new Random();
        public static string RandomEmail(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefgijklmnoprstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray()) + "@gmail.com";
        }
    }
}
