using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CertificateManager.src
{
    internal class Cert9DbContext : DbContext
    {
        private static string Cert9Db = Path.Combine(
            Environment.GetEnvironmentVariable("HOME"), "Projects",
            "CertificateManager", "pki", "test", "cert9.db"
        );

        public DbSet<Certificate> nssPublic { get; set; }

        SqliteConnectionStringBuilder sqliteConnection = new()
        {
            DataSource = Cert9Db,
            Mode = SqliteOpenMode.ReadWriteCreate,
        };

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(sqliteConnection.ToString());
        }
    }
}
