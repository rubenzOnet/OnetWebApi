using FakeItEasy;
using Onet.Cliente.Repositories.Cliente.Interfaces;
using Xunit;

namespace Onet.Test.Client
{
    public class ClienteGetAllServices_Test
    {
        [Fact]
        public void GetClientAllAsyncTest()
        {
            var fakeIClienteGetAllRepository = A.Fake<IClienteGetAllRepository>();

            A
                .CallTo(() => fakeIClienteGetAllRepository.GetAllClientsAsync());
        }
    }
}
