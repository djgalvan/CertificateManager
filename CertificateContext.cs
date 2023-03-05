using Microsoft.EntityFrameworkCore;

namespace CertificateManager
{
    internal class CertificateContext : DbContext
    {
        internal string Cert9Db { get; }
        public CertificateContext()
        {
            string Cert9Db = Path.Combine(
                Environment.GetEnvironmentVariable("AppData"),
                "Mozilla", "Firefox", "Profiles", "5rc3d8ha.default-release", "cert9.db"
            );
        }

        public DbSet<Certificate> Certificates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={Cert9Db}");
    }
}
