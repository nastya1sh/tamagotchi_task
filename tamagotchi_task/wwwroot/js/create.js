function showAnimal() {
    document.getElementById('showAccessories').style.display = "none";
    document.getElementById('showColor').style.display = "none";
    document.getElementById('showWallpaper').style.display = "none";
    document.getElementById('showAnimal').style.display = "block";
}

function showColor() {
    document.getElementById('showAccessories').style.display = "none";
    document.getElementById('showWallpaper').style.display = "none";
    document.getElementById('showAnimal').style.display = "none";
    document.getElementById('showColor').style.display = "block";
}

function showWallpaper() {
    document.getElementById('showAccessories').style.display = "none";
    document.getElementById('showAnimal').style.display = "none";
    document.getElementById('showColor').style.display = "none";
    document.getElementById('showWallpaper').style.display = "block";
}

function showAccessories() {
    document.getElementById('showAnimal').style.display = "none";
    document.getElementById('showColor').style.display = "none";
    document.getElementById('showWallpaper').style.display = "none";
    document.getElementById('showAccessories').style.display = "block";
}

function changeImg(lin){
    var img = document.getElementById("myImg");
    img.src = lin;
    document.getElementById("textImg").innerText = lin;
}

function changeImgWallpaper(lin){
    var img = document.getElementById("myWallpaper");
    img.src=lin;
}

function changeImgAccessories(lin){
    var img = document.getElementById("myAccessories");
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

function dropDown() {
    document.getElementById("myDropdown").classList.toggle("show");
}

window.onclick = function(event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}

function showMessage(lin){
    document.getElementById(lin).style.display = "block";
    setTimeout(()=>lin.hidden = true, 3500);
}
