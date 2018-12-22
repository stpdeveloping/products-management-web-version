$(document).ready(function () {
    $("li").click(function () {
        $("li").removeClass("is-active");
        $(this).addClass("is-active");
    });
});