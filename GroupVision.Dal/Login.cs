using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupVision.Data;


namespace GroupVision.Dal
{
    public class Login
    {
        public int LoginUsuario(string login, string password)
        {
            using (var db = new GroupVisionDataContext())
            {
                var user = db.Usuarios.Where(u => u.LOGIN == login && u.SENHA == password).ToList();

                if (user.Count > 0)
                {
                    return user.First().PK_ID_USUARIO;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
