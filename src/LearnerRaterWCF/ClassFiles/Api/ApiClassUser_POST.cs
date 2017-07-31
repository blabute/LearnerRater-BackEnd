namespace LearnerRaterWCF.ClassFiles.Api
{
    public class ApiClassUserPOST
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public static ApiClassUserPOST Add(string Username, byte[] Password, string PasswordSalt, string Email, string FullName)
        {
            return new ApiClassUserPOST
            {
                Username = Username,
                Password = Password,
                PasswordSalt = PasswordSalt,
                Email = Email,
                FullName = FullName
            };
        }
    }
}