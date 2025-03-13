using Xunit;

namespace IdentityServer.UnitTests.EmailSecurity;

public class EmailRateLimiterTests
{
    [Fact]
    public void Should_Limit_Email_Sending()
    {
        var rateLimiter = new EmailRateLimiter();
        string testEmail = "user@domain.com";

        for (int i = 0; i < 100; i++)
        {
            Assert.True(rateLimiter.CanSendEmail(testEmail));
        }

        Assert.False(rateLimiter.CanSendEmail(testEmail), "Rate limiter failed!");
    }
}
