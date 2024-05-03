using _2704.Interfaces;
using _2704.Models;
using Microsoft.EntityFrameworkCore;

namespace _2704.Repository
{
    public class RoleRepository: IRoleRepository
    {
        private readonly WeatherForecastContext _context;
        public RoleRepository(WeatherForecastContext context)
        {
            _context = context;
        }
        public ICollection<Role> GetRoles()
        {

            return _context.Roles.ToList();

        }
        public Role GetRoleById(int id)
        {
            return _context.Roles.Where(e => e.RoleId == id).FirstOrDefault();
        }
        public bool RoleExists(int roleId)
        {
            return _context.Roles.Any(p => p.RoleId == roleId);
        }

        public bool CreateRole(Role location)
        {
            _context.Add(location);
            return Save();
        }
     
        public bool DeleteRole(Role location)
        {
            _context.Remove(location);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRole(Role updatedRole)
        {
            var existingRole = _context.Roles.FirstOrDefault(r => r.RoleId == updatedRole.RoleId);
            if (existingRole == null)
            {
                return false; 
            }
            existingRole.RoleId = updatedRole.RoleId;
            existingRole.RoleName = updatedRole.RoleName;
            _context.Update(existingRole);
            return Save();
        }
    }
}
