
$(window).on("load", function () {
    // Identify what level of presence is selected.
    switch (document.getElementById('form-locationi').value) {
        case "Home":
            selectHome();
            break;
        case "Away":
            selectTravel();
            break;
        default:
            document.getElementById('form-locationi').value = "";
            break;
    }


    // Identify what type of task is selected.
    switch (document.getElementById('form-typei').value) {
        case "Fixed":
            selectFlat();
            break;
        case "Tender":
            selectTender();
            break;
        case "Bounty":
            selectBounty();
            break;
        default:
            document.getElementById('form-typei').value = "";
            break;
    }

    if (document.getElementById("form-costi").value == "0") {
        document.getElementById("form-costi").value == "";
    }
});