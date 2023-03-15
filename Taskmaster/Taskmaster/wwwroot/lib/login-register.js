function register() {

    var x = document.getElementById("secureLogin");
    var y = document.getElementById("secureRegister");
    var z = document.getElementById("login-or-register");
    var checkbox = document.getElementById("Register");

    // Positional Change
    x.style.left = "-400px";
    y.style.left = "50px";
    z.style.left = "110px";
    checkbox.checked = true;
}
function login() {

    var x = document.getElementById("secureLogin");
    var y = document.getElementById("secureRegister");
    var z = document.getElementById("login-or-register");
    var checkbox = document.getElementById("Register");

    // Positional Change
    x.style.left = "50px";
    y.style.left = "450px";
    z.style.left = "0";
    checkbox.checked = false;
}

function toggleHelp() {
    var isVisible = document.getElementById("form-help-box").style.visibility

    if (isVisible != "hidden") {
        document.getElementById("form-help-box").style.visibility = "hidden";
    } else {
        document.getElementById("form-help-box").style.visibility = "visible";
    }
}