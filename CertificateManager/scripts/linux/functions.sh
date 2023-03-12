#!/bin/bash
# Append to ~/.bashrc
# if [ -f ~/Projects/CertificateManager/CertificateManager/scripts/linux/functions.sh ]; then
# 	. ~/Projects/CertificateManager/CertificateManager/scripts/linux/functions.sh
# fi

# Source: https://www.ibm.com/docs/en/api-connect/2018.x?topic=overview-generating-self-signed-certificate-using-openssl
# Already have deps installed in wsl
function New-SelfSignedCerts {
    openssl req -x509 -newkey rsa:2048 -nodes -keyout $PKICertDir/key1.pem -x509 -days 365 -out $PKICertDir/certificate1.pem
    openssl req -x509 -newkey rsa:2048 -nodes -keyout $PKICertDir/key2.pem -x509 -days 365 -out $PKICertDir/certificate2.pem
    openssl req -x509 -newkey rsa:2048 -nodes -keyout $PKICertDir/key3.pem -x509 -days 365 -out $PKICertDir/certificate3.pem
    # Country
    # State
    # Locality
    # Org
    # Unit
    # FQDN or User
    # Email
}

function CreatePKS12s-FromFiles {
    openssl pkcs12 -inkey $PKICertDir/key1.pem -in $PKICertDir/certificate1.pem -export -out $PKICertDir/certificate1.p12
    openssl pkcs12 -inkey $PKICertDir/key2.pem -in $PKICertDir/certificate2.pem -export -out $PKICertDir/certificate2.p12
    openssl pkcs12 -inkey $PKICertDir/key3.pem -in $PKICertDir/certificate3.pem -export -out $PKICertDir/certificate3.p12
}

function Create-BarePKIDatabase {
    certutil -Nd sql:$PKIRefDir
}

function Dump-PKICertDatabases {
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
}

function Dump-PKIKeyDatabases {
    cert9ReferenceTables=$(sqlite3 $PKIRefDir/cert9.db -cmd .tables .quit)
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

function Review-Cert9db {
    code --diff $PKILogDir/cert9-testdump.log $PKILogDir/cert9-refdump.log
}