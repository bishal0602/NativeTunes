namespace NativeTunes.Shared.Errors.Authentication
{
    public class InvalidCredentialsError : AuthenticationError
    {
        public InvalidCredentialsError(string errorMessage) : base("Authentication.InvalidCredentials", errorMessage: errorMessage) { }
    }
}
