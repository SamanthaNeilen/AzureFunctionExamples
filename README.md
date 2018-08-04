<h1>Azure Functions examples</h1>
<p>
Please see my blog posts on <a href="https://samanthaneilen.github.io/2018/06/08/pre-compiled-azure-functions-example.html" target="_blank">precompiled Azure Functions</a> and <a href="https://samanthaneilen.github.io/2018/07/14/csharp-script-azure-functions-example.html" target="_blank">C# script Azure Functions</a> for details on how to write and use Azure Functions.
</p>
<p>
These projects were created with a Visual Studio 2017 Community Edition with the Azure workload installed.
</p>
<h3>AzureFunction_CSharpScript Solution Folder</h3>
<h5>Summary</h5>
<p>
Contains a resource project (AzureFunctionsExample.ScriptResources) to access a database with Entity Framework 6 and a project (AzureFunctionsExample.ScriptV1) containing a C# script function.
</p>
<h5>Settings and configuration files</h5>
<p>
The local.settings.json assumes a local database called OrderDb in a SQLEPRESS named instance of SQL Server. The database can be created using the OrderDatabase project under the Database Solution Folder.
</p>
<p>
It also assumes that there is a instance of the Azure Storage Emulator running with the default access credentials and that a messages queue is present.
<h5>Running the project</h5>
<p>
To run the Azure Function use the Azure Function Core command line tools. For more information see the <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local" target="_blank">Microsoft Docs page</a> for running script Azure Functions.
</p>
<h3>AzureFunction_PreCompiled Solution Folder</h3>
<h5>Summary</h5>
<p>
Contains a resource project (AzureFunctionExample.ResourceAccess) with code to access a database using Entity Framework Core, a class to access blob storage to retrieve a email template file and a class to call the SendGrid email service to send an email.
</p>
<p>
Contains POCO/DTO library (AzureFunctionsExample.Shared) for shared simple object structure classes used in both the related Azure Functions projects.
</p>
<p>
Contains both an Azure Functions V1 (AzureFunctionsExample.V1) and V2 project (AzureFunctionsExample.V2) that contain a queue triggered Azure Function that use the resource and POCO/DTO libraries to send an email, using data from the database, when triggered by a queue message. 
</p>
<h5>Settings and configuration files</h5>
<p>
Both Azure Function projects have local settings files that assume a local database called OrderDb in a SQLEPRESS named instance of SQL Server. The database can be created using the OrderDatabase project under the Database Solution Folder.
</p>
<p>
Both Azure Function projects have local.settings.json files that assume that there is a instance of the Azure Storage Emulator running with the default access credentials and that a messages queue is present.
</p>
<p>
Both settings files also require a value for a sender emailaddress and an SendGrid API key that is not provided by default. Be sure to provide these settings with custom values to be able to run the Azure Functionss.
</p>
<h5>Running the project</h5>
<p>
Both Azure Function projects can be run by setting the project as startup project and starting the project with the Visual Studio IDE.
If you have trouble launching the local Azure Functions runtime, and you username contains a space, you may have to include a launchSettings.json as described in <a href="https://github.com/Azure/Azure-Functions/issues/623" target="_blank">this GitHub issue</a>.
</p>
<h3>Database Solution Folder</h3> 
<h5>Summary</h5>
<p>
Contains a database project with the database definition that is used to run the Azure Functions.
</p>
<h3>SendQueueMessageClient Solution Folder</h3> 
<h5>Summary</h5>
<p>
Contains a commandline executable project to post a queue message to a Azure Storage queue. Used to trigger the Azure Functions in my example projects.
</p>
<h5>Settings and configuration files</h5>
<p>
The appsettings file defines the connection to a local Azure Storage Emulator account with a messages queue.
</p>
<h5>Running the project</h5>
<p>
Set the project as startup project and run the project using the Visual Studio IDE.
</p>