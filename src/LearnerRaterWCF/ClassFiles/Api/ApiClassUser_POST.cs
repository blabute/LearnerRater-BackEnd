namespace LearnerRaterWCF.ClassFiles.Api
{
    public class ApiClassUserPOST
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static ApiClassUserPOST Add(string Username, string Password)
        {
            return new ApiClassUserPOST
            {
                Username = Username,
                Password = Password
            };
        }
    }
}