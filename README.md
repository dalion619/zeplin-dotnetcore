# Zeplin.NetCore
.NET Core REST client for [zeplin.io](https://zeplin.io/). Unofficial and unsupported, Zeplin has no documented public API.

## Documentation
This client is built with [Refit](https://github.com/reactiveui/refit). The interfaces used interact with Zeplin's API endpoints can be found at [src/Zeplin.NetCore.RestClient/Interfaces](https://github.com/dalion619/zeplin-dotnetcore/tree/master/src/Zeplin.NetCore.RestClient/Interfaces). This started as a proof of concept of gaining additional value for non-designers in the product team.

### Use cases

* Compiling a linear history of subtle design changes by comparing screen version snapshots using a tool like [Blink-Diff](https://github.com/yahoo/blink-diff
).

* Exporting notes to Excel with [EPPlus](https://github.com/JanKallman/EPPlus) for tracking open issues.

## Usage
Register and configure the service with the `AddZeplinRestClientService` extension method.
```c#
.AddZeplinRestClientService(options =>
                {
                    options.username = "YourZeplinUsername";
                    options.password = "YourZeplinPassword";
                })
```

Inject or resolve the client service.
```c#
var zeplinRestClient = serviceProvider.GetService<IZeplinRestClient>();
```

Interact with the required endpoints.
```c#
var projectDetails = await zeplinRestClient.GetProjectDetailsById(projectId);
```

## Example
The `Zeplin.ScreenDumpExample` project has sample code showing how to download a snapshot for every version of a screen in a Zeplin project.