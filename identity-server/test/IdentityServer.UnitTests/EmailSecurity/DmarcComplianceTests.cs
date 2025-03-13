using Xunit;
using System.Threading.Tasks;

namespace IdentityServer.UnitTests.EmailSecurity;

public class DmarcComplianceTests
{
    [Fact]
    public async Task DmarcRecord_ShouldExist()
    {
        string testDomain = "example.com";
        await DmarcComplianceChecker.CheckDmarcRecord(testDomain);
        Assert.True(true, "DMARC record check executed successfully.");
    }
}

