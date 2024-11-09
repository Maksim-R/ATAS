using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATAS.Test
{
    public static class UserRu
    {
        public static string EmailPostfix => GenerateRandomEmail();
        public static string EmailPostfixOld => "a19a3693@atas.net";        
        public static string IndexPhone => "+7";
        public static string Phone => "9511234567";
        public static string Name => "AutotestName";
        public static string Password => "V2%@j*@%&";

        public static string GenerateRandomEmail()
        {
            // Генерация случайной строки перед "@atas.net"
            string randomPart = Guid.NewGuid().ToString("N").Substring(0, 3);  // генерирует строку длиной 8 символов
            return randomPart + "@atas.net";
        }
    }
}
