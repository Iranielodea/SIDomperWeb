$(function () {
    $("input[data-tipo='cpf']").mask("000.000.000-00");
    $("input[data-tipo='data']").mask("00/00/0000");
    $("input[data-tipo='hora']").mask("00:00");
    $("input[data-tipo='moeda']").mask("000.000.000,00", { reverse: true });
});