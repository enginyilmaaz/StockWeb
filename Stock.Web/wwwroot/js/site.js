// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('[data-toggle="popover"]').popover({ trigger: "hover" });
});
$('.popover-dismiss').popover({
    trigger: 'focus'
})



$('#deleteModal').on('show.bs.modal', function (e) {
    var dataLink = $(e.relatedTarget).data('link');
    $('#deleteLink').attr('href', dataLink) ;


}); 

$('.form-control-chosen-required').chosen({
    allow_single_deselect: false,
    width: '100%'
});
