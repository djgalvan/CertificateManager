namespace Config;

internal static partial class PKI {
    internal static readonly string Cert9Db = Path.Combine(
        Environment.GetEnvironmentVariable("PKIDirectory"), "cert9.db"
    );

    internal static readonly string Key4Db = Path.Combine(
        Environment.GetEnvironmentVariable("PKIDirectory"), "key4.db"
    );
}