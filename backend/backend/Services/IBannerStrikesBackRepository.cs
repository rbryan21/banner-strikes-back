using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public interface IBannerStrikesBackRepository
    {
        // Organizations
        Organization GetOrganization(string code);
        List<Organization> GetOrganizations();
        void AddOrganization(Organization organization);
        void DeleteOrganization(string code);
        void UpdateOrganization(Organization organization);

        bool Save();
    }
}
