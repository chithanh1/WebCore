using System.Collections.Generic;

namespace VegeFood.Models
{
    public static class Config
    {
        public static Dictionary<string, string> UserType = new Dictionary<string, string>()
        {
            {"admin", "0" },
            {"user", "1" },
            {"cutomer", "2" }
        };

        public static Dictionary<string, string> Status = new Dictionary<string, string>()
        {
            {"enable", "0" },
            {"disable", "0" }
        };
    }
}
