<!--
This template is useful to build consensus about whether work should be done, and if so, the high-level shape of how it should be approached. Use this before fixating on a particular implementation.
-->

## Summary

Leveraging Sqlite, trusting developer certificates on Linux/Unix Desktop Environments may be accomplished through the User's Public Key Infrastructure (PKI) Directories. Using a database will increase the data integrity and security of these certificates.

Related #32842 

## Motivation and goals

The current state of Linux/Unix Desktop Environment certificates has fallen behind. NET 6.0 created the certificate and did not trust it. NET 7.0 seems to have dropped support for HTTPS altogether.

## In scope

1. Bare (non-containerized) Chromium-based Browsers (Chromium, Google Chrome, Microsoft Edge, etc.) ~/.pki/nssdb
2. Bare (non-containerized) Firefox (Profile1, Profile2, Profile3, etc.) ~/.mozilla/firefox/$ProfileDirectory

## Out of scope

1. Containerized Browsers (Snap, Flatpack) 
1. Any browser/utility that supports PKI databases
1. Root databases. 
1. Docker/Podman
1. Encrypting the database.
1. Any other advanced situations beyond typical Desktop Browser Development.
1. Automated testing with curl, documentation suggests that there is potential for future implementation.

## Risks / Unknowns

1. As far as Desktop Environments go, there shouldn't be any major issues, at least not that I can think of. Preserving the initial certificate stored in ~/.{dotnet,aspnet}/**/*.pfx should maintain other uses of the certificate. The regeneration/deletion of the certificate can be accomplished using the usual `dotnet https` commands.
2. Browsers/Utilities could drop support for PKI database. 

## Examples

The `dotnet https` command is a CLI utility. Utilizing the PKI databases would fix many issues revolving around `dotnet https --trust` usage.

[Experimentation](https://github.com/djgalvan/CertificateManager.git)

<!--
# Detailed design

It's often best not to fill this out until you get basic consensus about the above. When you do, consider adding an implementation proposal with the following headings:

Detailed design
Drawbacks
Considered alternatives
Open questions
References

If there's one clear design you have consensus on, you could do that directly in a PR.
-->
