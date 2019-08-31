using System.Threading.Tasks;
using Refit;
using Zeplin.NetCore.RestClient.RequestModels.Users;
using Zeplin.NetCore.RestClient.ResponseModels.Users;

namespace Zeplin.NetCore.RestClient.Interfaces
{
    [Headers("Content-Type: application/json", "Accept: application/json")]
    public interface IUsers
    {
        [Post("/users/login")]
        Task<LoginResponseModel> Login([Body] LoginRequestModel model);
    }
}