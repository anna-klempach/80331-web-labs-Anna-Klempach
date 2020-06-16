
// Функция формирования одной строки таблицы
// index - порядковый номер
// data - объект данных
function createRow(index, data) {
    // создать строку таблицы
    var row = $("<tr>");
    // добавть колонку с порядковым номером
    row.append("<td>" + index + "</td>");
    // добавить колонку с названием
    row.append("<td>" + data.lootName + "</td>");
    // создать кнопку
    var button = $("<button>")
        .addClass("btn btn-outline-info") // стиль кнопки
        .click(data.lootId, showDetails)
        .text("Details"); // надпись
    // создать колонку с кнопкой
    var td = $("<td>").append(button);
    // добавить в строку таблицы
    row.append(td);
    return row;
}
//Функция выода информации о выбранном объекте
function showDetails(e) {
    // Послать запрос
    $.getJSON(uri + "/" + e.data, function (data) {
        $("#name") // Найти блок для информации
            .empty()
            .text(data.lootName + ":");
        var details = data.lootDescription + " - "
            + data.lootPrice + "$";
        $("#details") // Найти блок для информации
            .empty()
            .text(details); // очистить содержимое.text(details); // записать новый текст
    })
}