using System.Security.Cryptography.X509Certificates;

namespace CertificateManager
{
    internal class CertificateManager
    {
        readonly static string TestCertificate = Path.Combine(
            Environment.GetEnvironmentVariable("USERPROFILE"),
            "CertificateManager", "8E1295C3B234919CDA8E4BC398AA6A6BAD880C46.pfx"
        );

        readonly static X509Certificate x509Certificate = X509Certificate.CreateFromCertFile(TestCertificate);

        // TODO: Generate Certificate
        internal static Certificate GetCertificate()
        {
            Certificate certificate = new Certificate
            {
                Hash = x509Certificate.GetCertHash(),
                EffectiveDate = DateTime.Parse(x509Certificate.GetEffectiveDateString()),
                ExpirationDate = DateTime.Parse(x509Certificate.GetExpirationDateString()),
                Format = x509Certificate.GetFormat(),
                HashCode = x509Certificate.GetHashCode(),

                // TODO: Implement new Issuer property after GetIssuer method is implemented
                IssuerName = x509Certificate.GetIssuerName(),
                KeyAlgorithm = x509Certificate.GetKeyAlgorithm(),
                KeyAlgorithmParameters = x509Certificate.GetKeyAlgorithmParameters(),

                // TODO: Implement new Subject property after GetSubject method is implemented
                Principal = x509Certificate.GetName(),
                PublicKey = x509Certificate.GetPublicKey(),
                RawCertData = x509Certificate.GetRawCertData(),
                SerialNumber = x509Certificate.GetSerialNumber(),
            };
            return certificate;
        }

        internal static void AddCertificate(CertificateContext context, Certificate certificate)
        {
            context.nssPublic.Add(certificate);
        }

        // TODO: Remove Certificate
        //internal static void RemoveCertificate(CertificateContext context, Certificate certificate)
        //{
        //    context.Certificates.Remove(certificate);
        //}

    }
}
