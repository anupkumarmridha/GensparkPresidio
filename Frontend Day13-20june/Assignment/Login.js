// Array of user credentials
const users = [
    { email: 'user1@example.com', password: 'password1' },
    { email: 'user2@example.com', password: 'password2' },
    { email: 'user3@example.com', password: 'password3' }
];

// Function to handle login button click
function  handleLogin(e) {
    e.preventDefault();
    // Get email and password from input fields
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    console.log(email);

    // Find user with matching email
    const user = users.find(user => user.email === email);

    // Check if user exists and password is correct
    if (user && user.password === password) {
        // Successful login
        document.getElementById('demo').innerHTML = 'Login successful!';
    } else {
        // Invalid credentials
        document.getElementById('demo').innerHTML = 'Invalid email or password';
    }
}

// Attach click event listener to login button
document.getElementById('loginBtn').addEventListener('click', (e)=>handleLogin(e));