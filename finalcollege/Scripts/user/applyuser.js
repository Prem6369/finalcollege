//firstname validation
function checkfirstname() {
    var firstName = document.getElementById("firstname").value;
    var error = document.getElementById("errorfirstname");
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

//lastname validation
function checklastname() {
    var lastname = document.getElementById("lastname").value;
    var error = document.getElementById("errorlastname");
    var pattern = /^[A-Za-z]+$/;

    if (lastname == "") {
        error.textContent = "Last name can't be empty";
        return false;
    } else if (!pattern.test(lastname)) {
        error.textContent = "Last name should only contain alphabetic characters";
        return false;
    } else {
        error.textContent = "";
    }
    return true;
}

// Email validation
function checkEmail() {
    var email = document.getElementById("email").value;
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

//highschoolname
function checkhigh() {
    var highname = document.getElementById("highname").value;
    var error = document.getElementById("errorhighname");
    var pattern = /^[A-Za-z. ]+$/;

    if (highname == "") {
        error.textContent = "Highschoolname can't be empty";
        return false;
    } else if (!pattern.test(highname)) {
        error.textContent = "Highschoolname should contain only letters uppercase ,lowercase";
    }

    else {
        error.textContent = "";
    }
    return true;
}


//highscoolmark
function checkgroup1() {
    var group1 = document.getElementById("group1").value;
    var error = document.getElementById("errorgroup1");
    var pattern = /^[A-Za-z\/{} ]+$/;

    if (group1 == "") {
        error.textContent = "12th group can't be empty";
        return false;
    } else if (!pattern.test(group1)) {
        error.textContent = "12th group should contain only letters uppercase ,lowercase";
        return false;
    }

    else {
        error.textContent = "";
    }
    return true;
}

//12mark
function checkmark1() {
    var mark1 = document.getElementById("mark1").value;
    var error = document.getElementById("errormark1");
    var pattern = /^[0-9]+$/;

    if (mark1 == "") {
        error.textContent = "12th mark can't be empty";
        return false;
    } else if (!pattern.test(mark1)) {
        error.textContent = "12th mark should contain only number";
        return false;
    }

    else {
        error.textContent = "";
    }
    return true;
}


//secondarayschoolname
function checksec() {
    var secondaryname = document.getElementById("sec").value;
    var error = document.getElementById("errorsec");
    var pattern = /^[A-Za-z. ]+$/;

    if (secondaryname == "") {
        error.textContent = "Highschoolname can't be empty";
        return false;
    } else if (!pattern.test(secondaryname)) {
        error.textContent = "Highschoolname should contain only letters uppercase ,lowercase";
        return false;
    }

    else {
        error.textContent = "";
    }
    return true;
}

//10mark
function checkmark2() {
    var mark2 = document.getElementById("mark2").value;
    var error = document.getElementById("errormark2");
    var pattern = /^[0-9]+$/;

    if (mark2 == "") {
        error.textContent = "10th mark can't be empty";
        return false;
    } else if (!pattern.test(mark2)) {
        error.textContent = "10th mark should contain only number";
        return false;
    }

    else {
        error.textContent = "";
    }
    return true;
}

function validateGender() {
    var maleRadio = document.getElementById("maleRadio");
    var femaleRadio = document.getElementById("femaleRadio");
    var othersRadio = document.getElementById("othersRadio");
    var genderError = document.getElementById("genderError");

    if (maleRadio.checked || femaleRadio.checked || othersRadio.checked) {
        genderError.textContent = ""; 
        return true; 
    } else {
        genderError.textContent = "Please select a gender.";
        return false;
    }
}

function validate() {
    var check = true;

    check = checkfirstname() && check;
    check = checklastname() && check;
    check = checkEmail() && check;
    check = checkhigh() && check;
    check = checkgroup1() && check;
    check = checkmark1() && check;
    check = checksec() && check;
    check = checkmark2() && check;
    check = validateGender() && check;

    return check;
}