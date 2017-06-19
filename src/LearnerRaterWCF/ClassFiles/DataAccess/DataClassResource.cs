using System;
using System.Collections.Generic;
using LearnerRaterWCF.ClassFiles.Api;
using LearnerRaterWCF.TableAdapters.MainDALTableAdapters;

namespace LearnerRaterWCF.ClassFiles.DataAccess
{
    public class DataClassResource
    {
        // Table Adapters
        private GetResourcesTableAdapter m_ResourcesTblAdapter;

        public GetResourcesTableAdapter ResourcesTblAdapter
        {
            get
            {
                if (m_ResourcesTblAdapter == null)
                    m_ResourcesTblAdapter = new GetResourcesTableAdapter();
                return(m_ResourcesTblAdapter);
            }            
        }

        public void SetCategoryResourceCounts(List<ApiClassCategory> categoryList)
        {
            for (var i = 0; i < categoryList.Count; i++)
            {
                int? iCount = null;
                ResourcesTblAdapter.GetCount(categoryList[i].Category,ref iCount);
                if (iCount != null) categoryList[i].NumberOfResources = (int) iCount;
                else categoryList[i].NumberOfResources = 0;
            }
        }

        public void LoadResourceList(string category, List<ApiClassResource> resourceList)
        {
            resourceList.Clear();

            var dataReview = new DataClassReview();
            var dt = ResourcesTblAdapter.GetData(category);
            for (var i = 0; i < dt.Count; i++)
            {
                var resource = new ApiClassResource();

                resource.ID = dt[i].Resource_ID;
                if (!dt[i].IsCategoryNull())
                    resource.Catagory = dt[i].Category;
                if (!dt[i].IsTitleNull())
                    resource.Title = dt[i].Title;
                if (!dt[i].IsAuthorNull())
                    resource.Author = dt[i].Author;
                if (!dt[i].IsDescriptionNull())
                    resource.Description = dt[i].Description;
                if (!dt[i].IsWebsiteNull())
                    resource.Website = dt[i].Website;
                if (!dt[i].IsURLNull())
                    resource.URL = dt[i].URL;
                //

                dataReview.LoadReviewList(resource.ID, resource.Reviews);
                resourceList.Add(resource);
            }

        }

        public long? SaveResource(string category, ApiClassResource resource)
        {
            long? resourceId = null;
            ResourcesTblAdapter.SaveResource(ref resourceId, category, resource.Title, resource.Author, resource.Description, resource.Website, resource.URL);
            if (resourceId != null)
            {
                var dataReview = new DataClassReview();
                if(!dataReview.SaveReviewList((long)resourceId, resource.Reviews))
                {
                    ResourcesTblAdapter.DeleteResource(resourceId);
                    resourceId = null;
                }
            }
            return resourceId;
        }

        public bool UpdateResource(long? resourceId, ApiClassResource resource)
        {
            ResourcesTblAdapter.SaveResource(ref resourceId, resource.Catagory, resource.Title, resource.Author, resource.Description, resource.Website, resource.URL);
            var bResult = (resourceId != null);
            if (bResult)
            {
                var dataReview = new DataClassReview();
                bResult = dataReview.DeleteResourceReviews((long) resourceId);
                if (bResult)
                {
                    bResult = dataReview.SaveReviewList((long) resourceId, resource.Reviews);
                }
            }
            return (bResult);
        }

        public bool DeleteResource(long resourceId)
        {
            try
            {
                ResourcesTblAdapter.DeleteResource(resourceId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}