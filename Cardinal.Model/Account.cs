using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Model {
    public class Account {

        // Table fields

        public int Id { get; set; }
        public string Type { get; set; }
        [Browsable(false)]
        public int UserId { get; set; }
        public DateTime CuttingDate { get; set; }
        public decimal CashPayment { get; set; }

        // Relations
        [Browsable(false)]
        public virtual User User { get; set; }
        [Browsable(false)]
        public virtual ICollection<AccountCutting> AccountCuttings { get; set; }
        [Browsable(false)]
        public virtual ICollection<Transaction> AccountTransactions { get; set; }
        [Browsable(false)]
        public virtual ICollection<Card> Cards { get; set; }
    }
}
