// Current user data
var currentUser = {
    name: "Spring Student",
    id: "ST2024001",
    class: "10th Grade",
    email: "john.doe@springflowers.edu"
};

// Initialize when page loads
document.addEventListener('DOMContentLoaded', function() {
    showDashboard();
    setupMobileMenu();
});

// Navigation functions
function showDashboard() {
    hideAllSections();
    document.getElementById('dashboard').style.display = 'block';
    updateActiveNav('dashboard');
}

function showProfile() {
    hideAllSections();
    document.getElementById('profile').style.display = 'block';  
    updateActiveNav('profile');
}

function showTimeTable() {
    hideAllSections();
    document.getElementById('timetable').style.display = 'block';
    updateActiveNav('timetable');
    highlightCurrentClass();
}

function showGrades() {
    alert('Grades section is under development');
}

function showAttendance() {
    alert('Attendance section is under development'); 
}

function logout() {
    var confirmLogout = confirm('Are you sure you want to logout?');
    if (confirmLogout) {
        alert('You have been logged out');
        // Redirect would happen here in real app
        location.reload();
    }
}

// Helper functions
function hideAllSections() {
    var sections = document.querySelectorAll('.content-section');
    for (var i = 0; i < sections.length; i++) {
        sections[i].style.display = 'none';
    }
}

function updateActiveNav(section) {
    // Remove active state from all nav links
    var navLinks = document.querySelectorAll('.sidebar .nav-link');
    for (var i = 0; i < navLinks.length; i++) {
        navLinks[i].classList.remove('active');
    }
    
    // Add some basic visual feedback
    var currentNav = document.querySelector('.sidebar .nav-link[onclick*="' + section + '"]');
    if (currentNav) {
        currentNav.style.backgroundColor = '#f8f9fa';
        setTimeout(function() {
            currentNav.style.backgroundColor = '';
        }, 200);
    }
}

// TimeTable highlighting  
function highlightCurrentClass() {
    var now = new Date();
    var currentHour = now.getHours();
    var currentMinute = now.getMinutes();
    
    // Basic time checking - could be improved
    var timeSlots = [
        {start: 8, end: 9},
        {start: 9, end: 10}, 
        {start: 10.25, end: 11.25},
        {start: 11.25, end: 12.25},
        {start: 13, end: 14},
        {start: 14, end: 15}
    ];
    
    var currentTime = currentHour + (currentMinute / 60);
    
    for (var i = 0; i < timeSlots.length; i++) {
        if (currentTime >= timeSlots[i].start && currentTime < timeSlots[i].end) {
            var rows = document.querySelectorAll('.timetable-table tbody tr');
            var actualRows = [0, 1, 3, 4, 6, 7]; // Skip break rows
            
            if (actualRows.indexOf(i) !== -1) {
                var rowIndex = actualRows.indexOf(i);
                if (rows[rowIndex]) {
                    rows[rowIndex].style.backgroundColor = '#fff3cd';
                    rows[rowIndex].style.border = '2px solid #ffc107';
                }
            }
        }
    }
}

// Mobile menu setup
function setupMobileMenu() {
    var toggler = document.querySelector('.navbar-toggler');
    var sidebar = document.querySelector('.sidebar');
    
    if (toggler && sidebar) {
        toggler.addEventListener('click', function() {
            sidebar.classList.toggle('show');
        });
        
        // Close sidebar when clicking outside
        document.addEventListener('click', function(event) {
            if (window.innerWidth <= 576) {
                if (!sidebar.contains(event.target) && !toggler.contains(event.target)) {
                    sidebar.classList.remove('show');
                }
            }
        });
    }
}

// Utility functions
function getCurrentDay() {
    var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    return days[new Date().getDay()];
}

function formatTime(hour, minute) {
    var ampm = hour >= 12 ? 'PM' : 'AM';
    var displayHour = hour % 12;
    if (displayHour === 0) displayHour = 12;
    var displayMinute = minute < 10 ? '0' + minute : minute;
    return displayHour + ':' + displayMinute + ' ' + ampm;
}

// Auto refresh highlighting every minute
setInterval(function() {
    if (document.getElementById('timetable').style.display === 'block') {
        highlightCurrentClass();
    }
}, 60000);

// Save user preferences (basic implementation)
function savePreferences() {
    try {
        localStorage.setItem('lastVisit', new Date().toString());
    } catch(e) {
        // Handle storage errors silently
        console.log('Unable to save preferences');
    }
}

// Load preferences on startup
function loadPreferences() {
    try {
        var lastVisit = localStorage.getItem('lastVisit');
        if (lastVisit) {
            console.log('Welcome back! Last visit: ' + lastVisit);
        }
    } catch(e) {
        // Handle storage errors silently  
        console.log('Unable to load preferences');
    }
}

// Initialize on page load
window.addEventListener('load', function() {
    loadPreferences();
    savePreferences();
});
