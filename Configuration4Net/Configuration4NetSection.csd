<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="e0b1dc5d-6b4c-49bc-a484-38825d1f4afa" namespace="Configuration4Net" xmlSchemaNamespace="urn:Configuration4Net" assemblyName="Configuration4Net" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="AgentConfiguration4NetSection" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="agentConfiguration4NetSection">
      <elementProperties>
        <elementProperty name="ConfigManagers" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="managers" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/ManagerSectionCollections" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="Property">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Value" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="PropertyCollections" collectionType="AddRemoveClearMapAlternate" xmlItemName="property" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/Property" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="ManagerSection">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="LoaderType" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="loaderType" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="AppName" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="appName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Properties" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="properties" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/PropertyCollections" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="ManagerSectionCollections" collectionType="AddRemoveClearMapAlternate" xmlItemName="managerSection" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/e0b1dc5d-6b4c-49bc-a484-38825d1f4afa/ManagerSection" />
      </itemType>
    </configurationElementCollection>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>