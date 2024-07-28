using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public Task<IEnumerable<CompanyInfo>> GetAllCompanies()
        {
            var res = _companyRepository.GetAll();
            return Task.Run(() => _mapper.Map<IEnumerable<CompanyInfo>>(res));
        }

        public Task<CompanyInfo> GetCompanyByCode(string companyCode)
        {
            var result = _companyRepository.GetByCode(companyCode);
            return Task.Run(() => _mapper.Map<CompanyInfo>(result));
        }
        public Task<bool> PostCompany(Company company)
        {
            return Task.Run(() => _companyRepository.PostCompany(company));
        }
        public Task<bool> PutCompany(Company company)
        {
            return Task.Run(() => _companyRepository.PutCompany(company));
        }
        public Task<bool> DeleteCompany(Company company)
        {
            return Task.Run(() => _companyRepository.DeleteCompany(company));
        }
    }
}
