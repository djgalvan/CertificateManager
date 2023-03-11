using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CertificateManager
{
    internal class Cert9DbContext : DbContext
    {
        private static readonly string Cert9Db = Path.Combine(
            Environment.GetEnvironmentVariable("PKITestDir"), "cert9.db"
        );

        internal DbSet<Certificate> nssPublic { get; set; }

        private readonly SqliteConnectionStringBuilder sqliteConnection = new()
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
