﻿using System.Security.Cryptography.X509Certificates;

namespace CertificateManager
{
    internal abstract class Manage
    {
        private static readonly string TestCertificate = Path.Combine(
            Environment.GetEnvironmentVariable("PKICertDir"), "certificate.p12"
        );

        private static readonly X509Certificate x509Certificate = X509Certificate.CreateFromCertFile(TestCertificate);

        internal static cert9 GetCertificate()
        {
            cert9 certificate = new cert9
            {
                Hash = x509Certificate.GetCertHash(),
                EffectiveDate = DateTime.Parse(x509Certificate.GetEffectiveDateString()),
                ExpirationDate = DateTime.Parse(x509Certificate.GetExpirationDateString()),
                Format = x509Certificate.GetFormat(),
                HashCode = x509Certificate.GetHashCode(),

                IssuerName = x509Certificate.GetIssuerName(),
                KeyAlgorithm = x509Certificate.GetKeyAlgorithm(),
                KeyAlgorithmParameters = x509Certificate.GetKeyAlgorithmParameters(),

                Principal = x509Certificate.GetName(),
                PublicKey = x509Certificate.GetPublicKey(),
                RawCertData = x509Certificate.GetRawCertData(),
                SerialNumber = x509Certificate.GetSerialNumber(),
            };
            return certificate;
        }
    }
}
