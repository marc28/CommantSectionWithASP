$(document).ready(function () {

    retrieveCommentsAjax();
});

/**

1. Make two ajax function, 1 on page load, the other for the click of a button




*/


//Adding comments with a click!!
$('#btnComment').on('click', insertCommentsAjax);
function insertCommentsAjax() {
    var name = $('#txtName').val();
    var comment = $('#txtComment').val();


    if (name == "" && comment == "") {
        $('#error').html("Error");
    } else {
        $('#error').html("");
        var url = "./InsertComment.ashx?name=" + name + "&comment=" + comment; //this is the josn object displayed
        $.ajax({
            "url": url,
            "success": function (data) {
                //alert("success")

                $('#resultAjax').prepend(
                "Name: " + name + "<br>" +
                "Comments: " + comment + "<br>" +
                "<hr>").hide().show(1500);
                $('#txtName').val("");
                $('#txtComment').val("");
            }
        });
    }
}



//On Page Load!!!!
function retrieveCommentsAjax() {

        var url = "./InsertComment.ashx"; //this is the josn object displayed
        $.ajax({
            "url": url,
            "success": function (data) {
                var comments = JSON.parse(data);
                var dataDisplay = "";
                for (i = comments.length - 1; i >= 0; i--) {
                    dataDisplay +="<div id='resultsDiv'>"
                    dataDisplay += "Name: " + comments[i].name + "<br>";
                    dataDisplay += "Comments: " + comments[i].comments + "<br>";
                    dataDisplay += "<hr>";
                    dataDisplay += "</div>"
                }
                $('#resultAjax').html(dataDisplay);
            }
        });
    

}
