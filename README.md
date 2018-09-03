# A .NET Core 2 client for Active Campaign V2 API

Nuget package can be found here : https://www.nuget.org/packages/unitee.activecampaignapiclient
## Configuration

Add Active Campaign API Key and host in the root of your appsettings.json :

<pre>
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  <b>"ActiveCampaign": {
    "BaseUri": "https://myspace.api-us1.com",
    "ApiKey": "a5ze5rty123qs3df3gh"
  }</b>
}
</pre>

Add ActiveCampaignClient service in your Startup.cs file :
<pre>
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    <b>services.AddActiveCampaignApiClient(Configuration); </b>
}
</pre>
        
## Usage
Inject ActiveCampaignClient service in your class (controller, ...) : 
<pre>
private readonly IActiveCampaignClient _activeCampaignClient;

public ValuesController(IActiveCampaignClient activeCampaignClient)
{
    _activeCampaignClient = activeCampaignClient;
}
</pre>

Use Call method to retreive data. First param is the Active Campaign RPC action, second param is the query parameters :
<pre>
// GET api/values
[HttpGet]
public async Task<ActionResult<ActiveCampaignClientResult>> Get()
{
    var activeCampaignClientResult = await _activeCampaignClient.Call(
            "contact_list", 
            new Dictionary<string, string> {{"ids", "all"}}
     );
    
    return activeCampaignClientResult;
}
</pre>
