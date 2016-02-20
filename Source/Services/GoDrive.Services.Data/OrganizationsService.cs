﻿namespace GoDrive.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GoDrive.Data.Common;
    using GoDrive.Data.Models;

    public class OrganizationsService : IOrganizationsService
    {
        private IDbRepository<Organization> organizations;

        public OrganizationsService(IDbRepository<Organization> organizations)
        {
            this.organizations = organizations;
        }

        public IQueryable<Organization> GetALl()
        {
            return this.organizations.All();
        }

        public IQueryable<Organization> GetById(int id)
        {
            return this.organizations
                .All()
                .Where(o => o.Id == id);
        }

        public void Create(Organization organization)
        {
            this.organizations.Add(organization);
            this.organizations.Save();
        }

        public void Update(Organization organization)
        {
            var organizationToUpdate = this.organizations.GetById(organization.Id);

            organizationToUpdate.AboutInfo = organization.AboutInfo;
            organizationToUpdate.Name = organization.Name;

            this.organizations.Save();
        }
    }
}
