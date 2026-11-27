async function register() {
  var usernameError = usernameValidation();

  var errorMessage = document.getElementById("register-form-error-message");

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
  var response = await fetch(`${API_BASE_URL}/api/user/register`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      username: document.getElementById("register-form-username").value.trim(),
      password: document.getElementById("register-form-password").value,
    }),
  });

 
    if (response.ok)
    {
        alert("ok");
    }
    else
    {
        alert("shit!!!...");
    }
}

function passwordValidation() {
  //minimum 8 letters ,atleast 1 capital letter,atleast 1 small letter ,atleast one number and one speacial character
  var errormessage = "";
  var pwd1 = document.getElementById("register-form-password").value;
  var pwd2 = document.getElementById("register-form-repeat-password").value;
  var ispassed = true;
  if (pwd1 == "" || pwd2 == "") {
    errormessage = "Password is required";
    ispassed = false;
  } else if (pwd1.length < 8) {
    errormessage = "Password should be minimum 8 characters";
    ispassed = false;
  } else if (!/[A-Z]/.test(pwd1)) {
    errormessage = "Password should contain atleast one capital letter";
    ispassed = false;
  } else if (!/[a-z]/.test(pwd1)) {
    errormessage = "Password should contain atleast one small letter";
    ispassed = false;
  } else if (!/[0-9]/.test(pwd1)) {
    errormessage = "Password should contain atleast one number";
    ispassed = false;
  } else if (!/[^A-Za-z0-9]/.test(pwd1)) {
    errormessage = "Password should contain atleast one special character";
    ispassed = false;
  } else if (pwd1 != pwd2) {
    errormessage = "Passwords do not match";
    ispassed = false;
  }
  if (!ispassed) {
    document.getElementById("register-form-error-message").textContent =
      errormessage;
  }
  return ispassed;
}
function usernameValidation() {
  //username should not contain capital letter
  var errormessage = "";
  var username = document.getElementById("register-form-username").value.trim();
  var ispassed = true;
  if (username == "") {
    console.log("username is empty" + username);
    errormessage = "Username is required";
    ispassed = false;
  } else if (username != username.toLowerCase()) {
    console.log("username contains capital letters" + username);
    errormessage = "Username should not contain capital letters";
    ispassed = false;
  }
  if (!ispassed) {
    document.getElementById("register-form-error-message").textContent =
      errormessage;
  }
  return ispassed;
}
function clearForm() {
  console.log("clear called");
  document.getElementById("register-form-username").value = "";
  document.getElementById("register-form-password").value = "";
  document.getElementById("register-form-repeat-password").value = "";
  document.getElementById("register-form-error-message").style.display = "none";
}

API_BASE_URL = "http://127.0.0.1:5002";
