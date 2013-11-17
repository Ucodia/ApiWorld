using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using unirest_net.http;

namespace ApiWorld.Model
{
    public class ApisService
    {
        private const string ApiUri = "https://mashape.p.mashape.com/apis";

        private const string ApiKeyHeader = "X-Mashape-Authorization";
        private const string ApiKey = "yVCxJKR4Q6RhCrWsDs37auhuhRlN7MCV";

        public async Task<IList<Api>> GetApis()
        {
            var result = await Unirest.get(ApiUri)
                                      .header(ApiKeyHeader, ApiKey)
                                      .asJsonAsync<ApisResult>();

            return result.Body.Apis;
        }
    }
}
