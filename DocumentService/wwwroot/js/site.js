$(function () {
    $('input[filter-for]').keyup(function () {
        var value = $(this).val();
        $('#' + $(this).attr('filter-for')).children().each(function () {
            $(this).toggle($(this).text().indexOf(value) > -1);
        });
    });

    $(".sortable").sortable({
        revert: true,
        connectWith: ".sortable",
        stop: function (event, ui) {
            $(this).find('.sortable-order').each(function (index, item) {
                $(item).val(index);
            });
        }
    });

    $(".sortable").disableSelection();
});

