using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public double BasicPay { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public string DepDummy { get; set; }
        public string Country { get; set; } 
        public string Department { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
        public string Address { get; set; }

    }
}
