namespace NativeTunes.Shared.Errors.Authentication
{
    public class EmailAlreadyInUseError : AuthenticationError
    {
        public EmailAlreadyInUseError(string errorMessage = "Email is already in use.") : base("Authentication.EmailIsAlreadyInUse", errorMessage: errorMessage) { }
    }
}
