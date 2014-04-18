$(document).ready(function () {

//    $('#slow').show("slow");
//    $('#ms').show(1500);
//    $('#fast').show("fast");
    $('#toggle').on('click', function () {
        //$('#toggled').toggle("slow");
        $('#toggled').slideToggle("slow");
    });

    $('#slow').fadeIn("slow");
    $('#ms').fadeIn(4500);
    $('#fast').fadeIn("fast");


});

$(document).ready(function () {
    $('dt').on('click', function () {
        $(this).next().slideToggle();
    })

});



//===============================================
//Ajax stuff pgs 68 onwards on his notes

//$(document).ready(function () {
//    //step 1 : $.ajax({});
//    $.ajax({
//        "url": "book.txt",
//        "success": function (data) {
//            //alert(data);
//        }
//    });
//});

$(document).ready(function () {
    $('#ajaxbtn').on('click', outputText); //returns a text file from the server
    $('#jsonBtn').on('click', jsonBtn); //returns the json object
    //$('#ajaxdataservice').on('click', retrieveDataFromdataService);
});



function outputText() {
    $.ajax({
        "url": "book.txt", //a text file on the server
        "success": function (data) {
            $('#result').html(data);
           // alert(data);
        }
    });
}

//Below is a method handling a json object from the server
var content = "";
function jsonBtn() {
    $.ajax({
        "url": "book.json",
        "success": function (data) {
            var dataObj = JSON.parse(data);
            content += "Title: " + dataObj.title + "<br>";
            content += "Author: " + dataObj.author + "<br>";
            content += "Year: " + dataObj.year + "<br>";
            
            $('#result').html(content);

        }
    });

}

