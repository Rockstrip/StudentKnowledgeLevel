namespace InferenceLibrary
{
    /// <summary>
    /// Contains pairs of Term name and Membership function value. 
    /// </summary>
    public record struct FuzzyTuple
    (
        KeyValuePair<Severity, double> ApplicationGrade, 
        KeyValuePair<Severity, double> PresentationGrade, 
        KeyValuePair<Severity, double> ArrangementGrade
    );
}
