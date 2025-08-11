
fetch('https://dummy.restapiexample.com/api/v1/employees')
    .then(response => response.json())
    .then(data => {
        console.log('Employee Data:', data);
        console.log('Total employees:', data.data.length);
    })
    .catch(error => {
        console.error('Error fetching data:', error);
    });


async function fetchEmployeeData() {
    try {
        const response = await fetch('https://dummy.restapiexample.com/api/v1/employees');
        const data = await response.json();
        console.log('Employee Data:', data);
        console.log('Total employees:', data.data.length);
    } catch (error) {
        console.error('Error fetching data:', error);
    }
}

fetchEmployeeData();
