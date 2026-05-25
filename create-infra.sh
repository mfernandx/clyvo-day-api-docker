#!/bin/bash

RESOURCE_GROUP="rg-clyvo-devops"
LOCATION="eastus"
VM_NAME="vm-clyvo-api"
ADMIN_USER="azureuser"
VM_SIZE="Standard_B2s"
IMAGE="Ubuntu2204"

echo "1. Criando Resource Group..."
az group create \
  --name $RESOURCE_GROUP \
  --location $LOCATION

echo "2. Criando VM Linux..."
az vm create \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --image $IMAGE \
  --size $VM_SIZE \
  --admin-username $ADMIN_USER \
  --generate-ssh-keys \
  --public-ip-sku Standard

echo "3. Abrindo porta 22..."
az vm open-port \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --port 22

echo "4. Abrindo porta 8080..."
az vm open-port \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --port 8080

echo "5. Abrindo porta 1521..."
az vm open-port \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --port 1521

echo "6. Instalando Docker, Docker Compose, Git e Nano..."
az vm run-command invoke \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --command-id RunShellScript \
  --scripts "
    sudo apt-get update -y
    sudo apt-get install -y ca-certificates curl gnupg git nano unzip

    sudo install -m 0755 -d /etc/apt/keyrings

    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | \
    sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg

    sudo chmod a+r /etc/apt/keyrings/docker.gpg

    echo \"deb [arch=\$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \$(. /etc/os-release && echo \$VERSION_CODENAME) stable\" | \
    sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

    sudo apt-get update -y
    sudo apt-get install -y docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin

    sudo systemctl enable docker
    sudo systemctl start docker
    sudo usermod -aG docker $ADMIN_USER
  "

PUBLIC_IP=$(az vm show \
  --resource-group $RESOURCE_GROUP \
  --name $VM_NAME \
  --show-details \
  --query publicIps \
  --output tsv)

echo "======================================"
echo "Infra criada com sucesso!"
echo "IP público: $PUBLIC_IP"
echo "Acesse com:"
echo "ssh $ADMIN_USER@$PUBLIC_IP"
echo "======================================"