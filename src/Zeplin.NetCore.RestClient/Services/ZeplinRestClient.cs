using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Refit;
using Zeplin.NetCore.RestClient.Interfaces;
using Zeplin.NetCore.RestClient.Options;
using Zeplin.NetCore.RestClient.RequestModels.Users;
using Zeplin.NetCore.RestClient.ResponseModels.Dots;
using Zeplin.NetCore.RestClient.ResponseModels.Projects;
using Zeplin.NetCore.RestClient.ResponseModels.Screens;

namespace Zeplin.NetCore.RestClient.Services
{
    public class ZeplinRestClient : IZeplinRestClient
    {
        private readonly ZeplinRestClientOptions _options;
        private readonly IProjects _projects;
        private readonly IScreens _screens;
        private readonly IUsers _users;

        private string _authToken;

        public ZeplinRestClient(IOptions<ZeplinRestClientOptions> optionsAccessor)
        {
            if (optionsAccessor == null) throw new ArgumentNullException(nameof(optionsAccessor));

            _options = optionsAccessor.Value;
            _users = RestService.For<IUsers>(ZeplinRestClientConstants.ZeplinBaseUrl);
            _projects = RestService.For<IProjects>(ZeplinRestClientConstants.ZeplinApiUrl);
            _screens = RestService.For<IScreens>(ZeplinRestClientConstants.ZeplinApiUrl);

            Initialise();
        }

        public async Task<ProjectsListResponseModel> GetProjects()
        {
            var res = await _projects.ListProjects(_authToken);
            return res;
        }

        public async Task<ProjectDetailsResponseModel> GetProjectDetailsById(string projectId)
        {
            var res = await _projects.GetProject(_authToken, projectId);
            return res;
        }

        public async Task<ScreenVersionsListResponseModel> GetScreenVersionsById(string projectId,
            string screenId)
        {
            var res = await _screens.GetVersionsListForScreen(_authToken, projectId, screenId);
            return res;
        }

        public async Task<DotsListResponseModel> GetScreenDotsById(string projectId, string screenId)
        {
            var res = await _screens.GetDotsListForScreen(_authToken, projectId, screenId);
            return res;
        }

        private void Initialise()
        {
            var loginResponse = _users.Login(
                    new LoginRequestModel {handle = _options.username, password = _options.password}).GetAwaiter()
                .GetResult();
            ;
            _authToken = loginResponse.token;
        }
    }
}