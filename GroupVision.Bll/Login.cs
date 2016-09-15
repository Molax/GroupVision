using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupVision.Bll
{
    public class Login
    {
        public int LoginUser(string login, string password)
        {
            return new GroupVision.Dal.Login().LoginUsuario(login, password);
        }
    }
}
