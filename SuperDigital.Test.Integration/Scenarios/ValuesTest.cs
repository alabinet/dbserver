using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using SuperDigital.Test.Integration.Fixtures;
using System.Net.Http;

namespace SuperDigital.Test.Integration.Scenarios
{
    public class ValuesTest
    {
        private readonly TestContext _testContext;

        public ValuesTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task ValidarRespostaAPI()
        {
            var response = await _testContext.Client.GetAsync("/api/TesteIntegração");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse2()
        {
            StringContent content = new StringContent("{}");
            var response = await _testContext.Client.PostAsync("/api/EfetuaLancamento", content);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
