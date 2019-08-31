using System;

namespace Zeplin.NetCore.RestClient.ResponseModels.Screens
{
    public class ScreenVersionResponseModel
    {
        public ScreenVersionResponseModel()
        {
            commit = new ScreenVersionCommitResponseModel();
            snapshot = new ScreenVersionSnapshotResponseModel();
        }

        public ScreenVersionCommitResponseModel commit { get; set; }
        public ScreenVersionSnapshotResponseModel snapshot { get; set; }
        public string _id { get; set; }
        public DateTime? created { get; set; }
    }

    public class ScreenVersionCommitResponseModel
    {
        public ScreenVersionCommitResponseModel()
        {
            author = new ScreenVersionCommitAuthorResponseModel();
        }

        public ScreenVersionCommitAuthorResponseModel author { get; set; }
    }

    public class ScreenVersionCommitAuthorResponseModel
    {
        public string _id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }

    public class ScreenVersionSnapshotResponseModel
    {
        public string source { get; set; }
        public string url { get; set; }
        public string _id { get; set; }
        public string density { get; set; }
    }
}