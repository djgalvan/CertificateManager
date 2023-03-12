namespace CertificateManager
{
    internal class Certificate
    {
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