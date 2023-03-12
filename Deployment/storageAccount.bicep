param location string
param storageAccountName string
param storageAccountType string
param storageAccountKind string

@description('The storage account for the function app')
resource storageAccount 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: storageAccountName
  location: location
  kind: 'StorageV2'
  sku: {
    name: storageAccountType
  }
  properties: {
    supportsHttpsTrafficOnly: true
  }
}

output blobUri string = storageAccount.properties.primaryEndpoints.blob
