using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public interface IApplication
    {
        ApplicationResponse Create(string policyholderId, string quotePackageId, int monthlyPremium, int serialNumber);
    }
}