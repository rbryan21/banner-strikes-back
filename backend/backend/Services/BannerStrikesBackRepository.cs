using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services
{
    public class BannerStrikesBackRepository : IBannerStrikesBackRepository
    {

        private ApiContext _context;

        public BannerStrikesBackRepository(ApiContext context)
        {
            _context = context;
        }

        public void AddOrganization(Organization organization)
        {
            _context.Organizations.Add(organization);
        }

        public void DeleteOrganization(string code)
        {
            _context.Organizations.Remove(_context.Organizations.First(a => a.Code == code));
        }

        public Organization GetOrganization(string code)
        {
            return _context.Organizations.FirstOrDefault(a => a.Code == code);
        }

        public List<Organization> GetOrganizations()
        {
            var organizations = new List<Organization>();
            foreach (var organization in _context.Organizations)
            {
                organizations.Add(organization);
            }
            return organizations;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateOrganization(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
