(function() {

    window.addEventListener('load', () => {
        AOS.init({
            duration: 1000,
            easing: 'ease-in-out',
            once: true,
            mirror: false
        })
    });
})()

/* $(document).on("click", ".navbar-right .dropdown-menu",function(e){
    e.stopPropagation();
}); */

var login = document.getElementById('login');
var register = document.getElementById('register');
var btn = document.getElementById('btn');

function registered() {
    login.style.left = "-400px";
    register.style.left = "50px";
    btn.style.left="110px";
}

function logined(){
    login.style.left ="50px";
    register.style.left ="450px";
    btn.style.left="0";
}