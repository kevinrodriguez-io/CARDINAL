using Microsoft.ML.Runtime.Api;

namespace Cardinal.Service.AI.Model {
    public class AccountData {
        [Column("0")]
        public float Amount { get; set; }
        [Column("1")]
        public string Label { get; set; }
    }
}
