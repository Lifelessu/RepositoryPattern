
//var openEditElement = $('#openEditModalContainer');
//$('.openEditModal').click(function (event) {
//    var url = $(this).data('url');
//    var getUrl = decodeURIComponent(url);

//    openEditElement.empty();

//    $.get(getUrl).done(function (data) {
//        openEditElement.html(data);
//        openEditElement.find('#editModalSeller').modal('show');
//    });
//});

(function ($) {
    var openEditElement = $('#openEditModalContainer');
    $('.openEditModal').click(function (event) {
        var url = $(this).data('url');
        var getUrl = decodeURIComponent(url);

        openEditElement.empty();

        $.get(getUrl).done(function (data) {
            openEditElement.html(data);
            openEditElement.find('#editModalSeller').modal('show');
        });
    });
})(jQuery);