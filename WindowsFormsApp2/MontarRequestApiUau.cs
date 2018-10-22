using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Rest;
//using System.Net.Http;
using RestSharp;

namespace WindowsFormsApp2
{
    public class MontarRequestApiUau
    {
        public RestRequest ObjetRequestApiUau(RestRequest restRequest, string tokenAuthentication)
        {
            restRequest.AddHeader("Postman-Token", "8a088b8c-c783-4000-b642-5df9d9bab218");
            restRequest.AddHeader("cache-control", "no-cache");
            if (tokenAuthentication != "")
                restRequest.AddHeader("Authorization", tokenAuthentication);
            restRequest.AddHeader("X-INTEGRATION-Authorization", "eyJhbGciOiJkaXIiLCJlbmMiOiJBMTI4Q0JDLUhTMjU2In0..RwTPih1ni9HPQlurXpa_bw.zJEhbYuIcF71UAeuhPRzmUzlXBan-p4-MOrjy55oZcf-5fY-5W5Jnb_Chouv-DP3KrzZK6q4UvPJWPspL08qePFR4IsS6_dtUJ7RSTUfbySPbIyfYRiKeSFdvrWhksD3gMl2fltgEu1s9ZVik6jLzzjqdmsI2N_jO6rVXSpvtYY.paEM8uxjsQoNmAgZ9UK4Fg");            
            restRequest.AddHeader("Content-Type", "application/json");

            return restRequest;
        }
    }
}
