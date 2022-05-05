function showDiv() {
    document.getElementById('box1').style.display = "none";
    document.getElementById('welcomeDiv').style.display = "block";
}

function showAnimal() {
    document.getElementById('showColor').style.display = "none";
    document.getElementById('showAnimal').style.display = "block";
}

function showColor() {
    document.getElementById('showAnimal').style.display = "none";
    document.getElementById('showColor').style.display = "block";
}

function changeImg(lin){
    var img = document.getElementById("myImg");
    img.src=lin;
}