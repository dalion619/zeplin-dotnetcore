using Microsoft.Extensions.Options;

namespace Zeplin.NetCore.RestClient.Options
{
    /// <summary> Configuration options for <see cref="ZeplinRestClient" /> </summary>
    public class ZeplinRestClientOptions : IOptions<ZeplinRestClientOptions>
    {
        /// <summary>
        ///     Zeplin username/email address.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        ///     Zeplin password.
        /// </summary>
        public string password { get; set; }


        ZeplinRestClientOptions IOptions<ZeplinRestClientOptions>.Value => this;
    }
}