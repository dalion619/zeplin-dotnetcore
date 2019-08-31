namespace Zeplin.NetCore.RestClient
{
    public class ZeplinRestClientConstants
    {
        public static string ZeplinBaseUrl => "https://api.zeplin.io";
        public static string ZeplinApiVersion => "v2";
        public static string ZeplinApiUrl => $"{ZeplinBaseUrl}/{ZeplinApiVersion}";
    }
}