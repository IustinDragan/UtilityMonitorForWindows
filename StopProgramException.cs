namespace UtilityMonitorForWindows
{
    public class StopProgramException : Exception
    {
        public StopProgramException() : base("The program has been stopped by the user.") { }
    }
}
