using System.Collections.Generic;
using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public interface IPolicyHolder
    {
        PolicyHolderResponse CreatePolicyHolder(object id, string firstName = null,
            string lastName = null, string email = null,
            string dateOfBirth = null, string cellphone = null);

        IList<PolicyHolderResponse> ListPolicyHolders();

        PolicyHolderResponse GetPolicyHolder(string policyHolderId);
        PolicyHolderResponse UpdatePolicyHolder(string policyHolderId, string email, string cellphone);
        IList<PolicyHolderEvents> ListPolicyHolderEvents(string policyHolderId);
    }
}