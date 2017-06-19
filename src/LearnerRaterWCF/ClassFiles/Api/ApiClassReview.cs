namespace LearnerRaterWCF.ClassFiles.Api
{
    public class ApiClassReview
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public static ApiClassReview Add(string Username, int Rating, string Comment)
        {
            return new ApiClassReview
            {
                Username = Username,
                Rating = Rating,
                Comment = Comment
            };
        }
    }
}