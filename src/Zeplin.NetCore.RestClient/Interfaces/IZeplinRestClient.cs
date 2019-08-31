using System.Threading.Tasks;
using Zeplin.NetCore.RestClient.ResponseModels.Dots;
using Zeplin.NetCore.RestClient.ResponseModels.Projects;
using Zeplin.NetCore.RestClient.ResponseModels.Screens;

namespace Zeplin.NetCore.RestClient.Interfaces
{
    public interface IZeplinRestClient
    {
        Task<ProjectsListResponseModel> GetProjects();
        Task<ProjectDetailsResponseModel> GetProjectDetailsById(string projectId);

        Task<ScreenVersionsListResponseModel> GetScreenVersionsById(string projectId,
            string screenId);

        Task<DotsListResponseModel> GetScreenDotsById(string projectId, string screenId);
    }
}