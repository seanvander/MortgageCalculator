<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MortgageCalculator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script src="./Scripts/jquery-1.4.1.js" type="text/javascript"></script>

<script language="JavaScript" type="text/javascript">

    // Validate user inputs
    function Validate() {

        var validated = true;

        // Start with monthly payment label empty
        $("#<%=lbMonthlyPayment.ClientID%>").html("");
        
        ResetErrorLabel();

        ClearHighlightedInputs();

        // Get user inputs
        var mortgageValue = $("#<%=txtMortgageValue.ClientID%>").val();
        var loanTermInYears = $("#<%=txtLoanTermInYears.ClientID%>").val();
        var interestRate = $("#<%=txtInterestRate.ClientID%>").val();

        if (!ValidateMortgageValue(mortgageValue)) {
            validated = false;
        }
        else if (!ValidateLoanTerm(loanTermInYears)) {
            validated = false;
        }
        else if (!ValidateInterestRate(interestRate)) {
            validated = false;
        }

        return validated;
    }

    function ResetErrorLabel() {
        $("#<%=lbError.ClientID%>").hide();
        $("#<%=lbError.ClientID%>").html("");
    }

    // Ensure no inputs are highlighted
    function ClearHighlightedInputs() {
        $("#<%=txtMortgageValue.ClientID%>").removeClass("textboxHighlight");
        $("#<%=txtLoanTermInYears.ClientID%>").removeClass("textboxHighlight");
        $("#<%=txtInterestRate.ClientID%>").removeClass("textboxHighlight");
    }

    // Validate Mortgage Value
    function ValidateMortgageValue(value) {
        if (!ValidateNumber(value)) {
            $("#<%=txtMortgageValue.ClientID%>").addClass("textboxHighlight");
            $("#<%=lbError.ClientID%>").html("* Please enter a valid number for the Mortgage Value.");
            $("#<%=lbError.ClientID%>").show();
            return false;
        }
        else {
            return true;
        }
    }

    // Validate Loan Term
    function ValidateLoanTerm(term) {
        if (!ValidateNumber(term) || term > 100) {
            $("#<%=txtLoanTermInYears.ClientID%>").addClass("textboxHighlight");
            $("#<%=lbError.ClientID%>").html("* Please enter a valid number (in years) for the Loan Term, up to 100 years.");
            $("#<%=lbError.ClientID%>").show();
            return false;
        }
        else {
            return true;
        }
    }

    // Validate Interest Rate
    function ValidateInterestRate(rate) {
        if (!ValidateNumber(rate) || rate > 100) {
            $("#<%=txtInterestRate.ClientID%>").addClass("textboxHighlight");
            $("#<%=lbError.ClientID%>").html("* Please enter a valid Interest Rate.");
            $("#<%=lbError.ClientID%>").show();
            return false;
        }
        else {
            return true;
        }
    }

    // Number Validation 
    function ValidateNumber(number) {
        if (!isFinite(number) || number <= 0 || number === "") {
            return false;
        }
        else {
            return true;
        }
    }

</script>

<head runat="server">
    <title>Mortgage Calculator</title>
    <link rel="stylesheet" href="./Styles/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tbody>
                <tr>
                    <td class="grid">
                        <div class="headerLabelContainer">
                            <span class="headerLabel">Mortgage Calculator</span>
                        </div>
                        <div class="gridItem">
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td class="nameLabel">
                                            <label>Mortgage Value:</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMortgageValue" runat="server" MaxLength="20"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="nameLabel">
                                            <label>Loan Term (Years):</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLoanTermInYears" runat="server" MaxLength="5"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="nameLabel">
                                            <label>Interest Rate (%):</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInterestRate" runat="server" MaxLength="5"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="button">
                                        <td colspan="2">
                                            <asp:Button ID="btCalculate" runat="server" Text="Calculate" OnClick="btCalculate_OnClick"
                                                OnClientClick="return Validate();" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="nameLabel">
                                            <label>Monthly Payment:</label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbMonthlyPayment" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="errorLabel">
                                            <asp:Label ID="lbError" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
