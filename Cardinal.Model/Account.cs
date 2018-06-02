using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Model {
    public class Account {

        // Table fields

        public int Id { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public DateTime CuttingDate { get; set; }
        public decimal CashPayment { get; set; }

        // Relations

        public virtual User User { get; set; }
        public virtual ICollection<AccountCutting> AccountCuttings { get; set; }
        public virtual ICollection<Transaction> AccountTransactions { get; set; }
    }
}
