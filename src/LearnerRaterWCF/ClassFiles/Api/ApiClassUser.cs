namespace LearnerRaterWCF.ClassFiles.Api
{
    public class ApiClassUser
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }

        public static ApiClassUser Add(string Username, string Email, string FullName)
        {
            return new ApiClassUser
            {
                Username = Username,
                Email = Email,
                FullName = FullName
            };
        }
    }
}