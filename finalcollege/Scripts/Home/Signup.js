
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

//phonenumber
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
function checkpasswordc() {
    var password = document.getElementById("Password").value;
    var confirmPassword = document.getElementById("ConfirmPassword").value;
    var errorConPass = document.getElementById("errorconpass");

    if (confirmPassword == "") {
        errorConPass.textContent = "password can't be empty";
        return false;
    }
    else if (password !== confirmPassword) {
        errorConPass.textContent = "Passwords do not match";
    }
    else {
        errorConPass.textContent = "";
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

// State validation
function checkState() {
    var state = document.getElementById("state").value;
    var error = document.getElementById("errorState");

    if (state == "Select a state") {
        error.textContent = "Must select state";
        return false;
    }
    else {
        error.textContent = "";
    }
    return true;
}

function chooseState(state, city) {
    var state1 = document.getElementById(state);
    var city1 = document.getElementById(city);

    city1.innerHTML = "";

    if (state1.value == "tamilnadu") {
        var option = ['chennai|Chennai', 'coimbatore|Coimbatore', 'madurai|Madurai'];
    }

    else if (state1.value == "kerala") {
        var option = ['kochi|Kochi', 'thirissur|Thirissur', 'varkala|Varkala'];
    }

    else if (state1.value == "karnataka")
        var option = ['bangalore|Bangalore', 'mangalore|Mangalore']

    for (var o in option) {
        var split = option[o].split("|");
        var newoption = document.createElement("option");

        newoption.value = split[0];
        newoption.innerHTML = split[1];
        city1.options.add(newoption);
    }
}

 // date of birth
function calculateAge() {
    var dob = new Date(document.getElementById("DateOfBirth").value);
    var today = new Date();
    var age = today.getFullYear() - dob.getFullYear();

    if (
        today.getMonth() < dob.getMonth() ||
        (today.getMonth() === dob.getMonth() && today.getDate() < dob.getDate())
    ) {
        age--;
    }

    var ageField = document.getElementById("Age");
    ageField.value = age;
}
// Age calculation validation
function checkAge() {
    var userinput = document.getElementById("dob").value;
    var error = document.getElementById("dateError");

    var dob = new Date(userinput);
    var today = new Date();
    var result_age = today.getFullYear() - dob.getFullYear();


    var display = document.getElementById('age');
    display.value = result_age;

    return true;
}

//    //fullname validation function
function checkFullName() {
    var firstName = document.getElementById("FullName").value;
    var error = document.getElementById("errorFullname");
    var pattern = /^[A-Za-z]+$/;

    if (firstName == "") {
        error.textContent = "Full name can't be empty";
        return false;
    } else if (!pattern.test(firstName)) {
        error.textContent = "Full name should only contain alphabetic characters";
        return false;
    } else {
        error.textContent = ""; // Clear the error message
    }
    return true;
}

//message
function checkmessage() {
    var address = document.getElementById("message").value;
    var error = document.getElementById("errormessage");

    if (address == "") {
        error.textContent = "Message can't be empty";
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
    check = checkEmail() && check;
    check = checkPassword() && check;
    check = checkpasswordc() && check;
    check = validateGender() && check;
   


    return check;
}

function validate() {
    var check = true;

    check = checkPhonenumber() && check;
    check = checkEmail() && check;
    check = checkPassword() && check;
    check = checkpasswordc() && check;

    return check;
}