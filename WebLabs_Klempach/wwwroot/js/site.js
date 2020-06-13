$(document).ready(function () {
    $(".page-link").click(function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
        $("#list").load(url);
        $(".active").removeClass("active");
        var p = $(this).parent().addClass("active");
        history.pushState(null, null, url);
    });
});
