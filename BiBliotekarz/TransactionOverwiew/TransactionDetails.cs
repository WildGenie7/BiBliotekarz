using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiBliotekarz.TransactionOverwiew
{
    public class TransactionDetails
    {
        public int TransactionID { get; set; }
        public string ClientName { get; set; }
        public string BookTitle { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

}
