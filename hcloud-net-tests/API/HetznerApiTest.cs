using hcloud_net.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace hcloud_net_tests.API
{
    public class HetznerApiTest
    {
        readonly HetznerApi Api = new HetznerApi(ChangeMeConstants.API_TOKEN);

        [Fact]
        public async Task CanGetActionList()
        {
            var response = await Api.GetActionListAsync();

            Assert.NotNull(response);
            Assert.NotNull(response.Actions);
        }

        [Fact]
        public async Task CanGetAction()
        {
            HetznerApi api = new HetznerApi(ChangeMeConstants.API_TOKEN);
            var response = await api.GetActionAsync(13);

            Assert.NotNull(response);
        }
    }
}
