function checkdescription() {
    var des = document.getElementById("description").value;
    var error = document.getElementById("errordescription");

    if (des == "") {
        error.textContent = "Description can't be empty";
        return false;
    } else {
        error.textContent = "";
    }
    return true;
}

//duration
function checkduration() {
    var duration = document.getElementById("Duration").value;
    var error = document.getElementById("errorduration");

    if (duration == "") {
        error.textContent = "Duration can't be empty";
        return false;
    }
    else {
        error.textContent = "";
    }
    return true;
}
//duration
function checkprogram() {
    var program = document.getElementById("program").value;
    var error = document.getElementById("errorprogram");

    if (program == "") {
        error.textContent = "Program can't be empty";
        return false;
    }
    else {
        error.textContent = "";
    }
    return true;
}

//coursename
function checkcoursename() {
    var course = document.getElementById("coursename").value;
    var error = document.getElementById("errorcoursename");
    var pattern = /^[A-Za-z() ]+$/;

    if (course == "") {
        error.textContent = "Coursename can't be empty";
        return false;
    } else if (!pattern.test(course)) {
        error.textContent = "Coursename should contain only letters, uppercase, or lowercase.";
        return false;
    } else {
        error.textContent = "";
    }
    return true;
}


    //courseid
function checkcoursid() {
    var id = document.getElementById("courseid").value; // Use "id" instead of "course"
    var error = document.getElementById("errorcourseid");
    var pattern = /^[A-Za-z0-9]+$/;

    if (id == "") {
        error.textContent = "Courseid can't be empty";
        return false;
    } else if (!pattern.test(id)) {
        error.textContent = "Courseid should contain only letters, uppercase, lowercase, and numbers";
        return false;
    } else {
        error.textContent = "";
    }
    return true;
}

function validateForm() {
    var check = true;

    check = checkdescription() && check;
    check = checkduration() && check;
    check = checkprogram() && check;
    check = checkcoursename() && check;
    check = checkcoursid() && check;



    return check;
}

