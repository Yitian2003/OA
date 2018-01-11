using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.DAL;
using OA.Model;
using OA.IBLL;

namespace OA.BLL
{
    public class UserInfoService : BaseService<Ou_UserInfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = DBSession.UserInfoDal;
        }
    }
}
