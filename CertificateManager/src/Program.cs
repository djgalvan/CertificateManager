using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using CertificateManager;

using var cert9Db = new Cert9Context();
using var key4Db = new Key4Context();
cert9Db.Database.EnsureCreated();
key4Db.Database.EnsureCreated();