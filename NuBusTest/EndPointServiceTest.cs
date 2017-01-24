using NUnit.Framework;

namespace NuBusTest
{
    using FakeItEasy;
    using NuBus.Service;

    [TestFixture]
	public class EndPointServiceTest
	{ 
		[Test]
		public void TestCallToDisposeByUsing()
		{
            var fakeService = A.Fake<EndpointService>();

            using (fakeService)
			{
			}

            A.CallTo(() => fakeService.Dispose(true)).MustHaveHappened();
		}

	}
}