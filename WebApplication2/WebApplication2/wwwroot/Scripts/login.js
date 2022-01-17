function login() {
    let email = document.getElementById("email").value;
    let pass = document.getElementById("pass").value;
    fetch('../api/user/' + email + "/" + pass)
        .then(response => {
            if (response.ok && response.status==200)
                return response.json();
        })
        .then(data => {
            if (data) {
                window.location.href = "../HTML/helloUser.html";
                sessionStorage.setItem('user', JSON.stringify(data));
            }
            else {
                alert("you need to application")
            }
        })
}

function newUser() {
    window.location.href = "newUser.html";
}

function create() {
    fetch('../api/user', {
        headers: {
            'Content-Type': 'application/json',
        },
        method: 'POST',
        body: JSON.stringify({
            FirstName: document.getElementById("fn").value,
            LastName: document.getElementById("ln").value,
            Email: document.getElementById("ma").value,
            Password: document.getElementById("pw").value,
        }),
    })
        .then(response => response.json())
        .then(data => {
            if (data)
                window.location.href = "homepage.html";
        });
}

function name() {
    document.getElementById("hello").innerHTML = "welcome to: " + JSON.parse(sessionStorage.getItem('user')).firstName;
}

function update() {
    window.location.href = "updateDetails.html"
    
}

function onLoudeUpdateUser() {
    document.getElementById("fnu").value = JSON.parse(sessionStorage.getItem('user')).firstName;
    document.getElementById("lnu").value = JSON.parse(sessionStorage.getItem('user')).lastName;
    document.getElementById("mau").value = JSON.parse(sessionStorage.getItem('user')).email;
    document.getElementById("pwu").value = JSON.parse(sessionStorage.getItem('user')).password;
}

function saveChange() {
    let Userid = JSON.parse(sessionStorage.getItem('user')).userId;
    fetch('../api/user/' + Userid, {
        headers: {
            'Content-Type': 'application/json',
        },
        method: 'PUT',
        body: JSON.stringify({
            FirstName: document.getElementById("fnu").value,
            LastName: document.getElementById("lnu").value,
            Email: document.getElementById("mau").value,
            Password: document.getElementById("pwu").value//s, 
        }),
    })
        .then(response => response.json())
        .then(data => {
            if (data)
                sessionStorage.setItem('user', JSON.stringify(data));
                window.location.href = "helloUser.html";
        });
}