$(document).ready(function(){
    var url = window.location.href;
    url = url.split("/");
    Id = url[5];

    $.ajax({
        url: '/Classes/GetClassById/' + Id,
        type: 'GET',
        success: function(data) {
            data = JSON.parse(data);
            if (data.length > 0) {
                $("#valueStudents").append("<label>" + data[0].FirstName + " " + data[0].LastName + "</label>");
                $("#valueClassDetail").append("<label>" + data[0].classDetailName + "</label>");
            }
        },
        error: function(error) {
            alert("Error: " + error);
        }
    });

    $("#btnEdit").click(function(){
        event.preventDefault();
        window.location.href = "/ClassDetails/Edit/" + Id
    });
});
