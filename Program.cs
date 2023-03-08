using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using Certificates;

using var cert9DbContext = new Cert9DbContext();
cert9DbContext.Database.EnsureCreated();
cert9DbContext.Add(Certificates.Manage.GetCertificate());
cert9DbContext.SaveChanges();
var certificates = cert9DbContext.nssPublic
    .OrderBy(c => c.CertificateId)
    .First();

string certificateId = certificates.ToString();

// TODO: FixMe
Console.WriteLine(certificateId);

