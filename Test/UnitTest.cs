using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator;

namespace Test
{
    /// <summary>
    /// Unit Tests for Mortgage Calculator
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMonthlyPaymentInvalidInterestRate()
        {
            try
            {
                double amountBorrowed = 100000;
                double loanTermInMonths = 240;
                double yearlyFixedInterestRate = 8.5;

                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                Assert.Fail("Expected Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Yearly fixed interest rate must be expressed as a decimal, not a percentage.", ae.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message);
            }

        }

        [TestMethod]
        public void TestMonthlyPaymentInvalidTerm()
        {
            try
            {
                double amountBorrowed = 100000;
                double loanTermInMonths = 1500;
                double yearlyFixedInterestRate = 0.85;

                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                Assert.Fail("Expected Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Loan term cannot be greater than 1200 months.", ae.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message);
            }

        }
        
        [TestMethod]
        public void TestMonthlyPaymentRounding()
        {
            double amountBorrowed = 100000;
            double loanTermInMonths = 240;
            double yearlyFixedInterestRate = 0.085;

            double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

            // Rounding must be to 2 decimal places
            double value = monthlyPayment * 100;

            Assert.AreEqual(value, Math.Floor(value), "Expected rounding to 2 decimal places");
        }

        [TestMethod]
        public void TestMonthlyPayment()
        {
            double amountBorrowed = 100000;
            double loanTermInMonths = 240;
            double yearlyFixedInterestRate = 0.085;

            double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

            Assert.IsTrue(monthlyPayment == 867.82, "Expected monthly payment of {0} for Loan of {1} over {2} months at a yearly interest rate of {3}. Actual: {4}.", 867.82, amountBorrowed, loanTermInMonths, yearlyFixedInterestRate, monthlyPayment);
        }

        [TestMethod]
        public void TestMonthlyPaymentNegativeAmountBorrowed()
        {
            try
            {
                double amountBorrowed = -1;
                double loanTermInMonths = 240;
                double yearlyFixedInterestRate = 0.1;

                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                Assert.Fail("Expected Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Arguments must be greater than zero.", ae.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message);
            }

        }

        [TestMethod]
        public void TestMonthlyPaymentNegativeLoanTerm()
        {
            try
            {
                double amountBorrowed = 100000;
                double loanTermInMonths = -1;
                double yearlyFixedInterestRate = 0.1;

                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                Assert.Fail("Expected Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Arguments must be greater than zero.", ae.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message);
            }

        }

        [TestMethod]
        public void TestMonthlyPaymentNegativeInterestRate()
        {
            try
            {
                double amountBorrowed = 100000;
                double loanTermInMonths = 240;
                double yearlyFixedInterestRate = -0.1;

                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                Assert.Fail("Expected Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Arguments must be greater than zero.", ae.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message);
            }

        }

        [TestMethod]
        public void TestMonthlyPaymentZeroAmountBorrowed()
        {
            try
            {
                double amountBorrowed = 0;
                double loanTermInMonths = 240;
                double yearlyFixedInterestRate = 0.1;

                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                Assert.Fail("Expected Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Arguments must be greater than zero.", ae.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message);
            }

        }

        [TestMethod]
        public void TestMonthlyPaymentZeroLoanTerm()
        {
            try
            {
                double amountBorrowed = 100000;
                double loanTermInMonths = 0;
                double yearlyFixedInterestRate = 0.1;

                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                Assert.Fail("Expected Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Arguments must be greater than zero.", ae.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message);
            }

        }

        [TestMethod]
        public void TestMonthlyPaymentZeroInterestRate()
        {
            try
            {
                double amountBorrowed = 100000;
                double loanTermInMonths = 240;
                double yearlyFixedInterestRate = 0;

                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                Assert.Fail("Expected Argument Exception");
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Arguments must be greater than zero.", ae.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", ex.GetType(), ex.Message);
            }

        }
    }
}
