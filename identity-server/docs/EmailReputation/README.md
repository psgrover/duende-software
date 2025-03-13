# Email Reputation & Deliverability Fix With IdentityServer

## Overview
Email deliverability issues can significantly impact business communications, especially when emails end up in spam instead of inboxes. This project enhances IdentityServer by adding authentication and validation mechanisms to improve domain reputation and email deliverability. It ensures that emails sent through the system follow best practices like SPF, DKIM, DMARC authentication, and rate limiting.

## Features
- **SPF, DKIM, and DMARC validation** to prevent spoofing
- **OAuth2-based email authentication** for secure sending
- **Email rate limiting** to maintain domain reputation
- **Blacklist monitoring and removal process**
- **Support for email warm-up strategies**
- **Dedicated subdomain configuration for bulk email sending**

## Repository Structure
```
identity-server  
│── src  
│   ├── IdentityServer  
│   │   ├── EmailSecurity  
│   │   │   ├── EmailRateLimiter.cs  
│   │   │   ├── DmarcComplianceChecker.cs  
│   │   │   ├── IdentityServerEmailAuth.cs  
│   ├── Configuration  
│   │   ├── IdentityServerConfig.cs  
│── test  
│   ├── IdentityServer.UnitTests  
│   │   ├── EmailSecurity  
│   │   │   ├── EmailRateLimiterTests.cs  
│   │   │   ├── DmarcComplianceTests.cs  
│── test-results  
│   ├── InboxTestResults.md  
│   ├── BlacklistRemoval.txt  
│   ├── dns_records.txt  
│   ├── domain_segmentation.txt  
│   ├── WarmUpStrategy.txt  
│── docs  
│   ├── ReputationAnalysis.md  
│   ├── FinalReport.md  
│   ├── README.md
│── .gitignore  
```

## Getting Started

### Clone the Repository
```sh
git clone https://github.com/psgrover/duende-software.git
cd duende-software
```

### Install Dependencies
```sh
dotnet restore
```

### Configure IdentityServer for Email Authentication
- Update `IdentityServerConfig.cs` to allow email-based OAuth authentication.
- Ensure IdentityServer enforces secure email sending policies.

### Running Tests
```sh
dotnet test /repo/duende-software/identity-server/test/IdentityServer.UnitTests/EmailSecurity/
```

## Deployment
1. Ensure DNS settings include valid SPF, DKIM, and DMARC records.
2. Deploy IdentityServer with email authentication enabled.
3. Monitor email deliverability using Google Postmaster Tools and MXToolbox.

## Licensing Disclaimer
This project integrates **Duende IdentityServer**, which is free for **development and testing** but requires a **paid license for production use**. Learn more at [Duende Licensing](https://duendesoftware.com/products/identityserver#pricing).

## Contributing
Pull requests are welcome! If you find issues, feel free to submit a GitHub issue.

## License
This project follows the [MIT License](LICENSE).
