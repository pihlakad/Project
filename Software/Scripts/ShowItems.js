function ShowInputElement() {
    var x = document.getElementById('SecondQuantity');
    var c = document.getElementById('OperationDropDown').value;
    if (c !== "Round")
        x.style.display = 'block';
    else x.style.display = 'none';
}
function ShowResult() {
    var x = document.getElementById('ResultLabel');
    x.style.display = 'block';    
}

function CheckItems() {
    ShowInputElement();
    var x = document.getElementById('ResultLabel');
    if (x.Value === "Result : 0")
        x.style.display = 'none';
    else x.style.display = 'block';
}