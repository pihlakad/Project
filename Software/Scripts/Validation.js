function IsFirstUnitEmpty() {
    if (document.getElementById('FirstUnit').value === "") {
        return 'First Unit should not be empty';
    }
    else { return ""; }
}

function IsFirstUnitInValid() {
    var i = document.getElementById('FirstUnit').value;
    if ((i.length === 2|| i.length === 3)&& ContainsPrefix(i)) {
        return 'Enter Correct Prefix for First Unit';
    }
    else { return ""; }
}
function IsSecondUnitEmpty() {
    if (document.getElementById('SecondUnit').value === "") {
        return 'Second Unit should not be empty';
    }
    else { return ""; }
}

function IsSecondUnitInValid() {
    var i = document.getElementById('SecondUnit').value;
    if ((i.length === 2 || i.length === 3) && ContainsPrefix(i)) {
        return 'Enter Correct Prefix for Second Unit';
    }
    else { return ""; }
}

function ContainsPrefix(i) {
    var firstLetter = i.Substring(0, 1);
    var secondLetter = i.Substring(1, 2);    
    if (firstLetter === "c") return false;
    if (firstLetter === "d" && secondLetter === "a") return false;
    if (firstLetter === "d") return false;
    if (firstLetter === "h") return false;
    if (firstLetter === "k") return false;
    if (firstLetter === "M") return false;
    if (firstLetter === "G") return false;
    if (firstLetter === "T") return false;
    if (firstLetter === "μ") return false;
    if (firstLetter === "n") return false;
    if (firstLetter === "p") return false;
    return true;
}

function IsValid() {
    var firstUnitEmptyMessage = IsFirstUnitEmpty();
    var firstUnitInValidMessage = IsFirstUnitInValid();
    var secondUnitInValidMessage = IsSecondUnitInValid();
    var secondUnitEmptyMessage = IsSecondUnitEmpty();

    var finalErrorMessage = "Errors:";
    if (firstUnitEmptyMessage !== "")
        finalErrorMessage += "\n" + firstUnitEmptyMessage;
    if (firstUnitInValidMessage !== "")
        finalErrorMessage += "\n" + firstUnitInValidMessage;
    if (secondUnitInValidMessage !== "")
        finalErrorMessage += "\n" + secondUnitInValidMessage;
    if (secondUnitEmptyMessage !== "")
        finalErrorMessage += "\n" + secondUnitEmptyMessage;
    if (finalErrorMessage !== "Errors:") {
        alert(finalErrorMessage);
        return false;
    }
    else {
        return true;
    }
}