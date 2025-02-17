﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
	    private readonly IDbWrapper<Company> _companyDbWrapper;

	    public CompanyRepository(IDbWrapper<Company> companyDbWrapper)
	    {
		    _companyDbWrapper = companyDbWrapper;
        }

        public IEnumerable<Company> GetAll()
        {
            return _companyDbWrapper.FindAll();
        }

        public Company GetByCode(string companyCode)
        {
            return _companyDbWrapper.Find(t => t.CompanyCode.Equals(companyCode))?.FirstOrDefault();
        }

        public bool PostCompany(Company company)
        {
            try
            {
                return SaveCompany(company);
            }
            catch (Exception ex)
            {
                Logger(ex.ToString());
                return false;
            }
        }

        public bool PutCompany(Company company)
        {
            try
            {
                return SaveCompany(company);
            }
            catch (Exception ex)
            {
                Logger(ex.ToString());
                return false;
            }
        }
        public bool DeleteCompany(Company company)
        {
            try
            {
                return _companyDbWrapper.Delete(t => t.SiteId.Equals(company.SiteId) && t.CompanyCode.Equals(company.CompanyCode));
            }
            catch (Exception ex)
            {
                Logger(ex.ToString());
                return false;
            }

        }
        public bool SaveCompany(Company company)
        {
            var itemRepo = _companyDbWrapper.Find(t =>
                t.SiteId.Equals(company.SiteId) && t.CompanyCode.Equals(company.CompanyCode))?.FirstOrDefault();
            if (itemRepo != null)
            {
                itemRepo.CompanyName = company.CompanyName;
                itemRepo.AddressLine1 = company.AddressLine1;
                itemRepo.AddressLine2 = company.AddressLine2;
                itemRepo.AddressLine3 = company.AddressLine3;
                itemRepo.Country = company.Country;
                itemRepo.EquipmentCompanyCode = company.EquipmentCompanyCode;
                itemRepo.FaxNumber = company.FaxNumber;
                itemRepo.PhoneNumber = company.PhoneNumber;
                itemRepo.PostalZipCode = company.PostalZipCode;
                itemRepo.LastModified = company.LastModified;
                return _companyDbWrapper.Update(itemRepo);
            }

            return _companyDbWrapper.Insert(company);
        }
        private void Logger(string message)
        {
            EventLog.WriteEntry("TestCase", message, EventLogEntryType.Error);
        }
    }
}
