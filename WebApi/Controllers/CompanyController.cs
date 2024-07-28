using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var items = await _companyService.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = await _companyService.GetCompanyByCode(companyCode);
            return _mapper.Map<CompanyDto>(item);
        }

        // POST api/<controller>
        public async void Post([FromBody] Company value)
        {
            if (!await _companyService.PostCompany(value))
            {
                Logger("Inserting item " + value.SiteId + "||" + value.CompanyCode + " failed.");
            }
        }

        // PUT api/<controller>/5
        public async void Put([FromBody] Company value)
        {
            if (!await _companyService.PutCompany(value))
            {
                Logger("Updating item " + value.SiteId + "||" + value.CompanyCode + " failed.");
            }
        }

        // DELETE api/<controller>/5
        public async void Delete(Company value)
        {
            if (!await _companyService.DeleteCompany(value))
            {
                Logger("Deleting item " + value.SiteId + "||" + value.CompanyCode + " failed.");
            }
        }

        private void Logger(string message)
        {
            EventLog.WriteEntry("TestCase", message, EventLogEntryType.Error);
        }
    }
}