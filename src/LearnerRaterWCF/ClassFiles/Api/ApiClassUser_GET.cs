namespace LearnerRaterWCF.ClassFiles.Api
{
    public class ApiClassUserGET
    {
        public long ID { get; set; }
        public string Username { get; set; }

        public static ApiClassUserGET Add(string Username)
        {
            return new ApiClassUserGET
            {
                Username = Username
            };
        }
    }
}