using Microsoft.ML.Runtime.Api;

namespace Cardinal.Model.AI {
    public class AccountPrediction {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;
    }
}
