$('input[filter-for]').keyup(function () {
    var value = $(this).val();
    $('#' + $(this).attr('filter-for')).children().each(function () {
        $(this).toggle($(this).text().indexOf(value) > -1);
    });
});