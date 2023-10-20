//description
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

//program
function checkprogram() {
    var program = document.getElementById("program").value;
    var error = document.getElementById("errorprogram");
    var pattern = /^[A-Z]+$/;

    if (program == "") {
        error.textContent = "Program can't be empty";
        return false;
    } else if (!pattern.test(program)) {
        error.textContent = "Progrm should contain only uppercase letters";
    }

    else {
        error.textContent = "";
    }
    return true;
}
//duration
function checkduration() {
    var duration = document.getElementById("Duration").value;
    var error = document.getElementById("errorduration");
    var pattern = /^[A-Za-z0-9]+$/;

    if (program == "") {
        error.textContent = "Duration can't be empty";
        return false;
    } else if (!pattern.test(duration)) {
        error.textContent = "Duration should contain only letters uppercase ,lowercase and numbers";
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
    var pattern = /^[A-Za-z!@#$()]+$/;

    if (program == "") {
        error.textContent = "Duration can't be empty";
        return false;
    } else if (!pattern.test(course)) {
        error.textContent = "Coursename contain only letters uppercase ,lowercase ";
    }
    else {
        error.textContent = "";
    }
    return true;
}