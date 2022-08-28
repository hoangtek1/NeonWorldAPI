using NeonWorld.Entities;
using NeonWorld.ViewModels.Common;
using NeonWorld.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.System.Users
{
    public interface IUserService
    {
        ApiResult<string> Login(UserLogin userLogin);
        ApiResult<bool> CreateUser(RegisterRequest userRegister);
        ApiResult<bool> ChangePassword(UserChangePassword changePassword);
        Task<User> GetUserAsync(Guid userId);
        ApiResult<string> Logout();
    }
}
