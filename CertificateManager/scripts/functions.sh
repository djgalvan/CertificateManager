#!/bin/bash

# Source: https://www.ibm.com/docs/en/api-connect/2018.x?topic=overview-generating-self-signed-certificate-using-openssl
function New-SelfSignedCert {
    openssl req -newkey rsa:2048 -nodes -keyout $PKICertDir/key.pem -x509 -days 365 -out $PKICertDir/certificate.pem
    # Country
    # State
    # Locality
    # Org
    # Unit
    # FQDN or User
    # Email
}
function Review-SelfSignedCert {
    openssl x509 -text -noout -in $PKICertDir/certificate.pem
}
function CreatePKS12-FromFiles {
    openssl pkcs12 -inkey $PKICertDir/key.pem -in $PKICertDir/certificate.pem -export -out $PKICertDir/certificate.p12
}
function Validate-PKS12 {
    openssl pkcs12 -in $PKICertDir/certificate.p12 -noout -info
}

function Dump-PKIDatabases {
    cert9ReferenceTables=$(sqlite3 $PKIRefDir/cert9.db -cmd .tables .quit)
    cert9ReferenceDump=$(sqlite3 $PKIRefDir/cert9.db -cmd .dump .quit)
    cert9TestTables=$(sqlite3 $PKITestDir/cert9.db -cmd .tables .quit)
    cert9TestDump=$(sqlite3 $PKITestDir/cert9.db -cmd .dump .quit)
    {
    echo "$cert9ReferenceTables"
    echo "$cert9TestDump"
    } > $PKILogDir/cert9-testdump.log
    {
    echo "$cert9TestTables"
    echo "$cert9ReferenceDump"
    } > $PKILogDir/cert9-refdump.log

    key4ReferenceTables=$(sqlite3 $PKIRefDir/key4.db -cmd .tables .quit)
    key4ReferenceDump=$(sqlite3 $PKIRefDir/key4.db -cmd .dump .quit)
    key4TestTables=$(sqlite3 $PKITestDir/key4.db -cmd .tables .quit)
    key4TestDump=$(sqlite3 $PKITestDir/key4.db -cmd .dump .quit)
    {
    echo "$key4ReferenceTables"
    echo "$key4TestDump"
    } > $PKILogDir/key4-testdump.log
    {
    echo "$key4TestTables"
    echo "$key4ReferenceDump"
    } > $PKILogDir/key4-refdump.log
}