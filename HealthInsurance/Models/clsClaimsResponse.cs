using System.Collections.Generic;

namespace HealthInsurance.Models
{
    public class clsClaimsResponse
    {
        public int MemberID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EnrollmentDate { get; set; }
        public List<clsClaim> claimsList { get; set; }

    }
    
}
