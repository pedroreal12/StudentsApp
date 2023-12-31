﻿const studentsPerPage = 10;
var lastClicked = 1;
var tableData = [];
$(document).ready(function () {
    $.ajax({
        url: '/Students/GetStudents',
        type: 'GET',
        success: function (data) {
            data = JSON.parse(data);
            if (data.length > 0) {
                resetTable(data);
                tableData = data;

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
        if (data[index] !== undefined){
            var dataObj = data[index];
        } else {
            break;
        }
        for (var eachValue in dataObj) {
            tableHTML += "<td>" + dataObj[eachValue] + "</td>";
        }
        tableHTML += "<td><a href='Students/Details/" + dataObj.Id + "'>Details</a></td>";
        tableHTML += "<td><a href='Students/Edit/" + dataObj.Id + "'>Edit</a></td>";
        tableHTML += "<td><a href='Students/Delete/" + dataObj.Id + "'>Delete</a></td>";
        tableHTML += "</tr>";
    }

    $("#body-table").append(tableHTML);
    $("#foot-table>*").remove();
    qnt = data.length / studentsPerPage;
    qnt = data.length % qnt > 0 ? qnt + 1 : qnt

    btnsHTML = '<td><button class="btnControls" id="btnPrevious" onclick="previous()">Previous</button>';

    for (i = 1; i <= qnt; i++) {
        btnsHTML += '<button class="btnControls" onclick="pagination(this.textContent)">' + i + '</button>';
    }

    btnsHTML += '<button class="btnControls" id="btnNext" onclick="next()">Next</button></td>';

    $("#foot-table").append(btnsHTML);
}

function pagination(currentPage) {
    lastClicked = parseInt(currentPage);
    resetTable(tableData, currentPage);
}

function next() {
    var maxPagination = tableData.length / studentsPerPage;
    if (lastClicked < maxPagination) {
        lastClicked += 1;
    }

    resetTable(tableData, lastClicked);
}

function previous() {
    if (lastClicked > 1) {
        lastClicked -= 1;
    }

    resetTable(tableData, lastClicked);
}

function getSearch() {
    input = $("#inpSearch").val();

    results = [];

    tableData.forEach(function(obj) {
        $.each(obj, function(index) {
            if(obj[index] == input){
                results.push(obj);
            }
        });
    });

    if (results.length == 0) {
        alert("Não foram encontrados resultados.");
        resetTable(tableData);
        currentPage = 1;
    } else {
        resetTable(results);
        currentPage = 1;
    }
}
