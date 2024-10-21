
function fetchData() {
    var xhr = new XMLHttpRequest();
    var url = "http://localhost:5279/Employee";

    xhr.open("GET", url, true);

    xhr.onload = function() {
        if (xhr.status >= 200 && xhr.status < 300) {
            var data = JSON.parse(xhr.responseText);
            console.log(data);
            populateGrid(data);
        } else {
            console.error('Request failed with status:', xhr.status);
        }
    };

    xhr.onerror = function() {
        console.error('Network error occurred');
    };

    xhr.send();
}

function populateGrid(data) {
    let gridData = document.getElementById("employeeGrid");
    gridData.innerHTML = ''; 

    data.forEach(employee => {
        gridData.innerHTML += `
            <tr>
                <td>${employee.employeeId}</td>
                <td>${employee.name}</td>
                <td>${employee.phone}</td>
                <td>${employee.salary}</td>
                <td>${employee.position}</td>
                <td>${employee.email}</td>
            </tr>
        `;
    });
}




