const fs = require('fs').promises;
const path = require('path');

const filePath = path.join(__dirname, '../data/books.json');

async function readBooks() {
    const data = await fs.readFile(filePath, 'utf8');
    return JSON.parse(data);
}

async function writeBooks(books) {
    await fs.writeFile(filePath, JSON.stringify(books, null, 2));
}

module.exports = { readBooks, writeBooks };
