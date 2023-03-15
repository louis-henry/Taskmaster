function ToggleSecurePage() {
    var login = document.getElementById("loginForm");
    var loginSelect = document.getElementById("loginSelect");
    var register = document.getElementById("registerForm");
    var registerSelect = document.getElementById("registerSelect");
    var checkbox = document.getElementById("Register");

    if (login.className == "") {
        login.className = "hidden";
        loginSelect.className = "";
        register.className = "";
        registerSelect.className = "selected";
        checkbox.checked = true;
    } else {
        login.className = "";
        loginSelect.className = "selected";
        register.className = "hidden";
        registerSelect.className = "";
        checkbox.checked = false;
    }
}

