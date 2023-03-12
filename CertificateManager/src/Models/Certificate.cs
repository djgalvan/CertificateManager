using System.Security.Cryptography.X509Certificates;

namespace CertificateManager
{
    internal class Certificate
    {
        private static readonly string TestCertificate = Path.Combine(
            Environment.GetEnvironmentVariable("PKICertDir"), "certificate.p12"
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

        public int CertificateId { get; set; }

        public byte[] Hash { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Format { get; set; }

        public int HashCode { get; set; }

        public string IssuerName { get; set; }

        public string KeyAlgorithm { get; set; }

        public byte[] KeyAlgorithmParameters { get; set; }

        public string Principal { get; set; }

        public byte[] PublicKey { get; set; }

        public byte[] RawCertData { get; set; }

        public byte[] SerialNumber { get; set; }
    }
}