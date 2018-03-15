using Classificator.database;
using System;
using System.Collections.Generic;


namespace Classificator
{
    class QueryMap
    {
        public static bool use_date { get; set; }
        public static DateTime date { get; set; }
        public static User user { get; set; }
        public static List<String> symptoms { get; set; }
    }
}
