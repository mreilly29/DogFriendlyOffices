using DogOffices.Controllers;
using DogOffices.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace DogOffices.Tests
{
    public class CompanyControllerTests
    {
        ICompanyRepository companyRepo;
        CompanyController underTest;

        public CompanyControllerTests()
        {
            companyRepo = Substitute.For<ICompanyRepository>();
            underTest = new CompanyController(companyRepo);
        }
        [Fact]
        public void Index_Returns_A_View()
        {
            var result = underTest.Index();
            
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void GetAll_Returns_All_Companies_In_Index()
        {
            var expectedModel = new List<Company>();
            
            companyRepo.GetAll().Returns(expectedModel);

            var result = underTest.Index();
            
            var model = ((ViewResult)result).Model;

            Assert.Equal(expectedModel, model);
        }

        [Fact]
        public void Details_Passes_Correct_Car_To_View()
        {
            var companyId = 42;
            var expectedCompany = new Company();

            companyRepo.GetById(companyId).Returns(expectedCompany);

            var result = underTest.Details(companyId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCompany, model);
        }

        [Fact]
        public void Create_Creates_And_Saves_Car()
        {
            var company = new Company();
            underTest.Create(company);

            companyRepo.Received().Create(company);
        }
        [Fact]
        public void Create_Redirects_To_Index_After_Creating()
        {
            var company = new Company();
            var result = underTest.Create(company);
            var redirectResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirectResult.ActionName); //redirecting specifically to Index
        }

        [Fact]
        public void Delete_Passes_Correct_Company_To_View()
        {
            var companyId = 42;
            var expectedCompany = new Company();

            companyRepo.GetById(companyId).Returns(expectedCompany);

            var result = underTest.Delete(companyId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCompany, model);
        }

        [Fact]
        public void Delete_Post_Deletes_The_Company()
        {
            var companyId = 42;
            underTest.DeletePost(companyId);

            companyRepo.Received().Delete(companyId);
        }
        [Fact]
        public void Delete_Redirects_To_Index_After_Creating()
        {
            var result = underTest.DeletePost(42);
            var redirectResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirectResult.ActionName); //redirecting specifically to Index
        }

        [Fact]
        public void Edit_Passes_Existing_Company_To_View()
        {
            var companyId = 42;
            var expectedCompany = new Company();
            companyRepo.GetById(companyId).Returns(expectedCompany);

            var result = underTest.Edit(companyId);
            var model = ((ViewResult)result).Model;

            Assert.Same(expectedCompany, model);
        }

        [Fact]
        public void Edit_Saves_Updated_Company()
        {
            var company = new Company();

            underTest.Edit(company);

            companyRepo.Received().Update(company);
        }

        [Fact]
        public void Edit_Redirects_To_Index()
        {
            var company = new Company();

            var result = underTest.Edit(company);
            var redirectResult = (RedirectToActionResult)result;

            Assert.Same("Index", redirectResult.ActionName);
        }
    }
}
