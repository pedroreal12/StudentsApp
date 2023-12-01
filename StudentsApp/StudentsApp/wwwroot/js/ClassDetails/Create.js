$(document).ready(function(){
    $.ajax({
        url: '/Teachers/GetTeachers',
        type: 'GET',
        success: function(data) {
            data = JSON.parse(data);
            if (data.length > 0) {
                data.forEach(function(value){
                   $("#selectTeachers").append("<option value=\"" + value.Id + "\">" + value.FirstName + " " + value.LastName + "</option>");
                })
            } else {
                $("#selectTeachers").attr("disabled", true);
                alert("No Teachers were found. Please create teachers so you are able to create new Class Details");
            }
        },
        error: function(error) {
            alert("Error: " + error);
        }
    })
})
