using System;
using System.Collections.Generic;

namespace Zeplin.NetCore.RestClient.ResponseModels.Projects
{
    public class ProjectDetailsResponseModel
    {
        public ProjectDetailsResponseModel()
        {
            sections = new List<ProjectSectionResponseModel>();
            screens = new List<ProjectScreenResponseModel>();
        }

        public string _id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public List<ProjectSectionResponseModel> sections { get; set; }
        public List<ProjectScreenResponseModel> screens { get; set; }
    }

    public class ProjectSectionResponseModel
    {
        public ProjectSectionResponseModel()
        {
            screens = new List<string>();
        }

        public List<string> screens { get; set; }
        public string name { get; set; }
        public string _id { get; set; }
    }

    public class ProjectScreenResponseModel
    {
        public string _id { get; set; }
        public string name { get; set; }
        public DateTime? updated { get; set; }
        public string description { get; set; }
    }
}