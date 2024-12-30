//calculate days in month
function getDaysInMonth() {
    const now = new Date();
    const year = now.getFullYear();
    const month = now.getMonth();
    return new Date(year, month + 1, 0).getDate();
}

//Provincial Tax
function calProvincialTax(province, amount) {
    //Tax Rates
    const taxRate = {
        AB: [
            { limit: 14292, rate: 0.10 },
            { limit: 170751, rate: 0.12 },
            { limit: 227668, rate: 0.13 },
            { limit: 341502, rate: 0.14 },
            { limit: Infinity, rate: 0.15 },
        ],
        BC: [
            { limit: 45654, rate: 0.0506 },
            { limit: 91310, rate: 0.0770 },
            { limit: 104835, rate: 0.1050 },
            { limit: 127299, rate: 0.1229 },
            { limit: 172602, rate: 0.1470 },
            { limit: Infinity, rate: 0.1680 },
        ],
        MB: [
            { limit: 36842, rate: 0.1080 },
            { limit: 79625, rate: 0.1275 },
            { limit: Infinity, rate: 0.1740 },
        ],
        NL: [
            { limit: 41457, rate: 0.0870 },
            { limit: 82913, rate: 0.1450 },
            { limit: 148027, rate: 0.1580 },
            { limit: 207239, rate: 0.1730 },
            { limit: 263640, rate: 0.1830 },
            { limit: Infinity, rate: 0.1980 },
        ],
        NT: [
            { limit: 48326, rate: 0.0590 },
            { limit: 96655, rate: 0.0860 },
            { limit: 157139, rate: 0.1220 },
            { limit: Infinity, rate: 0.1405 },
        ],
        NS: [
            { limit: 29590, rate: 0.0879 },
            { limit: 59180, rate: 0.1495 },
            { limit: 93000, rate: 0.1667 },
            { limit: 150000, rate: 0.1750 },
            { limit: Infinity, rate: 0.21 },
        ],
        NU: [
            { limit: 50877, rate: 0.04 },
            { limit: 101754, rate: 0.07 },
            { limit: 165429, rate: 0.09 },
            { limit: Infinity, rate: 0.1150 },
        ],
        ON: [
            { limit: 49231, rate: 0.0505 },
            { limit: 98463, rate: 0.0915 },
            { limit: 150000, rate: 0.1116 },
            { limit: 220000, rate: 0.1216 },
            { limit: Infinity, rate: 0.1316 }
        ],
        PE: [
            { limit: 31984, rate: 0.0980 },
            { limit: 63969, rate: 0.1380 },
            { limit: Infinity, rate: 0.1670 },
        ],
        QC: [
            { limit: 49275, rate: 0.15 },
            { limit: 98540, rate: 0.20 },
            { limit: 119910, rate: 0.24 },
            { limit: Infinity, rate: 0.2575 },
        ],
        SK: [
            { limit: 49720, rate: 0.1050 },
            { limit: 142058, rate: 0.1250 },
            { limit: Infinity, rate: 0.1450 },
        ],
        YK: [
            { limit: 53359, rate: 0.0640 },
            { limit: 106717, rate: 0.09 },
            { limit: 165430, rate: 0.1090 },
            { limit: 500000, rate: 0.1280 },
            { limit: Infinity, rate: 0.15 },
        ],
    };

    if (!taxRate[province]) {
        return 0;
    }

    for (let bracket of taxRate[province]) {
        if (amount <= bracket.limit) {
            return amount * bracket.rate;
        }
    }

    return 0;
}

function updatePayroll() {
    // Get Elements
    const getAmount = parseFloat(document.getElementById("amount").value) || 0; 
    const getPayType = document.getElementById("payType").value; 
    const getWorkHours = parseFloat(document.getElementById("workhours").value) || 0;
    const province = document.getElementById("province").value;

    const federalTaxInput = document.getElementById("federalTax");
    const provincialTaxInput = document.getElementById("provincialTax");



    // if workhours value is 0, stop calculating
    if (getPayType === "h" && getWorkHours === 0) {
        federalTaxInput.value = "0.00";
        return;
    }

    // Total Amount 
    let totalAmount = 0.00;

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

    const calculatedProvincialTax = calProvincialTax(province, totalAmount);
    provincialTaxInput.value = isNaN(calculatedProvincialTax) ? "0.00" : calculatedProvincialTax.toFixed(2);
}

//Event Listeners
document.getElementById("amount").addEventListener("input", updatePayroll);
document.getElementById("payType").addEventListener("change", updatePayroll);
document.getElementById("workhours").addEventListener("input", updatePayroll);
document.getElementById("province").addEventListener("change", updatePayroll);