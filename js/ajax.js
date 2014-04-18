/////////////////////////////////////////////////////////////////////
//His Ajax Notes on HTTP Handler
$(document).ready(function () {
    $('#ajaxdataservice').on('click', retrieveDataFromdataService);

});

function retrieveDataFromdataService() {
    var title = $('#txtTitle').val();
    var url = "http://localhost:51252/AnimationWithVisualStudio/DataService.ashx?title=" + title; //this is the josn object displayed

    $.ajax({
        "url": url,
        "success": function (data) {
            var books = JSON.parse(data);
            var dataDisplay = "";
            for (i = 0; i < books.length; i++) {
                dataDisplay += "Title: " + books[i].title + "<br>";
                //dataDisplay += "Publisher " + books[i].publisher + "<br>";
                //dataDisplay += "Publication Year " + books[i].publicationYear + "<br>";
                dataDisplay += "Price " + books[i].price + "<br>";
                dataDisplay += "<hr>";
            }
            $('#resultAjax').html(dataDisplay);
        }
    });

}