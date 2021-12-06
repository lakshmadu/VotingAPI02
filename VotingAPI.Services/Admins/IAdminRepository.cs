using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;

namespace VotingAPI.Services.Admins
{
    public interface IAdminRepository
    {
        public Admin FindAdmin(string AdminID);
        public ICollection<Admin> GetAllAdmin();
        public Admin CreateAdmin(Admin admin);

    }
}
