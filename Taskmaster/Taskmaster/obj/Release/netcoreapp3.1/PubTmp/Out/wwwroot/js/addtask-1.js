function focusLocation(btnId) {
    var all = document.getElementsByClassName('addtask-where-btn');
    for (var i = 0; i < all.length; i++) {
        all[i].style.color = "white";
        all[i].style.border = "solid 2px white";
    }
    document.getElementById(btnId).style.border = "solid 2px orange";
    document.getElementById(btnId).style.color = "#ffa500";
}

function focusType(btnId) {
    var all = document.getElementsByClassName('addtask-type-btn');
    for (var i = 0; i < all.length; i++) {
        all[i].style.color = "white";
        all[i].style.border = "solid 2px white";
    }
    document.getElementById(btnId).style.border = "solid 2px orange";
    document.getElementById(btnId).style.color = "#ffa500";
}

function enablePostCode(possible) {
    if (possible != true) {
        document.getElementById("form-pc").style.background = "#9e9e9e";
    } else {
        document.getElementById("form-pc").style.background = "transparent";
    }
    document.getElementById("form-pci").readOnly = possible;
}

function enablePrice(possible) {
    if (possible != true) {
        document.getElementById("form-cost").style.background = "#9e9e9e";
    } else {
        document.getElementById("form-cost").style.background = "transparent";
    }
    document.getElementById("form-costi").readOnly = possible;
    document.getElementById("form-costi").required = !possible;
}

function selectHome() {
    enablePostCode(true);
    focusLocation("btn-home");
    document.getElementById('form-locationi').value = "Home";
}

function selectTravel() {
    enablePostCode(false);
    focusLocation("btn-travel");
    document.getElementById('form-locationi').value = "Away";
}

function selectFlat() {
    enablePrice(false);
    focusType("btn-flat");
    document.getElementById('form-typei').value = "Fixed";
}

function selectTender() {
    enablePrice(false);
    focusType("btn-tender");
    document.getElementById('form-typei').value = "Tender";
}

function selectBounty() {
    enablePrice(false);
    focusType("btn-bounty");
    document.getElementById('form-typei').value = "Bounty";
}

function selectOther() {
    enablePrice(true);
    focusType("btn-other");
    document.getElementById('form-typei').value = "Other";
}
const selected = document.querySelector(".selected");
const optionsContainer = document.querySelector(".options-container");
const formValue = document.getElementById("form-catagoryi");

const optionsList = document.querySelectorAll(".option");
/*
selected.addEventListener("click", () => {
    optionsContainer.classList.toggle("active");
});
*/
optionsList.forEach(o => {
    o.addEventListener("click", () => {
        selected.innerHTML = o.querySelector("label").innerHTML;
        optionsContainer.classList.remove("active");
        formValue.value = o.querySelector("label").innerHTML;
        console.log(formValue.value);
    });
});
