using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using CertificateManager;

using var cert9DbContext = new Cert9DbContext();
cert9DbContext.Database.EnsureCreated();
cert9DbContext.Add(Manage.GetCertificate());
cert9DbContext.SaveChanges();
