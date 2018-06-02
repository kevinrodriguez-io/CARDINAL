using System;
using System.Collections.Generic;
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

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<UserDirectionHistory> UserDirectionHistories { get; set; }

    }
}
