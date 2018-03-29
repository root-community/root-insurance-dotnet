namespace RootSDK
{
    public class RootOptions
    {
        // for dev on this lib, add update this target in your appsettings to point to the sandbox url
        // https://sandbox.root.co.za/v1/
        public string ApiKey { get; set; } = "https://api.root.co.za/v1/";
        public string ApiUrl { get; set; }
    }
}