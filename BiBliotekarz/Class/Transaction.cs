using System;

namespace BiBliotekarz.Class
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int ClientID { get; set; }
        public long BookID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
