using System;
using System.Collections.Generic;

namespace LearnerRaterWCF.ClassFiles.Api
{
    public class ApiClassResource
    {        
        private readonly List<ApiClassReview> m_ReviewList;

        public ApiClassResource()
        {
            m_ReviewList = new List<ApiClassReview>();
        }
        public long ID { get; set; }
        public string Catagory { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string URL { get; set; }

        public List<ApiClassReview> Reviews => (m_ReviewList);

        public void AddReview(string Username, int Rating, string Comment)
        {
            m_ReviewList.Add(ApiClassReview.Add(Username, Rating, Comment));
        }

        private int m_GetAverageRating()
        {
            var iTotal = 0;
            for (var i = 0; i < m_ReviewList.Count; i++)
            {
                iTotal += m_ReviewList[i].Rating;
            }
            return (int)(Math.Round((double)iTotal / m_ReviewList.Count, 0));
        }
        public int AverageRating
        {
            get { return m_GetAverageRating(); }
            set { }
        }
    }
}