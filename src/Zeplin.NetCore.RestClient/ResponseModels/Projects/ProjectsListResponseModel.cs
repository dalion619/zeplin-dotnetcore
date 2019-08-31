using System;
using System.Collections.Generic;

namespace Zeplin.NetCore.RestClient.ResponseModels.Projects
{
    public class ProjectsListResponseModel
    {
        public ProjectsListResponseModel()
        {
            projects = new List<ProjectResponseModel>();
        }

        public List<ProjectResponseModel> projects { get; set; }
    }

    public class ProjectResponseModel
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
    }
}