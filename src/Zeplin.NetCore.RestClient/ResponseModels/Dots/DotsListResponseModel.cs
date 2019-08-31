using System.Collections.Generic;

namespace Zeplin.NetCore.RestClient.ResponseModels.Dots
{
    public class DotsListResponseModel
    {
        public DotsListResponseModel()
        {
            dots = new List<DotsResponseModel>();
        }

        public List<DotsResponseModel> dots { get; set; }
    }
}