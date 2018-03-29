<h1>ROOT SDK</h1>

This SDK is used to develop applications that leverage the ROOT API.

> THIS LIBRARY IS NOT COMPLETE AND IS SUBJECT TO CHANGE.

<h4>Usage:</h4>

Startup.cs
```
 public void ConfigureServices(IServiceCollection services)
 {
     services.AddMvc();
     services.AddLogging();
     
     services.AddRoot(opts => Configuration.GetSection("RootOptions").Bind(opts));
 }
```

where RootOptions will be the appsettings node containing your api key.

appsettings.json
```
"RootOptions":  {
  "ApiKey": "<your_very_private_key>"
}
```

Standard dotnetcore rules apply. 
The key can also be set via environment variables, or user secrets

Then in your services via DI, inject either of the following:
```
// this exposes all the clients as a single higher level service
public MyRootService(IRootClient rootClient)
{
   _root = rootClient;
}

public MyInsuranceService(IRootInsuranceClient insuranceClient)
{
   _insuranceClient = insuranceClient;
}

public MyBankingService(IRootBankingClient bankingClient)
{
   _bankingClient = bankingClient;
}
```

> MORE DOCS TO COME...