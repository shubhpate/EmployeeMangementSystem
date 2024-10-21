{/* <form id="form"></form>
<form id="form"></form> */}
let submit = document.getElementById("Submit");

submit.addEventListener('click', (event) => {
    let employeeId = document.getElementById("employeeId").value;
    let name = document.getElementById("name").value;
    let email = document.getElementById("email").value;
    let phone = document.getElementById("phone").value;
    let position = document.getElementById("position").value;
    let salary = document.getElementById("salary").value;

    const data = {
        employeeId: employeeId,
        name : name,
        email : email,
        phone : phone,
        position : position,
        salary : salary
    }
    saveData(data);
});
    
    function saveData(data) {
        var xhr = new XMLHttpRequest();
        var url = "http://localhost:5279/Employee/AddEmployee";
    
        xhr.open("POST", url, true);
        xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
        xhr.onload = function() {
            if (xhr.status >= 200 && xhr.status < 300) {
                var data = JSON.parse(xhr.responseText);
                alert("New Employee Created Succefully");
                window.location.href = "EmployeeDetail.html";
            } else {
                console.error('Request failed with status:', xhr.status);
            }
        };
    
        xhr.onerror = function() {
            console.error('Network error occurred');
        };
    
        xhr.send(JSON.stringify(data));
    }
    
