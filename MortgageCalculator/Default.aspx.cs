using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Reflection;

namespace MortgageCalculator
{
    public partial class _Default : System.Web.UI.Page
    {
        // Log4Net logger
        private static readonly ILog LOG = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                lbError.Text = String.Empty;
            }
        }

        /// <summary>
        /// Handle click for button btCalculate 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btCalculate_OnClick(Object sender, EventArgs e)
        {
            try
            {
                // Convert input values
                double amountBorrowed = Convert.ToDouble(txtMortgageValue.Text);
                double yearlyFixedInterestRate = Convert.ToDouble(txtInterestRate.Text) / 100;
                double loanTermInMonths = Convert.ToDouble(txtLoanTermInYears.Text) * 12;

                LOG.Debug(String.Format("{0}: Calculating monthly payment for Amount Borrowed: {1}, Yearly Fixed Interest Rate: {2}, Loan Term in Months: {3}",
                    MethodBase.GetCurrentMethod().Name, amountBorrowed, yearlyFixedInterestRate, loanTermInMonths));

                // Calculate monthly payment
                double monthlyPayment = Calculator.CalculateMonthlyPaymentForLoan(amountBorrowed, loanTermInMonths, yearlyFixedInterestRate);

                LOG.Debug(String.Format("{0}: Monthly payment calculated as {1}", MethodBase.GetCurrentMethod().Name, monthlyPayment));

                lbMonthlyPayment.Text = String.Format("R{0:#,0.00}", monthlyPayment);

            }
            catch (Exception ex)
            {
                LOG.Error(String.Format("{0}: Caught Exception.", MethodBase.GetCurrentMethod().Name), ex);
                lbError.Text = String.Format("Error: {0}", ex.Message);
            }
        }
    }
}