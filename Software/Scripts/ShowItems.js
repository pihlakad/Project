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

