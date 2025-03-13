using System;
using System.Linq;
using System.Threading.Tasks;
using DnsClient;

namespace IdentityServer.EmailSecurity;

public static class DmarcComplianceChecker
{
    public static async Task CheckDmarcRecord(string domain)
    {
        string dmarcRecord = $"_dmarc.{domain}";
        var dnsResolver = new LookupClient();
        var result = await dnsResolver.QueryAsync(dmarcRecord, QueryType.TXT);

        if (!result.Answers.Any())
        {
            Console.WriteLine("DMARC record missing! Compliance issue detected.");
        }
        else
        {
            Console.WriteLine("DMARC record found: " + string.Join(", ", result.Answers));
        }
    }
}
