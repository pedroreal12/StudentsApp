const studentsPerPage = 10;
var lastClicked = 1;

$(document).ready(function () {
    $.ajax({
        url: '/Students/GetStudents',
        type: 'GET',
        success: function (data) {
            if (data.length > 0 && data.IsArray) {
                resetTable(data);
            } else {
                alert("No Students");
            }
        },
        error: function (error) {
            alert("Error: " + error);
        }
    });

});

function resetTable(data, currentPage = 1) {
    $("#body-table>*").remove()
    tableHTML = '';
    var startIndex = (currentPage - 1) * studentsPerPage;
    var endIndex = startIndex + studentsPerPage;

    for (index = startIndex; index < endIndex; index++) {
        tableHTML += "<tr>";
        var dataObj = data[index];
        for (var eachValue in dataObj) {
            tableHTML += "<td>" + dataObj[eachValue] + "</td>";
        }
        tableHTML += "</tr>";
    }

    $("#body-table").append(tableHTML);
    $("#foot-table>*").remove();
    qnt = data.length / studentsPerPage;

    btnsHTML = '<td><button class="btnControls" id="btnPrevious" onclick="previous()">Previous</button>';

    for (i = 1; i <= qnt; i++) {
        btnsHTML += '<button class="btnControls" onclick="pagination(this.textContent)">' + i + '</button>';
    }

    btnsHTML += '<button class="btnControls" id="btnNext" onclick="next()">Next</button></td>';

    $("#foot-table").append(btnsHTML);
}

function pagination(currentPage) {
    lastClicked = parseInt(currentPage);
    resetTable(data, currentPage);
}

function next() {
    var maxPagination = data.length / studentsPerPage;
    if (lastClicked < maxPagination) {
        lastClicked += 1;
    }

    resetTable(data, lastClicked);
}

function previous() {
    if (lastClicked > 1) {
        lastClicked -= 1;
    }

    resetTable(data, lastClicked);
}

function getSearch() {
    input = $("#inpSearch").val();

    results = [];

    data.forEach(function (value) {
        if (value.firstName.search(input) != -1 || value.lastName.search(input) != -1) {
            results.push(value);
        }
    });

    if (results.length == 0) {
        alert("Não foram encontrados resultados.");
        resetTable(data);
        currentPage = 1;
    } else {
        resetTable(results);
        currentPage = 1;
    }
}