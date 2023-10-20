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