namespace VeritechChallenge.src.model
{
    /// <summary>
    /// Enum to define the three possible pay frequencies: 'W' for weekly, 'F' for fortnightly, 'M' for monthly
    /// </summary>
    public enum PayFreq
    {
        // NOTE this could benefit from some more user friendly enum names as below:
        //      Weekly = 'W', Fortnightly = 'F', Monthly = 'M'
        //      this would unfortunately require a bit of fiddling so i've prioritised other tasks for the time being
        W = 'W', F = 'F', M = 'M'
    }
}