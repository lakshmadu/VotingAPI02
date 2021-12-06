using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Models;
using VotingAPI.DataAccess;

namespace VotingAPI.Services.Admins
{
    public class AdminSqlServerServices : IAdminRepository
    {
        private readonly VotingDbContext _context;

        public AdminSqlServerServices(VotingDbContext context)
        {
            _context = context;
        }

        public Admin FindAdmin(string AdminID)
        {
            try
            {
                var o = _context.Admins.Find(AdminID);
                if (o == null)
                    return null;
                return o;

            } catch (Exception ex)
            {
                return null;
            }
        }

        public ICollection<Admin> GetAllAdmin()
        {
            try
            {
                var o = _context.Admins.ToList();
                return o;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public Admin CreateAdmin(Admin admin)
        {
            try
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
                return _context.Admins.Find(admin.AdminID);
            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
