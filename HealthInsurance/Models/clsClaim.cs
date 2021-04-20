using System;

namespace HealthInsurance.Models
{
    public class clsClaim
    {
        public int MemberID { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime ClaimDate { get; set; }
    }
}
