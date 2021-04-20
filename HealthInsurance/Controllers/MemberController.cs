using CsvHelper;
using HealthInsurance.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HealthInsurance.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        [Route("GetMemberClaims/claimDate/{claimDate}")]
        [HttpGet]
        public clsResponse GetMemberClaims(string claimDate)
        {
            clsResponse response = new clsResponse();
            try
            {
                DateTime dateTime = Convert.ToDateTime(claimDate);
                var memberPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Member.csv");
                var claimPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Claim.csv");
                //Here We are calling function to read CSV file  
                List<clsMember> memberData = ReadMemberCSVFile(memberPath);
                List<clsClaim> claimsData = ReadClaimCSVFile(claimPath);
                List<clsClaimsResponse> claimsResponses = new List<clsClaimsResponse>();
                if (memberData != null)
                {
                    foreach (var member in memberData)
                    {
                        clsClaimsResponse claims = new clsClaimsResponse();
                        claims.MemberID = member.MemberID;
                        claims.FirstName = member.FirstName;
                        claims.LastName = member.LastName;
                        claims.EnrollmentDate = member.EnrollmentDate.ToShortDateString();
                        if (claimsData != null)
                            claims.claimsList = claimsData.Where(x => x.MemberID == member.MemberID && x.ClaimDate <= dateTime).ToList();
                        claimsResponses.Add(claims);
                    }
                    response.status = "Success";
                    response.data = claimsResponses;
                }
                else
                {
                    response.status = "Failure";
                    response.data = "Data Format Error";
                }
            }
            catch (Exception ex)
            {
                response.status = "Exception";
                response.data = ex;
            }
            return response;
        }
        public List<clsMember> ReadMemberCSVFile(string location)
        {
            using (var reader = new StreamReader(location, Encoding.Default))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<MemberMap>();
                var records = csv.GetRecords<clsMember>().ToList();
                return records;
            }
        }
        public List<clsClaim> ReadClaimCSVFile(string location)
        {
            using (var reader = new StreamReader(location, Encoding.Default))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<ClaimMap>();
                var records = csv.GetRecords<clsClaim>().ToList();
                return records;
            }
        }
    }
}
