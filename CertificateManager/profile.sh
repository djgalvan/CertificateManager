#!/bin/bash
# Append to ~/.bashrc
# if [ -f ~/Projects/CertificateManager/CertificateManager/profile.sh ]; then
# 	. ~/Projects/CertificateManager/CertificateManager/profile.sh
# fi

export ProjectDir=$HOME/Projects/CertificateManager/CertificateManager
export PKIConfig=$ProjectDir/pkiconfig.ini
export PKIDir=$ProjectDir/pki
export PKIKeyDir=$PKIDir/keys
export PKICertDir=$PKIDir/certs
export PKIPKCSDir=$PKIDir/pkcs
export PKIRefDir=$PKIDir/refdb
export PKITestDir=$PKIDir/testdb
export PKILogDir=$PKIDir/logs

function Scaffold-PKIDirectories {
    mkdir -p $PKIKeyDir $PKICertDir $PKILogDir $PKIPKCSDir $PKIRefDir $PKITestDir
}

function Clean-PKIDirectories {
    rm -rf $PKIDir/*
}

# Source: https://www.ibm.com/docs/en/api-connect/2018.x?topic=overview-generating-self-signed-certificate-using-openssl
function New-SelfSignedCerts {
    openssl req -x509 -newkey rsa -nodes \
        -keyout $PKIKeyDir/key1.key -days 365 \
           -out $PKICertDir/cert1.cert -config $PKIConfig
    openssl req -x509 -newkey rsa -nodes \
        -keyout $PKIKeyDir/key2.key -days 365 \
           -out $PKICertDir/cert2.cert -config $PKIConfig
    openssl req -x509 -newkey rsa -nodes \
        -keyout $PKIKeyDir/key3.key -days 365 \
           -out $PKICertDir/cert3.cert -config $PKIConfig
}
function CreatePKS12s-FromFiles {
    openssl pkcs12 -inkey $PKIKeyDir/key1.key -in $PKICertDir/cert1.cert -export -out $PKIPKCSDir/pkcs12-1.p12 --password pass:
    openssl pkcs12 -inkey $PKIKeyDir/key2.key -in $PKICertDir/cert2.cert -export -out $PKIPKCSDir/pkcs12-2.p12 --password pass:
    openssl pkcs12 -inkey $PKIKeyDir/key3.key -in $PKICertDir/cert3.cert -export -out $PKIPKCSDir/pkcs12-3.p12 --password pass:
}

function Initialize-PKIRefDatabase {
    pk12util -i $PKIPKCSDir/pkcs12-1.p12 -d sql:$PKIRefDir -W '' -K ''
    pk12util -i $PKIPKCSDir/pkcs12-2.p12 -d sql:$PKIRefDir -W '' -K ''
    pk12util -i $PKIPKCSDir/pkcs12-3.p12 -d sql:$PKIRefDir -W '' -K ''
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