using System.Security.Cryptography.X509Certificates;

namespace Certificates
{
    internal abstract class Manage
    {
        private static readonly string TestCertificate = Path.Combine(
            Environment.GetEnvironmentVariable("HOME"), "Projects",
            "CertificateManager", "823F9A74E036BC06378EB64BB4C20E17D48D7A9E.pfx"
        );

        private static readonly X509Certificate x509Certificate = X509Certificate.CreateFromCertFile(TestCertificate);

        internal static Certificate GetCertificate()
        {
            Certificate certificate = new Certificate
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
