using System.Collections.Generic;

namespace RootSDK.Insurance.Models
{
    public class ClaimResponse
    {
        public string CreatedAt { get; set; }
        public string PolicyId { get; set; }
        public string ClaimId { get; set; }
        public string ClaimStatus { get; set; }
        public string ApprovalStatus { get; set; }
        public Dictionary<string, string> AppData { get; set; }
        public int RequestedAmount { get; set; }
    }
}