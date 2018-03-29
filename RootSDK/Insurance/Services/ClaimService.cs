using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using RootSDK.Core;
using RootSDK.Insurance.Models;

namespace RootSDK.Insurance.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IRootApiClient _root;

        public ClaimService(IRootApiClient root)
        {
            _root = root;
            _root.SetApiArea(RootApiAreas.Insurance);
        }

        public async Task<IList<ClaimResponse>> ListClaims(string claimStatus = "all", string approvalStatus = "all")
        {
            var request = $"claims?claim_status={claimStatus}&approval_status={approvalStatus}";
            return await _root.GetAsync<IList<ClaimResponse>>(request);
        }

        public async Task<ClaimResponse> GetClaim(string claimId)
        {
            return await _root.GetAsync<ClaimResponse>($"claims/{claimId}");
        }

        public async Task<ClaimResponse> OpenClaim(string policyId = null, string policyHolderId = null)
        {
//            "policy_id": "8349345c-a6c5-4bf9-8ebb-6bbfc1628715",
//            "incident_type": "Theft",
//            "incident_cause": "Device stolen during burglary",
//            "incident_date": "2017-10-16T10:12:02.872Z",
//            "app_data": {
//                "key1": "value 1"
//                "key2": "value 2"
//            },
//            "requested_amount": 13000000
            dynamic data = new ExpandoObject();
            if (policyId != null)
                data.policy_id = policyId;
            data.policyholder_id = policyHolderId;

            return await _root.PostAsync<ClaimResponse>($"claims", data);
        }

        public async Task<ClaimResponse> LinkPolicyToClaim(string claimId, string policyId)
        {
            dynamic data = new ExpandoObject();
            data.policy_id = policyId;
            return await _root.PostAsync<ClaimResponse>($"claims/{claimId}", data);
        }

        public async Task<ClaimResponse> LinkPolicyHolderToClaim(string claimId, string policyHolderId)
        {
            throw new System.NotImplementedException();
        }
    }
}