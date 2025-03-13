using System; 
using System.Collections.Generic;

namespace IdentityServer.EmailSecurity;

public class EmailRateLimiter
{
    private readonly Dictionary<string, int> _emailSendCount = new();
    private readonly int _maxEmailsPerHour = 100; //TODO: Move to configuration

    public bool CanSendEmail(string senderEmail)
    {
        if (!_emailSendCount.ContainsKey(senderEmail))
            _emailSendCount[senderEmail] = 0;

        if (_emailSendCount[senderEmail] >= _maxEmailsPerHour)
            return false;

        _emailSendCount[senderEmail]++;
        return true;
    }
}
