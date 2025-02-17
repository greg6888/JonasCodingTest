﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Model.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company GetByCode(string companyCode);
        bool PostCompany(Company company);
        bool PutCompany(Company company);
        bool DeleteCompany(Company company);
        bool SaveCompany(Company company);
    }
}
