//firstname
function checkFirstName() {
    var firstName = document.getElementById("FirstName").value;
    var error = document.getElementById("errorFirstname");
    var pattern = /^[A-Za-z]+$/;

    if (firstName == "") {
        error.textContent = "First name can't be empty";
        return false;
    } else if (!pattern.test(firstName)) {
        error.textContent = "First name should only contain alphabetic characters";
        return false;
    } else {
        error.textContent = "";
    }
    return true;
}

//lastname
function checkLastname() {
    var lastName = document.getElementById("Lastname").value;
    var error = document.getElementById("errorLastname");
    var pattern = /^[A-Za-z]+$/;

    if (lastName == "") {
        error.textContent = "Last name can't be empty";
        return false;
    } else if (!pattern.test(lastName)) {
        error.textContent = "Last name should only contain alphabetic characters";
        return false;
    } else {
        error.textContent = "";
    }
    return true;
}
function checkPhonenumber() {
    var Phonenumber = document.getElementById("PhoneNumber").value;
    var error = document.getElementById("errorphonenumber");
    var pattern = /^[0-9]+$/;
    var pattern2 = /^\d{10}$/;

    if (Phonenumber === "") {
        error.textContent = "Phone number can't be empty";
        return false;
    } else if (!pattern.test(Phonenumber)) {
        error.textContent = "Phone number should contain only numeric digits";
        return false;
    } else if (!pattern2.test(Phonenumber)) {
        error.textContent = "Phone number should contain only ten number";
        return false;
    }
    else {
        error.textContent = "";
    }
    return true;
}

//address
function checkaddress() {
    var address = document.getElementById("Address").value;
    var error = document.getElementById("erroraddress");

    if (address == "") {
        error.textContent = "Address can't be empty";
        return false;
    } else {
        error.textContent = "";
    }
    return true;
}
// Email validation
function checkEmail() {
    var email = document.getElementById("Email").value;
    var error = document.getElementById("erroremail");
    var pattern = /[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

    if (email == "") {
        error.textContent = "Email can't be empty";
        return false;
    }
    else if (!pattern.test(email)) {
        error.textContent = "Enter valid e-mail address";
        return false;
    }
    else {
        error.textContent = "";
    }
    return true;
}

function checkPassword() {
    var password = document.getElementById("Password").value;
    var error = document.getElementById("errorpass");
    var patternLength = /^.{8,16}$/;
    var patternSpecialChar = /[!@#$%^&*]/;
    var patternNumber = /[0-9]/;
    var patternUpperCase = /[A-Z]/;
    var patternLowerCase = /[a-z]/;

    if (password.trim() === "") {
        error.textContent = "Password can't be empty";
        return false;
    } else if (!patternLength.test(password)) {
        error.textContent = "Password should be between 8 and 16 characters";
        return false;
    } else if (!patternSpecialChar.test(password)) {
        error.textContent = "Password should contain at least one special character";
        return false;
    } else if (!patternNumber.test(password)) {
        error.textContent = "Password should contain at least one number";
        return false;
    } else if (!patternUpperCase.test(password)) {
        error.textContent = "Password should contain at least one uppercase character";
        return false;
    } else if (!patternLowerCase.test(password)) {
        error.textContent = "Password should contain at least one lowercase character";
        return false;
    } else {
        error.textContent = "";
    }
    return true;
}


function validateForm() {
    var check = true;

    check = checkFirstName() && check;
    check = checkLastname() && check;
    check = checkPhonenumber() && check;
    check = checkaddress() && check;
    check = checkPassword() && check;



    return check;
}