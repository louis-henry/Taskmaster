$(document).ready(function () {

    $(".dropdown").click(function () {

        $(".dropdown-list ul").toggleClass("active");

    });

    /* Select a category */

    $(".dropdown-list ul li").click(function () {

        var icon_text = $(this).html();
        $(".default-option").html(icon_text);

    });

    /* Hide dropdown list when cursor clicked outside searchbar or dropdown list */

    $(document).on("click", function (event) {

        if (!$(event.target).closest(".dropdown").length) {

            $(".dropdown-list ul").removeClass("active")

        }

    });

});