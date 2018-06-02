using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Model {
    public class Card {

        // Table fields

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Identifier { get; set; }
        public int AccountId { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Relations

        public virtual Account Account { get; set; }

    }
}
