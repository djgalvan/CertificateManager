using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using CertificateManager;

using var cert9Db = new Cert9Context();
cert9Db.Database.EnsureCreated();
