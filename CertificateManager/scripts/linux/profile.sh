#!/bin/bash
# Append to ~/.bashrc
# if [ -f ~/Projects/CertificateManager/CertificateManager/scripts/linux/profile.sh ]; then
# 	. ~/Projects/CertificateManager/CertificateManager/scripts/linux/profile.sh
# fi

export ProjectDir=$HOME/Projects/CertificateManager/CertificateManager
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

# Source: https://www.ibm.com/docs/en/api-connect/2018.x?topic=overview-generating-self-signed-certificate-using-openssl
function New-SelfSignedCerts {
    openssl req -x509 -newkey rsa -nodes \
        -keyout $PKIKeyDir/key1.pem -days 365 \
           -out $PKICertDir/cert1.pem -config $PKIDir/config.ini
    openssl req -x509 -newkey rsa -nodes \
        -keyout $PKIKeyDir/key2.pem -days 365 \
           -out $PKICertDir/cert2.pem -config $PKIDir/config.ini
    openssl req -x509 -newkey rsa -nodes \
        -keyout $PKIKeyDir/key3.pem -days 365 \
           -out $PKICertDir/cert3.pem -config $PKIDir/config.ini
}
function CreatePKS12s-FromFiles {
    openssl x509 -inkey $PKIKeyDir/key1.pem -in $PKICertDir/cert1.pem -export -out $PKIPKCSDir/cert1.pfx --password pass:
    openssl x509 -inkey $PKIKeyDir/key2.pem -in $PKICertDir/cert2.pem -export -out $PKIPKCSDir/cert2.pfx --password pass:
    openssl x509 -inkey $PKIKeyDir/key3.pem -in $PKICertDir/cert3.pem -export -out $PKIPKCSDir/cert3.pfx --password pass:
}

function Initialize-PKIRefDatabase {
    certutil -d sql:$PKIRefDir -A -n "$USER-DeveloperCert1" -t ",," -i $PKIPKCSDir/cert1.pfx --empty-password
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