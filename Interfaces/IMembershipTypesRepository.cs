using LibApp.Models;
using System.Collections.Generic;

namespace LibApp.Interfaces
{
    public interface IMembershipTypesRepository
    {
        IEnumerable<MembershipType> GetAllMembershipTypes();
        MembershipType GetMembershipType(int id);
    }
}
