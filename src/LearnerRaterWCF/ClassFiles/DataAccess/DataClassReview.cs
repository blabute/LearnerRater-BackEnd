using System.Collections.Generic;
using LearnerRaterWCF.ClassFiles.Api;
using LearnerRaterWCF.TableAdapters.MainDALTableAdapters;

namespace LearnerRaterWCF.ClassFiles.DataAccess
{
    public class DataClassReview
    {
        private GetReviewsTableAdapter m_ReviewsTblAdapter;

        public GetReviewsTableAdapter ReviewsTblAdapter
        {
            get
            {
                if (m_ReviewsTblAdapter == null)
                    m_ReviewsTblAdapter = new GetReviewsTableAdapter();
                return (m_ReviewsTblAdapter);
            }
        }

        public void LoadReviewList(long resourceId, List<ApiClassReview> reviewList)
        {
            reviewList.Clear();
            var dt = ReviewsTblAdapter.GetData(resourceId);
            for (var i = 0; i < dt.Count; i++)
            {
                var review = new ApiClassReview();
                review.ID = dt[i].Review_ID;
                if (!dt[i].IsUsernameNull())
                    review.Username = dt[i].Username;
                if (!dt[i].IsRatingNull())
                    review.Rating = dt[i].Rating;
                if (!dt[i].IsCommentsNull())
                    review.Comment = dt[i].Comments;
                //

                reviewList.Add(review);
            }
        }

        public bool SaveReviewList(long resourceId, List<ApiClassReview> reviews)
        {
            var bResult = true;
            
            var i = 0;
            while (bResult && i< reviews.Count)
            {
                long? reviewId = SaveReview(resourceId, reviews[i]);
                bResult = (reviewId != null);
                i++;
            }

            return (bResult);
        }

        public long? SaveReview(long resourceId, ApiClassReview review)
        {
            long? reviewId = null;
            ReviewsTblAdapter.SaveReview(resourceId, ref reviewId, review.Username, review.Rating, review.Comment);
            return reviewId;
        }

        public bool UpdateReview(long resourceId, long? reviewId, ApiClassReview review)
        {
            ReviewsTblAdapter.SaveReview(resourceId, ref reviewId, review.Username, review.Rating, review.Comment);
            return (reviewId != null);
        }

        public bool DeleteReview(long resourceId, long reviewId)
        {
            try
            {
                ReviewsTblAdapter.DeleteReview(resourceId, reviewId);
                return(true);
            }
            catch
            {
                return (false);
            }
        }

        public bool DeleteResourceReviews(long resourceId)
        {
            try
            {
                ReviewsTblAdapter.DeleteResourceReviews(resourceId);
                return (true);
            }
            catch
            {
                return (false);
            }
        }
    }
}