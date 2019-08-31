using System;

namespace Zeplin.NetCore.RestClient.ResponseModels.Dots
{
    public class DotCommentResponseModel
    {
        public DotCommentResponseModel()
        {
            author = new DotCommentAuthorResponseModel();
        }

        public string _id { get; set; }
        public string note { get; set; }
        public DotCommentAuthorResponseModel author { get; set; }
        public DateTime? updated { get; set; }
        public DateTime? created { get; set; }
    }

    public class DotCommentAuthorResponseModel
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}