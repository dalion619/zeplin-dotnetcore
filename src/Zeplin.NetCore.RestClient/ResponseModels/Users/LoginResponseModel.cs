using System;

namespace Zeplin.NetCore.RestClient.ResponseModels.Users
{
    public class LoginResponseModel
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public object emotar { get; set; }
        public object name { get; set; }
        public object surname { get; set; }
        public string status { get; set; }
        public string paymentPlan { get; set; }
        public bool emailNotifications { get; set; }
        public DateTime? notificationLastReadTime { get; set; }
        public string token { get; set; }
    }
}