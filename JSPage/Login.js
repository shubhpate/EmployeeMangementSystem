
document.getElementById('loginForm').addEventListener('submit', function(event) {
    event.preventDefault();
    
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
     
    var xhr = new XMLHttpRequest();
    var url =  "http://localhost:5279/Login";
xhr.open('POST', url, true);
xhr.setRequestHeader('Content-Type', 'application/json');

xhr.onload = function() {
    if (xhr.status >= 200 && xhr.status < 300) {
        var data = JSON.parse(xhr.responseText);
        localStorage.setItem('token', data.token);
        alert('Login successful!');
        window.location.href = 'EmployeeDetail.html';
    } else {
        alert('Login failed');
    }
};

xhr.onerror = function() {
    alert('An error occurred during the transaction');
};

var requestBody = JSON.stringify({ username: username, password: password });
xhr.send(requestBody);

});
