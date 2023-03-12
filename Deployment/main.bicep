@description('Location for all resources.')
param location string = resourceGroup().location

@description('Represents a purchasable Stock Keeping Unit (SKU) under a product.')
@allowed([
  'Standard_LRS'
  'Standard_GRS'
  'Standard_RAGRS'
])
param storageAccountType string = 'Standard_LRS'

@description('Determines the kind of the storage')
@allowed([
  'Storage'
  'StorageV2'
])
param storageAccountKind string = 'StorageV2'

@description('The name of the Azure Function app.')
param functionAppName string = 'func-${uniqueString(resourceGroup().id)}'

@description('Specifies the language worker runtime to load in the function app.')
@allowed([
  'dotnet'
  'node'
  'python'
  'java'
  'dotnet-isolated'
])
param functionWorkerRuntime string = 'dotnet-isolated'

@description('Specifies the OS used for the Azure Function hosting plan.')
@allowed([ 
  'Windows'
  'Linux'
])
param functionPlanOS string = 'Windows'

@description('''
Storage account name restrictions:
- Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.
- Your storage account name must be unique within Azure. No two storage accounts can have the same name.
''')
@minLength(3)
@maxLength(24)
param storageAccountName string = 'salindis${substring(uniqueString(resourceGroup().id),0,10)}'

module storageAccountDeploy 'storageAccount.bicep' = {
  name: 'storageAccountDeploy'
  params: {
    location: location
    storageAccountName: storageAccountName
    storageAccountType: storageAccountType
    storageAccountKind: storageAccountKind
  }
}
