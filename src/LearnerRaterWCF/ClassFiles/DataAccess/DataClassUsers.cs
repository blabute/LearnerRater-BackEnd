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

        public void LoadUserList(List<ApiClassUserGET> UserList)
        {
            UserList.Clear();
            var dt = UsersTblAdapter.GetData();
            for (var i = 0; i < dt.Count; i++)
            {
                var User = new ApiClassUserGET();
                User.ID = dt[i].User_ID;
                if (!dt[i].IsUsernameNull())
                    User.Username = dt[i].Username;

                UserList.Add(User);
            }
        }

        public ApiResponse SaveUser(ApiClassUserPOST User)
        {
            long? UserId = null;
            string ResponseMessage = null;
            UsersTblAdapter.SaveUser(ref UserId, User.Username, User.Password, User.PasswordSalt, User.Email, User.FullName, ref ResponseMessage);
            return new ApiResponse() { ID = UserId, ResponseMessage = ResponseMessage };
        }

        public bool UpdateUser(long? UserId, ApiClassUserPOST User)
        {
            string ResponseMessage = null;
            UsersTblAdapter.SaveUser(ref UserId, User.Username, User.Password, User.PasswordSalt, User.Email, User.FullName, ref ResponseMessage);
            return (UserId != null);
        }

        public ApiResponse Login(ApiClassUserPOST User)
        {
            string ResponseMessage = null;
            
            var test = UsersTblAdapter.Login(User.Username, ref ResponseMessage);
            //var test = new ApiResponse() { ID = areLoggedOn.HasValue ? (areLoggedOn.Value ? 1 : 0) : 0, ResponseMessage = ResponseMessage };
            return new ApiResponse() { ResponseMessage = ResponseMessage };
        }
    }
}