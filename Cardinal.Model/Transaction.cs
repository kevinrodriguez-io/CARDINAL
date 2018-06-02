using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Model {
    public class Transaction {

        // Table fields

        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal? Deposit { get; set; }
        public decimal? Withdrawal { get; set; }
        public DateTime TransactionDate { get; set; }

        // Properties

        public virtual Account Account { get; set; }

    }
}
