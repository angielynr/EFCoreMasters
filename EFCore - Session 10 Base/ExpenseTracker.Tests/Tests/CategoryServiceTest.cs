using ExpenseTracker.Data;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Infrastructure.Services;
using ExpenseTracker.Tests.Helper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Tests.Tests
{
    public class CategoryServiceTest
    {
        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the CategoryService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with ExpenseServiceTest

        private readonly string _className;
        public CategoryServiceTest()
        {
            _className = GetType().Name;
        }

        [Fact]
        public void GetAllCategories_ShouldReturnAllCategories()
        {
            //Arrange
            //1
            //2


            //Act
            //3
            //3

            //Assert
            //4 Assert that there should be categories retrieved 
        }


        [Fact]
        public void GetSingleCategory_ShouldReturnRequested()
        {
            //Arrange
            //1
            //2

            //Act
            //3
            //3

            //Assert
            //4 Assert that category returned is the one requested
        }

        [Fact]
        public void AddCategory_ShouldSuccessfullyAddCategory()
        {
            //Arrange
            //1
            //2


            //Act
            //3
            //3
            

            //Assert
            //4 Assert that category was added
        }

        [Fact]
        public void DeleteCategory_ShouldSuccessfullyDeleteCategory()
        {
            //Arrange
            //1
            //2


            //Act
            //3
            //3

            //Assert
            //4 Assert that category was deleted
        }
    }
}
