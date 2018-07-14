#load "QueueMessage.csx"
#r "references/EntityFramework.dll"
#r "references/AzureFunctionsExample.ScriptResources.dll"
#r "netstandard"

using AzureFunctionsExample.ScriptResources.DataAccess;
using System.Data.Entity;
using System;
using System.Linq;

public static void Run(QueueMessage myQueueItem, TraceWriter log)
{
    var dbContext = new OrderDbContext(Environment.GetEnvironmentVariable("OrderDbConnection"));
    var order = dbContext.Order.Include(o => o.Person).FirstOrDefault(o => o.Id == myQueueItem.Order && o.PersonID == myQueueItem.Person);

    log.Info($"{order.Person.FirstName} {order.Person.LastName}");
    log.Info($"C# Queue trigger function processed: {myQueueItem}");
}
