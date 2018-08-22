using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinal.Model {
    public class UserDirectionHistory {

        // Table fields

        public int Id { get; set; }
        public int UserId { get; set; }
        public string LastDirection { get; set; }
        public string NewDirection { get; set; }
        public DateTime ChangedDate { get; set; }
        // Relations

        public virtual User User { get; set; }

    }
}
