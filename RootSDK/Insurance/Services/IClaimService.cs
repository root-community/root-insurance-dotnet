using System.Collections.Generic;
using System.Threading.Tasks;
using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public interface IClaimService
    {
        Task<IList<ClaimResponse>> ListClaims(string claimStatus = null, string approvalStatus = null);
        Task<ClaimResponse> GetClaim(string claimId);
        Task<ClaimResponse> OpenClaim(string policyId = null, string policyHolderId = null);
        Task<ClaimResponse> LinkPolicyToClaim(string claimId, string policyId);
        Task<ClaimResponse> LinkPolicyHolderToClaim(string claimId, string policyHolderId);
    }
}