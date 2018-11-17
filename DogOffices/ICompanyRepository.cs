using DogOffices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogOffices
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        void Create(Company company);
        Company GetById(int companyId);
        void Delete(int companyId);
        void Update(Company company);
    }
}
