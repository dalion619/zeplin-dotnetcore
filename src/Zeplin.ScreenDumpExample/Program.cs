using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zeplin.NetCore.RestClient.Extensions;
using Zeplin.NetCore.RestClient.Interfaces;

namespace Zeplin.ScreenDumpExample
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Add our services for DI
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .AddZeplinRestClientService(options =>
                {
                    options.username = "";
                    options.password = "";
                })
                .BuildServiceProvider();

            // Get the services required
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            var zeplinRestClient = serviceProvider.GetService<IZeplinRestClient>();

            var projectId = "";
            // Get the project's info from Zeplin's API
            var projectDetails = await zeplinRestClient.GetProjectDetailsById(projectId);

            // A view model to make our dump easier
            var projectDumpModel = new ProjectDumpViewModel(projectDetails);

            foreach (var screen in projectDumpModel.ScreenDetails)
            {
                var screenId = screen.Key;
                var screenName = screen.Value;
                var screenSection = projectDumpModel.ScreenSections[screenId];
                var screenVersions = await zeplinRestClient.GetScreenVersionsById(projectDumpModel.ProjectId, screenId);

                // All the screen versions ordered by creation
                var versionsToDump = screenVersions.versions.OrderBy(o => o.created.GetValueOrDefault()).ToList();
                // A base path to make organisation easier.
                var screenBasePath = Path.Combine(AppContext.BaseDirectory, projectDumpModel.ProjectName.SanitisePath(),
                    screenSection.SanitisePath(), screenName.SanitisePath());

                foreach (var version in versionsToDump)
                {
                    var currentVersionFileName = Path.Combine(screenBasePath,
                        Util.GeneratePathForScreenVersion(version.created.GetValueOrDefault(),
                            version.commit.author.username, screenName));
                    var currentVersionFileInfo = new FileInfo(currentVersionFileName);

                    // If file already exists, skip downloading it
                    if (!currentVersionFileInfo.Directory.Exists)
                    {
                        var httpClient = httpClientFactory.CreateClient();
                        using (var stream = await httpClient.GetStreamAsync(version.snapshot.url))
                        {
                            currentVersionFileInfo.Directory.Create();
                            using (var fileStream = currentVersionFileInfo.OpenWrite())
                            {
                                await stream.CopyToAsync(fileStream);
                            }
                        }
                    }
                }
            }
        }
    }
}