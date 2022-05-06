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

function showTag() {
    document.getElementById('taginput').style.display = "block";
}

function hideTag() {
    document.getElementById('taginput').style.display = "none";
}

function showDifficulty() {
    document.getElementById('difficultyinput').style.display = "block";
}

function hideDifficulty() {
    document.getElementById('difficultyinput').style.display = "none";
}

function showDate() {
    document.getElementById('dateinput').style.display = "block";
}

function hideDate() {
    document.getElementById('dateinput').style.display = "none";
}
