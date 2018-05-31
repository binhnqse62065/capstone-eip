using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsService.Models
{
    public static class ConstantManager
    {
        public static int STT_SUCCESS = 0;
        public static int STT_FAIL = 1;
        public static int STT_MISSING_PARAM = 2;
        public static int STT_UNAUTHORIZED = 3;

        public static string MES_LOGIN_SUCCESS = "Login successfully";
        public static string MES_LOGIN_FAIL = "Login fail";
        public static string MES_MISSING_PARAM = "Missing parameter";
        public static string MES_UNVALID_TOKEN = "Token is unvalid or expired";
        //check role khi xem store
        public static string MES_STORE_UNAUTHENTICATED = "You do not have permission to see report of this store";
        // check role khi nhan token
        public static string MES_ROLE_UNAUTHENTICATED = "You do not have permission";
        public static string MES_LOAD_REPORT_SUCCESS = "Load report success";

        public static string ROLE_ADMIN = "Administrator";
        public static string ROLE_MANAGER = "StoreManager";

    }
}
