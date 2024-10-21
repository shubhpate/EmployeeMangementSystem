
const employeeGrid = document.getElementById('employeeGrid');
const updateModal = document.getElementById('updateModal');
const saveButton = document.getElementById('saveButton');
const cancelButton = document.getElementById('cancelButton');

// Fetch employee data 
function fetchData() {
        var xhr = new XMLHttpRequest();
        var url = "http://localhost:5279/Employee";
    
        xhr.open("GET", url, true);
    
        xhr.onload = function() {
            if (xhr.status >= 200 && xhr.status < 300) {
                var employees = JSON.parse(xhr.responseText);
                console.log(employees);
                populateTable(employees);
            } else {
                console.error('Request failed with status:', xhr.status);
            }
        };
    
        xhr.onerror = function() {
            console.error('Network error occurred');
        };
    
        xhr.send();
    
  
}

// Populate the employee table
function populateTable(employees) {
    employeeGrid.innerHTML = '';
    employees.forEach(emp => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${emp.id}</td>
            <td>${emp.employeeId}</td>
            <td>${emp.name}</td>
            <td>${emp.phone}</td>
            <td>${emp.salary}</td>
            <td>${emp.position}</td>
            <td>${emp.email}</td>
        `;
        row.addEventListener('click', () => openUpdateModal(emp));
        employeeGrid.appendChild(row);
    });
}

//  update modal with the employees data
function openUpdateModal(emp) {
    document.getElementById('Id').value = emp.id;
    document.getElementById('empId').value = emp.employeeId;
    document.getElementById('empName').value = emp.name;
    document.getElementById('empPhone').value = emp.phone;
    document.getElementById('empSalary').value = emp.salary;
    document.getElementById('empPosition').value = emp.position;
    document.getElementById('empEmail').value = emp.email;
    updateModal.style.display = 'block';
}

// Save updated data 
saveButton.addEventListener('click', () => {
    let id= document.getElementById('Id').value;
    let employeeId= document.getElementById('empId').value;
    let name= document.getElementById('empName').value;
    let phone= document.getElementById('empPhone').value;
    let salary= document.getElementById('empSalary').value;
    let position= document.getElementById('empPosition').value;
    let email= document.getElementById('empEmail').value;

    const data = {
        id:id,
        employeeId : employeeId,
        name : name,
        phone : phone,
        salary : salary,
        position : position,
        email : email
    };
    updateData(id,data);
});

cancelButton.addEventListener('click', () => {
    updateModal.style.display = 'none';
});

function updateData(id,data) {
    var xhr = new XMLHttpRequest();
    var url = "http://localhost:5279/Employee/" + `${id}`;
    
    xhr.open("PUT", url, true);
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhr.onload = function() {
        if (xhr.status >= 200 && xhr.status < 300) {
             alert("Update Data Succefully");
           window.location.href = "EmployeeUpdate.html";
        } else {
            console.error('Request failed with status:', xhr.status);
        }
    };

    xhr.onerror = function() {
        console.error('Network error occurred');
    };

    xhr.send(JSON.stringify(data));
}

fetchData();
