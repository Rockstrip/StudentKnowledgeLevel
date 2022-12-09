using static InferenceLibrary.Severity;

namespace InferenceLibrary
{
    public class ModelRuleProcessor
    {        
        public Severity ActivateRule(FuzzyTuple fuzzyTuple) =>
            (fuzzyTuple.ApplicationGrade.Key, fuzzyTuple.PresentationGrade.Key, fuzzyTuple.ArrangementGrade.Key) switch
            {
                //If ML is %% and CS is %% and CS2 is %% then ADIN is %%
                (Unsatisfactory, Unsatisfactory, Unsatisfactory) => Unsatisfactory,         //1
                (Unsatisfactory, Unsatisfactory, Satisfactory) => Unsatisfactory,           //2
                (Unsatisfactory, Unsatisfactory, Good) => Unsatisfactory,       //3
                (Unsatisfactory, Unsatisfactory, Excellent) => Unsatisfactory,         //4
                (Unsatisfactory, Satisfactory, Unsatisfactory) => Unsatisfactory,           //5
                (Unsatisfactory, Good, Unsatisfactory) => Unsatisfactory,       //6
                (Unsatisfactory, Excellent, Unsatisfactory) => Unsatisfactory,         //7
                (Unsatisfactory, Satisfactory, Satisfactory) => Unsatisfactory,             //8
                (Unsatisfactory, Satisfactory, Good) => Unsatisfactory,         //9
                (Unsatisfactory, Satisfactory, Excellent) => Unsatisfactory,           //10
                (Unsatisfactory, Good, Satisfactory) => Unsatisfactory,         //11
                (Unsatisfactory, Excellent, Satisfactory) => Unsatisfactory,           //12
                (Unsatisfactory, Good, Good) => Unsatisfactory,     //13
                (Unsatisfactory, Good, Excellent) => Satisfactory,         //14
                (Unsatisfactory, Excellent, Good) => Satisfactory,         //15
                (Unsatisfactory, Excellent, Excellent) => Satisfactory,           //16
                (Satisfactory, Unsatisfactory, Unsatisfactory) => Unsatisfactory,           //17
                (Satisfactory, Unsatisfactory, Satisfactory) => Unsatisfactory,             //18
                (Satisfactory, Unsatisfactory, Good) => Satisfactory,           //19
                (Satisfactory, Unsatisfactory, Excellent) => Satisfactory,             //20
                (Satisfactory, Satisfactory, Unsatisfactory) => Unsatisfactory,             //21
                (Satisfactory, Good, Unsatisfactory) => Satisfactory,           //22
                (Satisfactory, Excellent, Unsatisfactory) => Satisfactory,             //23
                (Satisfactory, Satisfactory, Satisfactory) => Satisfactory,                 //24
                (Satisfactory, Satisfactory, Good) => Satisfactory,             //25
                (Satisfactory, Satisfactory, Excellent) => Good,           //26
                (Satisfactory, Good, Satisfactory) => Satisfactory,             //27
                (Satisfactory, Excellent, Satisfactory) => Good,           //28
                (Satisfactory, Good, Good) => Good,     //29
                (Satisfactory, Good, Excellent) => Good,       //30
                (Satisfactory, Excellent, Good) => Good,       //31
                (Satisfactory, Excellent, Excellent) => Good,         //32
                (Good, Unsatisfactory, Unsatisfactory) => Satisfactory,         //33
                (Good, Unsatisfactory, Satisfactory) => Satisfactory,           //34
                (Good, Unsatisfactory, Good) => Good,   //35
                (Good, Unsatisfactory, Excellent) => Good,     //36
                (Good, Satisfactory, Unsatisfactory) => Satisfactory,           //37
                (Good, Good, Unsatisfactory) => Satisfactory,       //38
                (Good, Excellent, Unsatisfactory) => Good,     //39
                (Good, Satisfactory, Satisfactory) => Satisfactory,             //40
                (Good, Satisfactory, Good) => Good,     //41
                (Good, Satisfactory, Excellent) => Excellent,         //42
                (Good, Good, Satisfactory) => Good,     //43
                (Good, Excellent, Satisfactory) => Excellent,         //44
                (Good, Good, Good) => Good, //45
                (Good, Good, Excellent) => Excellent,     //46
                (Good, Excellent, Good) => Excellent,     //47
                (Good, Excellent, Excellent) => Excellent,       //48
                (Excellent, Unsatisfactory, Unsatisfactory) => Good,       //49
                (Excellent, Unsatisfactory, Satisfactory) => Good,         //50
                (Excellent, Unsatisfactory, Good) => Excellent,       //51
                (Excellent, Unsatisfactory, Excellent) => Excellent,         //52
                (Excellent, Satisfactory, Unsatisfactory) => Good,         //53
                (Excellent, Good, Unsatisfactory) => Excellent,       //54
                (Excellent, Excellent, Unsatisfactory) => Excellent,         //55
                (Excellent, Satisfactory, Satisfactory) => Good,           //56
                (Excellent, Satisfactory, Good) => Excellent,         //57
                (Excellent, Satisfactory, Excellent) => Excellent,           //58
                (Excellent, Good, Satisfactory) => Excellent,         //59
                (Excellent, Excellent, Satisfactory) => Excellent,           //60
                (Excellent, Good, Good) => Excellent,     //61
                (Excellent, Good, Excellent) => Excellent,       //62
                (Excellent, Excellent, Good) => Excellent,       //63
                (Excellent, Excellent, Excellent) => Excellent,         //64
            };
    }
}
