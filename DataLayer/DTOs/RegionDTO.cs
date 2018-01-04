using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    // Data Transfer Object
    public class RegionDTO
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }


        public override string ToString()
        {
            return $"{CustomerID} - {CompanyName}";
        }
        public RegionDTO(string customerId, string customerName)
        {
            CustomerID = customerId;
            CompanyName = customerName;
        }

        public RegionDTO()
        {

        }
    }
}
