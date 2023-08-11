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
    public class ExpenseServiceTest
    {

        //TODO
        //Fill in the steps for every test
        //1. Create a unique dbcontextoption 
        //2. Setup a new database with fresh data for every test
        //3. Test respective method in the ExpenseService.cs 
        //4. Do atleast 1 assertion using fluent assertions

        //GOAL: This test should run in parallel with CategoryServiceTest

        private readonly string _className;
        public ExpenseServiceTest()
        {
            _className = GetType().Name;
        }

        [Fact]
        public void GetAllExpenses_ShouldReturnAllExpenses()
        {
            //Arrange
            //1
            //2


            //Act
            //3
            //3;

            //Assert
            //4 Assert that there should be expenses retrieved 
        }

        [Fact]
        public void GetAllOrderedByAmount_ExpensesShouldBeInAscendingOrder()
        {
            //Arrange
            //1
            //2


            //Act
            //3
            //3

            //Assert
            //4 Assert that expenses should be in ascending order
        }

        [Fact]
        public void GetSingleExpense_ShouldReturnRequested()
        {
            //Arrange
            //1
            //2

            //Act
            //3
            //3

            //Assert
            //4 Assert that expense returned is the one requested
        }

        [Fact]
        public void AddExpense_ShouldSuccessfullyAddExpense()
        {
            //Arrange
            //1
            //2


            //Act
            //3
            //3

            //Assert
            //4 Assert that expense was added
        }

        [Fact]
        public void DeleteExpense_ShouldSuccessfullyDeleteExpense()
        {
            //Arrange
            //1
            //2


            //Act
            //3
            //3

            //Assert
            //4 Assert that expense was deleted
        }
    }
}
