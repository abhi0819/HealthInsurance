using CsvHelper.Configuration;

namespace HealthInsurance.Models
{
    public class Mappings
    {
    }
    public sealed class MemberMap : ClassMap<clsMember>
    {
        public MemberMap()
        {
            Map(x => x.MemberID).Name("MemberID");
            Map(x => x.FirstName).Name("FirstName");
            Map(x => x.LastName).Name("LastName");
            Map(x => x.EnrollmentDate).Name("EnrollmentDate");
        }
    }
    public sealed class ClaimMap : ClassMap<clsClaim>
    {
        public ClaimMap()
        {
            Map(x => x.MemberID).Name("MemberID");
            Map(x => x.ClaimAmount).Name("ClaimAmount");
            Map(x => x.ClaimDate).Name("ClaimDate");
        }
    }
}
