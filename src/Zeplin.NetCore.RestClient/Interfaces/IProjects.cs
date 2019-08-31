using System.Threading.Tasks;
using Refit;
using Zeplin.NetCore.RestClient.ResponseModels.Projects;

namespace Zeplin.NetCore.RestClient.Interfaces
{
    [Headers("Content-Type: application/json", "Accept: application/json")]
    public interface IProjects
    {
        [Get("/projects")]
        Task<ProjectsListResponseModel> ListProjects([Header("zeplin-token")] string authToken);

        [Get("/projects/{projectId}/")]
        Task<ProjectDetailsResponseModel> GetProject([Header("zeplin-token")] string authToken,
            string projectId);
    }
}