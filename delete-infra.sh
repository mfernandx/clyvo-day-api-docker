#!/bin/bash

RESOURCE_GROUP="rg-clyvo-devops"

echo "Deletando Resource Group..."
az group delete \
  --name $RESOURCE_GROUP \
  --yes \
  --no-wait

echo "Exclusão iniciada."