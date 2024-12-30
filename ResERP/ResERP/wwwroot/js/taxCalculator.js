function updatePayroll() {
    // Get Elements
    const getAmount = parseFloat(document.getElementById("amount").value) || 0; 
    const getPayType = document.getElementById("payType").value; 
    const getWorkHours = parseFloat(document.getElementById("workhours").value) || 0;
    const federalTaxInput = document.getElementById("federalTax"); 

    // if workhours value is 0, stop calculating
    if (getPayType === "h" && getWorkHours === 0) {
        federalTaxInput.value = "0.00";
        return;
    }

    // Total Amount 
    let totalAmount = 0.00;

    //calculate days in month
    function getDaysInMonth() {
        const now = new Date();
        const year = now.getFullYear();
        const month = now.getMonth();
        return new Date(year, month + 1, 0).getDate();
    }

    // Calculate Total Value by pay type
    if (getPayType === "h") {
        totalAmount = getAmount * getWorkHours; //hourly
    } else if (getPayType === "d") {
        totalAmount = getAmount * getDaysInMonth(); //daily
    } else if (getPayType === "m") {
        totalAmount = getAmount; // monthly
    }

    //Calculate Federal Tax
    function calFederalTax(amount) {
        if (amount < 53359) {
            return amount * 0.15;
        } else if (amount >= 53359 && amount < 106717) {
            return amount * 0.205;
        } else if (amount >= 106717 && amount < 165430) {
            return amount * 0.26;
        } else if (amount >= 165430 && amount < 235675) {
            return amount * 0.29;
        } else {
            return amount * 0.33;
        }
    }

    // Federal Tax Value
    const calculatedFederalTax = calFederalTax(totalAmount);
    federalTaxInput.value = isNaN(calculatedFederalTax) ? "0.00" : calculatedFederalTax.toFixed(2);
}

//Event Listeners
document.getElementById("amount").addEventListener("input", updatePayroll);
document.getElementById("payType").addEventListener("change", updatePayroll);
document.getElementById("workhours").addEventListener("input", updatePayroll);
