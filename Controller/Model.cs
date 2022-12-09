using static InferenceLibrary.Severity;

namespace InferenceLibrary
{
    public static class Model
    {
        /// <summary>
        /// Model Rule Processor.
        /// </summary>
        public static readonly ModelRuleProcessor RuleProcessor = new();

        /// <summary>
        /// Input Linguistic variables.
        /// </summary>
        public static readonly LinguisticVariable[] InputLVs = new[]
        {
            new LinguisticVariable
            {
                X = new XRange(0, 10, 0.01), //0-10, step 0.01
                Name = "Programming",
                Terms = new()
                {
                    [Unsatisfactory] = (double x) => MembershipFunctions.Sigmf(x, -11.9, 2.5),
                    [Satisfactory] = (double x) => MembershipFunctions.Gauss2mf(x, 0.506, 3.105, 0.506, 4.42),
                    [Good] = (double x) => MembershipFunctions.Gauss2mf(x, 0.48, 5.59, 0.48, 6.971),
                    [Excellent] = (double x) => MembershipFunctions.Sigmf(x, 10.5, 7.54),
                }
            },

            new LinguisticVariable
            {
                X = new XRange(0, 10, 0.01), //0-10, step 0.01
                Name = "Math",
                Terms = new()
                {
                    [Unsatisfactory] = (double x) => MembershipFunctions.Sigmf(x, -11.9, 2.5),
                    [Satisfactory] = (double x) => MembershipFunctions.Gauss2mf(x, 0.506, 3.105, 0.506, 4.42),
                    [Good] = (double x) => MembershipFunctions.Gauss2mf(x, 0.48, 5.59, 0.48, 6.971),
                    [Excellent] = (double x) => MembershipFunctions.Sigmf(x, 10.5, 7.54),
                }
            },

            new LinguisticVariable
            {
                X = new XRange(0, 10, 0.01), //0-10, step 0.01
                Name = "Computer Science",
                Terms = new()
                {
                    [Unsatisfactory] = (double x) => MembershipFunctions.Sigmf(x, -11.9, 2.5),
                    [Satisfactory] = (double x) => MembershipFunctions.Gauss2mf(x, 0.506, 3.105, 0.506, 4.42),
                    [Good] = (double x) => MembershipFunctions.Gauss2mf(x, 0.48, 5.59, 0.48, 6.971),
                    [Excellent] = (double x) => MembershipFunctions.Sigmf(x, 10.5, 7.54),
                }
            },
        };

        /// <summary>
        /// Output Linguistic variable.
        /// </summary>
        public static readonly LinguisticVariable OutputLV = new()
        {
            X = new XRange(0, 10, 0.01), //0-10, step 0.01
            Name = "ADIN",
            Terms = new()
            {
                [Unsatisfactory] = (double x) => MembershipFunctions.Sigmf(x, -11.9, 1.49),
                [Satisfactory] = (double x) => MembershipFunctions.Gauss2mf(x, 0.506, 2.1, 0.506, 4.011),
                [Good] = (double x) => MembershipFunctions.Gauss2mf(x, 0.48, 5.17, 0.48, 6.839),
                [Excellent] = (double x) => MembershipFunctions.Sigmf(x, 10.5, 7.377),
            }
        };
    }
}
