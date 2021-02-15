namespace Eliboo.Api.Contracts.Requests
{
    public class UserRegistrationRequest
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Confirm{ get; set; }

        public string CreateNewLibrary { get; set; }

        public bool IsNewLibraryCheckboxChecked
        { 
            get => !(CreateNewLibrary == null
                     || CreateNewLibrary == "false"
                     || CreateNewLibrary == "0");
        }

        public string LibraryCode { get; set; }
    }
}
