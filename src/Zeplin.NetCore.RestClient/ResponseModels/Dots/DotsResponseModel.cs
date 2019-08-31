using System.Collections.Generic;

namespace Zeplin.NetCore.RestClient.ResponseModels.Dots
{
    public class DotsResponseModel
    {
        public DotsResponseModel()
        {
            creator = new DotCreatorResponseModel();
            comments = new List<DotCommentResponseModel>();
        }

        public string _id { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public DotCreatorResponseModel creator { get; set; }
        public List<DotCommentResponseModel> comments { get; set; }
    }

    public class DotCreatorResponseModel
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}