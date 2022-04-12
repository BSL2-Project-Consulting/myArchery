//toggle switch view
var imputswitch = document.getElementById("lol-checkbox");
var targets = document.getElementById("targets");
var ranking = document.getElementById("ranking");

imputswitch.addEventListener('change',function(){
    if(imputswitch.checked && ranking.style.display === "none") {
        targets.style.display = "none";
        ranking.style.display = "block";
    } else {
        targets.style.display = "block";
        ranking.style.display = "none";
    }
});