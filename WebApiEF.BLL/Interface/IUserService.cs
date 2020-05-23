using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.DAL.Identity;
using WebApiEF.DAL.Models;

namespace WebApiEF.BLL.Interface
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterUser registerUser);

        Task<UserManagerResponse> LoginUserAsync(LoginUser loginUser);
    }

}
