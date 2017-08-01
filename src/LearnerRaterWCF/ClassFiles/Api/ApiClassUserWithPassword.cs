namespace LearnerRaterWCF.ClassFiles.Api
{
    public class ApiClassUserWithPassword : ApiClassUser
    {
        public string Password { get; set; }

        public static ApiClassUserWithPassword Add(string Username, string Password, string Email, string FullName)
        {
            return new ApiClassUserWithPassword
            {
                Username = Username,
                Password = Password,
                Email = Email,
                FullName = FullName
            };
        }
    }
}