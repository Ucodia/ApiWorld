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

        public async Task<ApisResult> GetApis(string query = "", int limit = 20, int offset = 0, string category = "")
        {
            var requestUrl = string.Format(
                "{0}?query={1}&limit={2}&offset={3}&category={4}",
                ApiUri, query, limit, offset, category);

            var result = await Unirest.get(requestUrl)
                                      .header(ApiKeyHeader, ApiKey)
                                      .asJsonAsync<ApisResult>();

            return result.Body;
        }
    }
}
