using System.Collections.Generic;

namespace Zeplin.NetCore.RestClient.ResponseModels.Screens
{
    public class ScreenVersionsListResponseModel
    {
        public ScreenVersionsListResponseModel()
        {
            versions = new List<ScreenVersionResponseModel>();
        }

        public int totalVersionCount { get; set; }
        public int allowedVersionCount { get; set; }
        public List<ScreenVersionResponseModel> versions { get; set; }
    }
}