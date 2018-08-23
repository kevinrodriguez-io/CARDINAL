using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Model {
    public class AccountCutting {
        
        // Table fields

        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal TotalDeposit { get; set; }
        public decimal TotalWithdrawal { get; set; }
        public int IntrestRate { get; set; }
        public decimal CashPayment { get; set; }
        public decimal RealPayment { get; set; }
        public decimal MinimumPayment { get; set; }
        public decimal LastMinimumCashPayment { get; set; }
        public decimal MoratoryIntrest { get; set; }
        public decimal WithdrawalCommission { get; set; }
        public decimal AdministrativeCommission { get; set; }
        public decimal CashPaymentCredit { get; set; }
        public decimal AutomaticCharges { get; set; }
        public decimal BalanceCutting { get; set; }

        // Relations
        public virtual Account Account { get; set; }

    }
}
