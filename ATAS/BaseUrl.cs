using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATAS.Test
{
    public static class BaseUrl
    {
        // Базовые ссылки 
        public static class Tariff
        {
            public static string Tariffs => "https://my.trade-with.me/";

            public static string currentUrl => "https://my.trade-with.me/download#wizard";
        }
        
    }

    public static class Tariff
    {
        // Global Standart Tariffs
        public static class GlobalStandart
        {
            public static string Id11 => "https://my.trade-with.me/cart?id=11";  // 1 month, 31 days, 69 €
            public static string Id5 => "https://my.trade-with.me/cart?id=5";    // 3 months, 92 days, 179 €
            public static string Id1 => "https://my.trade-with.me/cart?id=1";    // 6 months, 183 days, 299 €
            public static string Id2 => "https://my.trade-with.me/cart?id=2";    // 1 year, 365 days, 479 €
            public static string Id3 => "https://my.trade-with.me/cart?id=3";    // Lifetime, 36500 days, 1790 €
        }

        // Global Promo Tariffs
        public static class GlobalPromo
        {
            public static string Id22 => "https://my.trade-with.me/cart?id=22"; // 1 month, 45 days, 69 €
            public static string Id51 => "https://my.trade-with.me/cart?id=51"; // 3 months + 2 weeks as a gift, 106 days, 179 €
            public static string Id52 => "https://my.trade-with.me/cart?id=52"; // 6 months + 1 month as a gift, 214 days, 299 €
            public static string Id53 => "https://my.trade-with.me/cart?id=53"; // 1 year + 2 months as a gift, 427 days, 479 €
            public static string Id54 => "https://my.trade-with.me/cart?id=54"; // Lifetime / €200 discount included, 36500 days, 1590 €
        }

        // MOEX Standart Tariffs
        public static class MoexStandart
        {
            public static string Id10 => "https://my.trade-with.me/cart?id=10"; // 1 month, 31 days, 39 €
            public static string Id4 => "https://my.trade-with.me/cart?id=4";   // 3 months, 92 days, 99 €
            public static string Id6 => "https://my.trade-with.me/cart?id=6";   // 6 months, 183 days, 179 €
            public static string Id7 => "https://my.trade-with.me/cart?id=7";   // 1 year, 365 days, 299 €
            public static string Id8 => "https://my.trade-with.me/cart?id=8";   // Lifetime, 36500 days, 999 €
        }

        // MOEX Promo Tariffs
        public static class MoexPromo
        {
            public static string Id26 => "https://my.trade-with.me/cart?id=26"; // 1 month, 45 days, 39 €
            public static string Id48 => "https://my.trade-with.me/cart?id=48"; // 3 months + 2 weeks as a gift, 106 days, 99 €
            public static string Id49 => "https://my.trade-with.me/cart?id=49"; // 6 months + 1 month as a gift, 214 days, 179 €
            public static string Id50 => "https://my.trade-with.me/cart?id=50"; // 1 year + 2 months as a gift, 427 days, 299 €
            public static string Id55 => "https://my.trade-with.me/cart?id=55"; // Lifetime / €150 discount included, 36500 days, 849 €
        }
    }
}
