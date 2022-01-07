using Nihongo.Application.Commands.Auth;
using Nihongo.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nihongo.Application.Interfaces.Reposiroty;
using Nihongo.Application.Interfaces.Services;

namespace Nihongo.Repository.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<User> _userRepository;

        public UserService(IRepositoryBase<User> userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<User> ValidateUserAsync(AuthRequest request)
        {
            return await _userRepository.FindAsync(u => u.Username == request.Username);
        }
    }
}
