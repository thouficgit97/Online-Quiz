async function checkSession() {

    const response = await fetch(`${API_URL}/api/user/session`, {
        method: "GET",
        credentials: "include"
    });

    if (response.ok) {
        window.location.href = "./dashboard.html";
    } else {
        window.location.href = "./login.html";
    }
}
const API_URL = "http://localhost:5002"
checkSession();