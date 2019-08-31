using System.Collections.Generic;
using Zeplin.NetCore.RestClient.ResponseModels.Projects;

namespace Zeplin.ScreenDumpExample
{
    public class ProjectDumpViewModel
    {
        public ProjectDumpViewModel(ProjectDetailsResponseModel model)
        {
            ProjectInfo = model;
            ScreenDetails = new Dictionary<string, string>();
            ScreenSections = new Dictionary<string, string>();

            foreach (var section in model.sections)
            foreach (var id in section.screens)
                ScreenSections.TryAdd(id, section.name);

            foreach (var screen in model.screens)
                ScreenDetails.TryAdd(screen._id, screen.name);
        }

        public ProjectDetailsResponseModel ProjectInfo { get; }
        public Dictionary<string, string> ScreenSections { get; }
        public Dictionary<string, string> ScreenDetails { get; }

        public string ProjectId => ProjectInfo._id;

        public string ProjectName => ProjectInfo.name;

        public string ScreenSectionName(string screenId)
        {
            return ScreenSections[screenId];
        }

        public string ScreenName(string screenId)
        {
            return ScreenDetails[screenId];
        }
    }
}