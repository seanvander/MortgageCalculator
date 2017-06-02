Notes on how I approached and tested this solution:

- I Created an ASP.NET Solution and Project called Mortgage Calculator using the .NET 3.5 Framework.

- Wrote a static class, Calculator, that calculates the monthly mortgage payments for a fixed interest rate.

- I used http://en.wikipedia.org/wiki/Mortgage_calculator#Monthly_payment_formula and http://www.mtgprofessor.com/formulas.htm as reference for the monthly payment formula.

- Created a Test Project and wrote unit tests against the Calculator method 'CalculateMonthlyPaymentForLoan'.

- Developed UI code in Default.aspx.

- Added CSS styling.

- Used javascript and jQuery to validate user inputs on the aspx page.

- Wrote C# code in Default.aspx.cs to call the Calculator method 'CalculateMonthlyPaymentForLoan' and added error handling logic.

- Added basic logging using log4net library.

- Tested UI on Chrome and Edge browsers.

- Added further unit tests that came out of the browser testing.

- Compared monthly payment results to other Mortgage Calculators on the Web.

- Further functionality could be added, such as showing the total interest paid over the loan term and catering for additional payments per month.

- Automated testing of the UI, using Visual Studio Test Professional or a tool like Selenium, would provide another level of testing to ensure the application works as expected.

