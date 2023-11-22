using Conductor.Client;
using Conductor.Client.Extensions;
using Conductor.Client.Worker;
using Microsoft.Extensions.Logging;
using System;

var basePath = Environment.GetEnvironmentVariable("ORKES_BASE_PATH");
var keyId = Environment.GetEnvironmentVariable("ORKES_KEY_ID");
var keySecret = Environment.GetEnvironmentVariable("ORKES_KEY_SECRET");

var host = WorkflowTaskHost.CreateWorkerHost(
    new Configuration
    {
        AuthenticationSettings = new Conductor.Client.Authentication.OrkesAuthenticationSettings(keyId, keySecret),
        BasePath = basePath
    },
    LogLevel.Trace,
    new SimpleWorker());
await host.StartAsync();
Thread.Sleep(TimeSpan.FromSeconds(100));