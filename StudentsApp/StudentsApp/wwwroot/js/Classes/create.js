$(document).ready(function(){
    $.ajax({
        url: '/Students/GetStudents',
        type: 'GET',
        success: function(data) {
            data = JSON.parse(data);
            if (data.length > 0) {
                data.forEach(function(value){
                   $("#selectStudents").append("<option value=\"" + value.Id + "\">" + value.FirstName + " " + value.LastName + "</option>");
                })
            } else {
                $("#selectStudents").attr("disabled", true);
                alert("No Students were found. Please create students so you are able to create a new Class");
            }
        },
        error: function(error) {
            alert("Error: " + error);
        }
    })
    $.ajax({
        url: '/ClassDetails/GetClassDetails',
        type: 'GET',
        success: function(data) {
            data = JSON.parse(data);
            if (data.length > 0) {
                data.forEach(function(value){
                   $("#selectClassDetails").append("<option value=\"" + value.Id + "\">" + value.FirstName + " " + value.LastName + "</option>");
                })
            } else {
                $("#selectClassDetails").attr("disabled", true);
                alert("No Class Details were found. Please create class details so you are able to create a new Class");
            }
        },
        error: function(error) {
            alert("Error: " + error);
        }
    })
})
