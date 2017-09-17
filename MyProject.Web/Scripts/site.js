$(document).ready(function () {
    $(".autohide").fadeTo(10000, 1000).slideUp(500, function () {
        $(".autohide").fadeOut(100);
    });
});