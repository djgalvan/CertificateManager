#!/bin/bash

sudo apt update -y && 
sudo apt install -y wget &&
wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb &&
sudo apt install -y ./packages-microsoft-prod.deb &&
rm packages-microsoft-prod.deb &&
sudo apt update -y && 
sudo apt install -y dotnet-sdk-7.0