// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//Not working, change active state of navbar.

document.getElementById("navbar-home-link").addEventListener("click", function (event) {
    document.getElementById("navbar-home").classList.add("active")
    document.getElementById("navbar-players").classList.remove("active")
    document.getElementById("navbar-free-agency").classList.remove("active")
});

document.getElementById("navbar-players-link").addEventListener("click", function (event) {
    document.getElementById("navbar-home").classList.remove("active")
    document.getElementById("navbar-players").classList.add("active")
    document.getElementById("navbar-free-agency").classList.remove("active")
});

document.getElementById("navbar-free-agency-link").addEventListener("click", function (event) {
    document.getElementById("navbar-home").classList.remove("active")
    document.getElementById("navbar-players").classList.remove("active")
    document.getElementById("navbar-free-agency").classList.add("active")
});