using System.Collections.Generic;
using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public interface IPolicyService
    {
        PolicyResponse IssuePolicy(string applicationId);

        PolicyResponse AddPolicyBeneficiary(string policyId, object id, string firstName, string lastName,
            int percentage);

        IList<PolicyResponse> ListPolicies();

        PolicyResponse GetPolicy(string policyId);
        PolicyResponse CancelPolicy(string policyId, string reason);
        PolicyResponse ReplacePolicy(string policyId, string quotePackageId);
        PolicyResponse UpdatePolicyBillingAmount(string policyId, int billingAmount);

        IList<BeneficiaryResponse> ListPolicyBeneficiaries(string policyId);
    }
}