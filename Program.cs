using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Sqlite;
using CertificateManager;

using var db = new CertificateContext();
db.Add(CertificateManager.CertificateManager.GetCertificate());
db.SaveChanges();
var certificates = db.Certificates
    .OrderBy(c => c.CertificateId)
    .First();

string certificateId = certificates.ToString();

// TODO: FixMe
Console.WriteLine(certificateId);

