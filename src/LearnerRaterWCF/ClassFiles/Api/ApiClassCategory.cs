using System.Collections.Generic;

namespace LearnerRaterWCF.ClassFiles.Api
{
    public class ApiClassCategory
    {
        public string Category { get; set; }
        public int NumberOfResources { get; set; }

        public static ApiClassCategory Add(string Category)
        {
            return new ApiClassCategory
            {
                Category = Category
            };
        }
    }
}