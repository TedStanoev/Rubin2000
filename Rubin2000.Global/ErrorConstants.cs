namespace Rubin2000.Global
{
    public class ErrorConstants
    {
        public const string InvalidProcedure = "Procedure does not exist";

        public const string InvalidName = "The name must be between 2 and 20 characters long";

        public const string InvalidDate = "Please enter a valid date. Example: 2020-02-18";

        public const string InvalidDatePassed = "Please enter a future date";

        public const string InvalidTime = "Time must be between 10:00 and 19:00";

        public const string InvalidTimePassed = "Please enter an hour that hasn't passed";

        public const string InvalidEmployee = "The employee is unavailable or is unable to perform the given service";

        public const string OperationError = "There was an error approving the appointment. Please contact the creator of this web application.";
    }
}
