namespace NativeTunes.Shared.Errors.Authentication
{
    public class UserNameAlreadyTakenError : AuthenticationError
    {
        public UserNameAlreadyTakenError(string errorMessage = "Username is already taken.") : base("Authentication.UserNameAlreadyTaken", errorMessage: errorMessage) { }
    }
}
