using System.Threading.Tasks;
using Refit;
using Zeplin.NetCore.RestClient.ResponseModels.Dots;
using Zeplin.NetCore.RestClient.ResponseModels.Screens;

namespace Zeplin.NetCore.RestClient.Interfaces
{
    [Headers("Content-Type: application/json", "Accept: application/json")]
    public interface IScreens
    {
        [Get("/projects/{projectId}/screens/{screenId}/dots")]
        Task<DotsListResponseModel> GetDotsListForScreen([Header("zeplin-token")] string authToken,
            string projectId, string screenId);

        [Get("/projects/{projectId}/screens/{screenId}/versions")]
        Task<ScreenVersionsListResponseModel> GetVersionsListForScreen([Header("zeplin-token")] string authToken,
            string projectId, string screenId);
    }
}