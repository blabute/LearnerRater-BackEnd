using System.Collections.Generic;
using LearnerRaterWCF.ClassFiles.Api;
using LearnerRaterWCF.TableAdapters.MainDALTableAdapters;
using LearnerRaterWCF.Models;

namespace LearnerRaterWCF.ClassFiles.DataAccess
{
    public class DataClassUser
    {
        private GetUsersTableAdapter m_UsersTblAdapter;

        public GetUsersTableAdapter UsersTblAdapter
        {
            get
            {
                if (m_UsersTblAdapter == null)
                    m_UsersTblAdapter = new GetUsersTableAdapter();
                return (m_UsersTblAdapter);
            }
        }

        public void LoadUserList(string username, List<ApiClassUserWithPassword> UserList, ref string responseMessage)
        {
            UserList.Clear();
            var dt = UsersTblAdapter.GetData(username, ref responseMessage);
            for (var i = 0; i < dt.Count; i++)
            {
                var User = new ApiClassUserWithPassword();
                User.ID = dt[i].User_Id;
                if (!dt[i].IsUsernameNull())
                    User.Username = dt[i].Username;
                if (!dt[i].IsPasswordNull())
                    User.Password = dt[i].Password;
                if (!dt[i].IsEmailNull())
                    User.Email = dt[i].Email;
                if (!dt[i].IsFullNameNull())
                    User.FullName = dt[i].FullName;
                if (!dt[i].IsIsAdminNull())
                    User.IsAdmin = dt[i].IsAdmin;

                UserList.Add(User);
            }
        }

        public ApiResponse SaveUser(ApiClassUserWithPassword User)
        {
            long? UserId = null;
            string ResponseMessage = null;
            UsersTblAdapter.SaveUser(ref UserId, User.Username, User.Password, User.Email, User.FullName, ref ResponseMessage);
            return new ApiResponse() { ID = UserId, ResponseMessage = ResponseMessage };
        }

        public bool UpdateUser(long? UserId, ApiClassUserWithPassword User)
        {
            string ResponseMessage = null;
            UsersTblAdapter.SaveUser(ref UserId, User.Username, User.Password, User.Email, User.FullName, ref ResponseMessage);
            return (UserId != null);
        }
    }
}