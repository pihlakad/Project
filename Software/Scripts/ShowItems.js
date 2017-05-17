function ShowInputElement() {
    var x = document.getElementById('SecondQuantity');
    var c = document.getElementById('OperationDropDown').value;
    if (c === "Round")
        x.style.display = 'none';
    else x.style.display = 'block';
}
function ShowResult() {
    var x = document.getElementById('ResultLabel');
    x.style.display = 'block';    
}

function ShowUnits() {
    var x1 = document.getElementById('FirstUnit');
    var x2 = document.getElementById('SecondUnit');
    var x3 = document.getElementById('ThirdUnit');
    var x4 = document.getElementById('FourthUnit');
    var x5 = document.getElementById('FifthUnit');
    var unitsAmount = document.getElementById('UnitDropDown').value;
    if (unitsAmount === "4") {
        x1.style.display = 'block';
        x2.style.display = 'block';
        x3.style.display = 'block';
        x4.style.display = 'block';
        x5.style.display = 'none';
    } else if (unitsAmount === "3") {
        x1.style.display = 'block';
        x2.style.display = 'block';
        x3.style.display = 'block';
        x4.style.display = 'none';
        x5.style.display = 'none';
    } else if (unitsAmount === "2") {
        x1.style.display = 'block';
        x2.style.display = 'block';
        x3.style.display = 'none';
        x4.style.display = 'none';
        x5.style.display = 'none';
    } else if (unitsAmount === '1') {
        x1.style.display = 'block';
        x2.style.display = 'none';
        x3.style.display = 'none';
        x4.style.display = 'none';
        x5.style.display = 'none';
    } else {
        x1.style.display = 'block';
        x2.style.display = 'block';
        x3.style.display = 'block';
        x4.style.display = 'block';
        x5.style.display = 'block';
    }
}
function ShowElements() {
    ShowInputElement();
    ShowUnits();
}
function ShowUnits2() {
    var x1 = document.getElementById('SixthUnit');
    var x2 = document.getElementById('SeventhUnit');
    var x3 = document.getElementById('EighthUnit');
    var x4 = document.getElementById('NinthUnit');
    var x5 = document.getElementById('TenthUnit');
    var unitsAmount = document.getElementById('UnitDropDown2').value;
    if (unitsAmount === "4") {
        x1.style.display = 'block';
        x2.style.display = 'block';
        x3.style.display = 'block';
        x4.style.display = 'block';
        x5.style.display = 'none';
    } else if (unitsAmount === "3") {
        x1.style.display = 'block';
        x2.style.display = 'block';
        x3.style.display = 'block';
        x4.style.display = 'none';
        x5.style.display = 'none';
    } else if (unitsAmount === "2") {
        x1.style.display = 'block';
        x2.style.display = 'block';
        x3.style.display = 'none';
        x4.style.display = 'none';
        x5.style.display = 'none';
    } else if (unitsAmount === '1') {
        x1.style.display = 'block';
        x2.style.display = 'none';
        x3.style.display = 'none';
        x4.style.display = 'none';
        x5.style.display = 'none';
    } else {
        x1.style.display = 'block';
        x2.style.display = 'block';
        x3.style.display = 'block';
        x4.style.display = 'block';
        x5.style.display = 'block';
    }
}

