using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using LearnerRaterWCF.ClassFiles.Api;

namespace LearnerRaterWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "RESTApi" in both code and config file together.
    [ServiceContract]
    public interface IRESTApi
    {       
        // Get Categories 
        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "GetCategories")]
        List<ApiClassCategory> GetCategories();

        // Get Resources by category
        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "GetResources?category={category}")]
        List<ApiClassResource> GetResources(string category);

        // Add Resource - returns the new resourceId
        [OperationContract]
        [WebInvoke(Method = "POST",
             ResponseFormat = WebMessageFormat.Json,
             RequestFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "AddResource?category={category}")]
        long? AddResource(string category, ApiClassResource resource);

        // Update Resource - returns true/false
        [OperationContract]
        [WebInvoke(Method = "POST",
             ResponseFormat = WebMessageFormat.Json,
             RequestFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "UpdateResource?resourceid={resourceid}")]
        bool UpdateResource(long resourceId, ApiClassResource resource);

        // Delete Resource - returns true/false
        [OperationContract]
        [WebInvoke(Method = "DELETE",
             ResponseFormat = WebMessageFormat.Json,
             RequestFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "DeleteResource?resourceid={resourceid}")]
        bool DeleteResource(long resourceId);

        // Get reviews for resource
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetReviews?resourceid={resourceid}")]
        List<ApiClassReview> GetReviews(long resourceId);

        // Add Review
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "AddReview?resourceid={resourceid}")]
        long? AddReview(long resourceId, ApiClassReview review);

        // Update Review
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "UpdateReview?resourceid={resourceid}&reviewid={reviewid}")]
        bool UpdateReview(long resourceId, long reviewId, ApiClassReview review);

        // Delete Review
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "DeleteReview?resourceid={resourceId}&reviewid={reviewid}")]
        bool DeleteReview(long resourceId, long reviewId);

        // Get Users 
        [OperationContract]
        [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "GetUser/{username}")]
        ApiClassUserWithPassword GetUser(string username);

        // Add User
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "AddUser")]
        long? AddUser(ApiClassUserWithPassword user);
    }
}
