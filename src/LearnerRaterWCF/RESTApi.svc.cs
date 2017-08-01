using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;
using LearnerRaterWCF.ClassFiles.Api;
using System.Web;
using LearnerRaterWCF.ClassFiles.DataAccess;
using LearnerRaterWCF.Models;

namespace LearnerRaterWCF
{    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestApi" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestApi.svc or RestApi.svc.cs at the Solution Explorer and start debugging.
    public class RestApi : IRESTApi
    {
        private void SetResponseStatus(HttpStatusCode status, string message)
        {
            if (WebOperationContext.Current != null)
            {
                OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
                response.StatusCode = status;
                response.StatusDescription = message;
            }
            HttpContext.Current.Response.Write(message);
        }

        public List<ApiClassCategory> GetCategories()
        {
            var result = new List<ApiClassCategory>();

            try
            {
                // Hard coded list - adjust if necessary
                result.Add(ApiClassCategory.Add("React"));
                result.Add(ApiClassCategory.Add("Redux"));
                result.Add(ApiClassCategory.Add("JavaScript"));
                result.Add(ApiClassCategory.Add("ES6"));
                result.Add(ApiClassCategory.Add("Fluent Assertions"));
                result.Add(ApiClassCategory.Add("NCrunch"));
                result.Add(ApiClassCategory.Add("Specflow"));
                result.Add(ApiClassCategory.Add("BDD"));
                result.Add(ApiClassCategory.Add("CSS"));
                result.Add(ApiClassCategory.Add("SASS"));
                result.Add(ApiClassCategory.Add("HTML"));
                result.Add(ApiClassCategory.Add("SVG"));
                result.Add(ApiClassCategory.Add("Git"));
                result.Add(ApiClassCategory.Add("Kanban"));
                result.Add(ApiClassCategory.Add("Other"));

                var dataResource = new DataClassResource();
                dataResource.SetCategoryResourceCounts(result);
            }
            catch (Exception ex)
            {
                SetResponseStatus(HttpStatusCode.InternalServerError, ex.Message);
                result = null;
            }

            return (result);
        }       

        public List<ApiClassResource> GetResources(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                SetResponseStatus(HttpStatusCode.NotFound, "Invalid query parameter category");
                return null;
            }

            var result = new List<ApiClassResource>();
            try
            {
                var dataResource = new DataClassResource();
                dataResource.LoadResourceList(category, result);
            }
            catch (Exception ex)
            {
                SetResponseStatus(HttpStatusCode.NotFound, ex.Message);
                result = null;
            }

            return (result);
        }

        public long? AddResource(string category, ApiClassResource resource)
        {            
            if (string.IsNullOrWhiteSpace(category))
            {
                SetResponseStatus(HttpStatusCode.NotFound, "Invalid query parameter category");
                return null;
            }

            long? result;
            try
            {
                resource.Category = category;
                var dataResource = new DataClassResource();
                result = dataResource.SaveResource(category, resource);
                if (result == null)
                {
                    SetResponseStatus(HttpStatusCode.InternalServerError, "Unable to save resource");
                }
            }
            catch (Exception ex)
            {
                SetResponseStatus(HttpStatusCode.NotFound, ex.Message);
                result = null;
            }

            return (result);
        }

        public bool UpdateResource(long resourceId, ApiClassResource resource)
        {
            bool result = false;
            try
            {
                resource.ID = resourceId;
                var dataResource = new DataClassResource();
                result = dataResource.UpdateResource(resourceId, resource);
            }
            catch (Exception ex)
            {
                SetResponseStatus(HttpStatusCode.InternalServerError, ex.Message);
                return (false);
            }

            if (!result)
            {
                SetResponseStatus(HttpStatusCode.InternalServerError, "Unable to update resource");
            }
            return (result);            
        }

        public bool DeleteResource(long resourceId)
        {
            var dataResource = new DataClassResource();
            var bResult = dataResource.DeleteResource(resourceId);
            if (!bResult)
            {
                SetResponseStatus(HttpStatusCode.InternalServerError, "Unable to delete resource");
            }
            return (bResult);
        }

        public List<ApiClassReview> GetReviews(long resourceId)
        {
            var reviews = new List<ApiClassReview>();

            try
            {
                var dataReview = new DataClassReview();
                dataReview.LoadReviewList(resourceId, reviews);
            }
            catch
            {
                reviews.Clear();
            }

            return (reviews);
        }

        public long? AddReview(long resourceId, ApiClassReview review)
        {
            var dataReview = new DataClassReview();
            var lResult = dataReview.SaveReview(resourceId, review);
            if (lResult == null)
            {
                SetResponseStatus(HttpStatusCode.InternalServerError, "Unable to add review");
            }
            return (lResult);
        }

        public bool UpdateReview(long resourceId, long reviewId, ApiClassReview review)
        {
            review.ID = review.ID;
            var dataReview = new DataClassReview();
            var bResult = dataReview.UpdateReview(resourceId, reviewId, review);
            if (!bResult)
            {
                SetResponseStatus(HttpStatusCode.InternalServerError, "Unable to update review");
            }
            return (bResult);
        }

        public bool DeleteReview(long resourceId, long reviewId)
        {
            var dataReview = new DataClassReview();
            var bResult = dataReview.DeleteReview(resourceId, reviewId);
            if (!bResult)
            {
                SetResponseStatus(HttpStatusCode.InternalServerError, "Unable to delete review");
            }
            return (bResult);
        }

        public long? AddUser(ApiClassUserWithPassword user)
        {
            var result = new ApiResponse();
            try
            {
                var dataResource = new DataClassUser();
                result = dataResource.SaveUser(user);
                if (result.ID == null)
                {
                    SetResponseStatus(HttpStatusCode.InternalServerError, result.ResponseMessage);
                }
            }
            catch (Exception ex)
            {
                SetResponseStatus(HttpStatusCode.NotFound, ex.Message);
            }

            return result.ID;
        }

        public ApiClassUserWithPassword GetUser(string username)
        {
            var users = new List<ApiClassUserWithPassword>();
            string responseMessage = null;

            try
            {
                var dataReview = new DataClassUser();
                dataReview.LoadUserList(username, users, ref responseMessage);
            }
            catch
            {
                SetResponseStatus(HttpStatusCode.Forbidden, responseMessage);
            }

            if (users.Count > 1)
            {
                SetResponseStatus(HttpStatusCode.InternalServerError, "More than one user with that username exists");
                return null;
            }

            return users[0];
        }
    }
}
