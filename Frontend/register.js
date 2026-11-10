
async function register() {
    var usernameError = usernameValidation();

    var errorMessage = document.getElementById("error-message");

    if (!usernameError) {
        errorMessage.style.display = "block";
        return;
    }
    var passwordError = passwordValidation();

    if (!passwordError) {
        errorMessage.style.display = "block";
        return;
    }

    errorMessage.style.display = "none";

    // Both validations passed. Continue registration.
    var response = await fetch(`${API_BASE_URL}/api/User/Register`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            username: document.getElementById("uname").value.trim(),
            password: document.getElementById("pwd1").value
        })
    });

    response.then(function (data) {
        if (data.ok) {
            redirectToLogin();
        } else {
            errorMessage.style.display = "block";
        }
    });
}
function redirectToLogin()
{
    window.location.href = "Login.html";
}

function redirectToRegister()
{

    window.location.href = "Register.html";
}

function passwordValidation()
{
    //minimum 8 letters ,atleast 1 capital letter,atleast 1 small letter ,atleast one number and one speacial character
    var errormessage = "";
    var pwd1 = document.getElementById("pwd1").value;
    var pwd2 = document.getElementById("pwd2").value;
    var ispassed = true;
    if(pwd1 == "" || pwd2 == "")
    {
        errormessage = "Password is required";
        ispassed = false;
    }
    else if(pwd1.length < 8)
    {
        errormessage = "Password should be minimum 8 characters";
        ispassed = false;       
    }
    else if(!/[A-Z]/.test(pwd1))
    {
        errormessage = "Password should contain atleast one capital letter";
        ispassed = false;
    }
    else if(!/[a-z]/.test(pwd1))
    {
        errormessage = "Password should contain atleast one small letter";
        ispassed = false;
    }
    else if(!/[0-9]/.test(pwd1))
    {
        errormessage = "Password should contain atleast one number";
        ispassed = false;   
    }
    else if(!/[^A-Za-z0-9]/.test(pwd1))
    {
        errormessage = "Password should contain atleast one special character";
        ispassed = false;
    }
    else if(pwd1 != pwd2)
    {
        errormessage = "Passwords do not match";
        ispassed = false;
    }
    if(!ispassed)
    {
        document.getElementById("error-message").textContent = errormessage;
    }
    return ispassed;
}
function usernameValidation()
{
    //username should not contain capital letter
    var errormessage = "";
    var username = document.getElementById("uname").value.trim();
    var ispassed = true;
    if(username == "")
    {
        console.log("username is empty" + username);
        errormessage = "Username is required";
        ispassed = false;
    }
    else if(username != username.toLowerCase())
    {
        console.log("username contains capital letters" + username);
        errormessage = "Username should not contain capital letters";
        ispassed = false;
    }
    if(!ispassed)
    {
        document.getElementById("error-message").textContent = errormessage;
    }
    return ispassed;
}
function clearForm()
{
    console.log("clear called");
    document.getElementById("uname").value = "";
    document.getElementById("pwd1").value = "";
    document.getElementById("pwd2").value = "";
    document.getElementById("error-message").style.display = "none";
}

API_BASE_URL = "http://localhost:5002";