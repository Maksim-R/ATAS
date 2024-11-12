using System;

namespace ATAS.Test
{
    /// <summary>
    /// Содержит базовые URL-ы для различных страниц и тарифов приложения.
    /// </summary>
    public static class BaseUrl
    {
        /// <summary>
        /// Основные страницы сайта.
        /// </summary>
        public static class Page
        {
            /// <summary>
            /// URL страницы магазина.
            /// </summary>
            public static string Shop => "https://my.trade-with.me/";

            /// <summary>
            /// URL страницы приветственного опроса после регистрации.
            /// </summary>
            public static string Wizard => "https://my.trade-with.me/download#wizard";

            /// <summary>
            /// Тарифы Global Standard.
            /// </summary>
            public static class GlobalStandard
            {
                /// <summary>Тариф: 1 месяц, 69 €</summary>
                public static string Id11 => "https://my.trade-with.me/cart?id=11";

                /// <summary>Тариф: 3 месяца, 179 €</summary>
                public static string Id5 => "https://my.trade-with.me/cart?id=5";

                /// <summary>Тариф: 6 месяцев, 299 €</summary>
                public static string Id1 => "https://my.trade-with.me/cart?id=1";

                /// <summary>Тариф: 1 год, 479 €</summary>
                public static string Id2 => "https://my.trade-with.me/cart?id=2";

                /// <summary>Тариф: Пожизненно, 1790 €</summary>
                public static string Id3 => "https://my.trade-with.me/cart?id=3";
            }

            /// <summary>
            /// Промо-тарифы Global.
            /// </summary>
            public static class GlobalPromo
            {
                /// <summary>Тариф: 1 месяц, 45 дней, 69 €</summary>
                public static string Id22 => "https://my.trade-with.me/cart?id=22";

                /// <summary>Тариф: 3 месяца + 2 недели в подарок, 179 €</summary>
                public static string Id51 => "https://my.trade-with.me/cart?id=51";

                /// <summary>Тариф: 6 месяцев + 1 месяц в подарок, 299 €</summary>
                public static string Id52 => "https://my.trade-with.me/cart?id=52";

                /// <summary>Тариф: 1 год + 2 месяца в подарок, 479 €</summary>
                public static string Id53 => "https://my.trade-with.me/cart?id=53";

                /// <summary>Тариф: Пожизненно с учётом скидки 200 €, 1590 €</summary>
                public static string Id54 => "https://my.trade-with.me/cart?id=54";
            }

            /// <summary>
            /// Тарифы MOEX Standard.
            /// </summary>
            public static class MoexStandard
            {
                /// <summary>Тариф: 1 месяц, 39 €</summary>
                public static string Id10 => "https://my.trade-with.me/cart?id=10";

                /// <summary>Тариф: 3 месяца, 99 €</summary>
                public static string Id4 => "https://my.trade-with.me/cart?id=4";

                /// <summary>Тариф: 6 месяцев, 179 €</summary>
                public static string Id6 => "https://my.trade-with.me/cart?id=6";

                /// <summary>Тариф: 1 год, 299 €</summary>
                public static string Id7 => "https://my.trade-with.me/cart?id=7";

                /// <summary>Тариф: Пожизненно, 999 €</summary>
                public static string Id8 => "https://my.trade-with.me/cart?id=8";
            }

            /// <summary>
            /// Промо-тарифы MOEX.
            /// </summary>
            public static class MoexPromo
            {
                /// <summary>Тариф: 1 месяц, 45 дней, 39 €</summary>
                public static string Id26 => "https://my.trade-with.me/cart?id=26";

                /// <summary>Тариф: 3 месяца + 2 недели в подарок, 99 €</summary>
                public static string Id48 => "https://my.trade-with.me/cart?id=48";

                /// <summary>Тариф: 6 месяцев + 1 месяц в подарок, 179 €</summary>
                public static string Id49 => "https://my.trade-with.me/cart?id=49";

                /// <summary>Тариф: 1 год + 2 месяца в подарок, 299 €</summary>
                public static string Id50 => "https://my.trade-with.me/cart?id=50";

                /// <summary>Тариф: Пожизненно с учётом скидки 150 €, 849 €</summary>
                public static string Id55 => "https://my.trade-with.me/cart?id=55";
            }
        }
    }
}
