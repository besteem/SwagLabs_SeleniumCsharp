namespace SwagLabs.PageObjects
{
    public class Variables
    {
        //List of variables for SauceDemo website
        public string validPassword = "secret_sauce";
        public string validUsername = "standard_user";
        public string lockedOutUser = "locked_out_user";
        public string invalidCredential = "invalid_credential";
        public string passwordRequiredErrorMessage = "Epic sadface: Password is required";
        public string usernameRequiredErrorMessage = "Epic sadface: Username is required";
        public string lockedOutUserErrorMessage = "Epic sadface: Sorry, this user has been locked out.";
        public string invalidCredentialErrorMessage = "Epic sadface: Username and password do not match any user in this service";
    }
}