using U2.CIS.Core;

namespace U2.CIS.Tests;

public class CallInfoServicesTests : CisTestsBase 
{
	[Fact]
	public async Task CanAddCallInfo()
	{
		CancellationToken cancellationToken = new();
		_callInfos.Clear();
		await SetupCisDbContext();

		var service = new CallInfoService(_dbContext);
		var count = service.GetCallInfoCount();
		Assert.Equal(0, count);

		var id = await service.AddCallAsync("UT8UU", cancellationToken);
		Assert.Equal(1, id);
		count = service.GetCallInfoCount();
		Assert.Equal(1, count);
	}
}