// Get DOM elements
const fetchUserBtn = document.getElementById('fetchUserBtn');
const userInfo = document.getElementById('userInfo');
const profilePicture = document.getElementById('profilePicture');
const userName = document.getElementById('userName');
const userEmail = document.getElementById('userEmail');
const userLocation = document.getElementById('userLocation');

// Add event listener to button
fetchUserBtn.addEventListener('click', fetchRandomUser);

// Function to fetch random user data
async function fetchRandomUser() {
    try {
        // Show loading state
        fetchUserBtn.textContent = 'Loading...';
        fetchUserBtn.disabled = true;
        
        // Fetch data from Random User API
        const response = await fetch('https://randomuser.me/api/');
        const data = await response.json();
        
        // Extract user data
        const user = data.results[0];
        
        // Display user information
        displayUser(user);
        
    } catch (error) {
        console.error('Error fetching user data:', error);
        alert('Failed to fetch user data. Please try again.');
    } finally {
        // Reset button state
        fetchUserBtn.textContent = 'Get Random User';
        fetchUserBtn.disabled = false;
    }
}

// Function to display user information
function displayUser(user) {
    // Set profile picture
    profilePicture.src = user.picture.large;
    profilePicture.alt = `${user.name.first} ${user.name.last}`;
    
    // Set user details
    userName.innerHTML = `<strong>Name:</strong> ${user.name.title} ${user.name.first} ${user.name.last}`;
    userEmail.innerHTML = `<strong>Email:</strong> ${user.email}`;
    userLocation.innerHTML = `<strong>Location:</strong> ${user.location.city}, ${user.location.country}`;
    
    // Show user info div
    userInfo.style.display = 'block';
    
    // Log to console as well
    console.log('Random User Data:', user);
}

// Alternative implementation using .then() method
function fetchRandomUserWithThen() {
    fetchUserBtn.textContent = 'Loading...';
    fetchUserBtn.disabled = true;
    
    fetch('https://randomuser.me/api/')
        .then(response => response.json())
        .then(data => {
            const user = data.results[0];
            displayUser(user);
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Failed to fetch user data. Please try again.');
        })
        .finally(() => {
            fetchUserBtn.textContent = 'Get Random User';
            fetchUserBtn.disabled = false;
        });
}
