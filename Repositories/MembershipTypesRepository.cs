using LibApp.Data;
using LibApp.Interfaces;
using LibApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibApp.Repositories
{
    public class MembershipTypesRepository : IMembershipTypesRepository
    {
        private readonly ApplicationDbContext _context;
        public MembershipTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MembershipType> GetAllMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public MembershipType GetMembershipType(int id)
        {
            return _context.MembershipTypes.FirstOrDefault(x => x.Id == id);
        }
    }
}
