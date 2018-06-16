using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Model {
    public class User {

        // Table fields

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Direction { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Relations
        [Browsable(false)]
        public virtual ICollection<Account> Accounts { get; set; }
        [Browsable(false)]
        public virtual ICollection<UserDirectionHistory> UserDirectionHistories { get; set; }

    }
}
