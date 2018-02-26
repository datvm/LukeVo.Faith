using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LukeVo.Faith.MainWebsite.Models.BibleGatewayApi
{

    public class BibleGatewayConnector
    {
        private const int ApiLifetime = 43200;

        private const string ServerEndpoint = "https://www.biblegateway.com/";
        private const string VotDEndpoint = "votd/get/?format=json&version={0}";

        private RestClient RestClient = new RestClient(ServerEndpoint);

        private CachableApi<string, VotDResponse> VotDCache = new CachableApi<string, VotDResponse>(ApiLifetime);

        public BibleGatewayConnector() { }
        
        public async Task<VotDResponse> GetVotDAsync(string version)
        {
            return await this.VotDCache.GetOrRequestAsync(version, async () =>
            {
                var request = new RestRequest(string.Format(VotDEndpoint, version), Method.GET);

                var response = await this.RestClient.ExecuteTaskAsync(request);
                var result = JsonConvert.DeserializeObject<VotDResponse>(response.Content);

                if (result.votd == null)
                {
                    throw new ArgumentException("Unknown version");
                }

                return result;
            });
        }

    }

}
