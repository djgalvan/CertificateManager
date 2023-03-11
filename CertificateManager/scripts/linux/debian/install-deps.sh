# Source: https://learn.microsoft.com/en-us/dotnet/core/install/linux-debian
function Install-Deps {
    sudo apt update -y && 
    sudo apt install -y wget openssl libnss3-tools sqlite3 &&
    wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb &&
    sudo apt install -y ./packages-microsoft-prod.deb &&
    rm packages-microsoft-prod.deb &&
    sudo apt update -y && 
    sudo apt install -y dotnet-sdk-7.0 dotnet-sdk-6.0
}
