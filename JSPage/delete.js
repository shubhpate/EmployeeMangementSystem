
fetchData(); 
function fetchData() {
    var xhr = new XMLHttpRequest();
    var url = "http://localhost:5279/Employee";
    xhr.open("GET", url, true);

    xhr.onload = function () {
        if (xhr.status === 200) {
            const data = JSON.parse(xhr.responseText); 
            const employeeGrid = document.getElementById('employeeGrid');
            employeeGrid.innerHTML = ''; 

            data.forEach(employee => {
                const row = document.createElement('tr');
                const checkboxCell = document.createElement('td');
                const checkbox = document.createElement('input');
                checkbox.type = 'checkbox';
                checkbox.className = 'employee-checkbox';
                checkbox.value = employee.id; 
                checkboxCell.appendChild(checkbox);
                row.appendChild(checkboxCell);

                row.innerHTML += `
                    <td>${employee.employeeId}</td>
                    <td>${employee.name}</td>
                    <td>${employee.phone}</td>
                    <td>${employee.salary}</td>
                    <td>${employee.position}</td>
                    <td>${employee.email}</td>
                `;
                
                employeeGrid.appendChild(row);
            });
        } else {
            console.error('Error fetching employee data:', xhr.statusText);
        }
    };

    xhr.onerror = function () {
        console.error('Request failed:', xhr.statusText);
    };

    xhr.send(); 
}

function selectedEmployees() {
    const checkboxes = document.querySelectorAll('.employee-checkbox:checked');
    const selectedValues = [];

    checkboxes.forEach(checkbox => {
        selectedValues.push(checkbox.value); 
    });
     
    return selectedValues;
}

function deleteEmployees() {
    let selectedEmpIds = selectedEmployees(); 
    if (selectedEmpIds.length === 0) {
        alert("No employees selected for deletion.");
        return;
    }
    deleteData(selectedEmpIds); 
    console.log("Selected Employee IDs for deletion:", selectedEmpIds);
}

function deleteData(data) {
    var xhr = new XMLHttpRequest();
    var url = "http://localhost:5279/Employee/" + `${data}`;
    
    xhr.open("DELETE", url, true);
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhr.onload = function() {
        if (xhr.status >= 200 && xhr.status < 300) {
            alert("Data Deleted Succefully");
            window.location.href = "EmployeeDelete.html";
        } else {
            console.error('Request failed with status:', xhr.status);
        }
    };

    xhr.onerror = function() {
        console.error('Network error occurred');
    };

    xhr.send(JSON.stringify(data));
}
