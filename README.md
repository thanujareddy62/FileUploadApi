# File Upload Web API using Azure Services

## Project Overview

This project is a Proof of Concept (POC) developed using **.NET Web API** and **Microsoft Azure services**.  
The application allows users to upload files through a REST API. Uploaded files are securely stored in Azure Blob Storage, while file metadata is saved in Azure Table Storage. All sensitive configuration values are managed using Azure Key Vault, and application monitoring is enabled using Azure Application Insights.

The goal of this POC is to gain hands-on experience with Azure cloud services, secure configuration management, and deploying a real-world .NET Web API application to Azure.

---

## Features

- Upload files using a REST API endpoint
- Store uploaded files in Azure Blob Storage
- Save file metadata (name, size, upload time) in Azure Table Storage
- Securely manage secrets using Azure Key Vault
- Use Managed Identity for authentication (no secrets in code)
- Enable logging and monitoring with Azure Application Insights
- Deploy the application to Azure App Service

---

## Technology Stack

- C#
- .NET 6 Web API
- Azure App Service
- Azure Blob Storage
- Azure Table Storage
- Azure Key Vault
- Azure Application Insights
- Postman (for testing)

---

## Azure Services Used

Azure Service - Purpose 

Azure App Service - Hosts the .NET Web API 
Azure Blob Storage - Stores uploaded files 
Azure Table Storage - Stores file metadata
Azure Key Vault - Stores connection strings securely 
Azure Application Insights - Logging and monitoring

---

## Application Architecture

Client (Postman / Browser)  
→ .NET Web API (Azure App Service)  
→ Azure Blob Storage (file content)  
→ Azure Table Storage (file metadata)  
→ Azure Key Vault (secure secrets)  
→ Azure Application Insights (logs & monitoring)

Architecture :  https://fried-viola-73649473.figma.site/

## Setup Steps

1. Clone the repository
2. Create Azure resources:
   - App Service
   - Storage Account
   - Blob container (uploads)
   - Table (FileMetadata)
   - Azure Key Vault
   - Application Insights
3. Add storage connection strings to Azure Key Vault
4. Enable Managed Identity for App Service
5. Assign Key Vault Secrets User role
6. Publish the Web API to Azure App Service
7. Test API using Postman




