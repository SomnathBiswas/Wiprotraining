const express = require('express');
const app = express();
const bookService = require('./services/bookService');
const EventEmitter = require('events');
const bookEvents = new EventEmitter();
const { readBooks, writeBooks } = bookService;

// Event Listeners
bookEvents.on('bookAdded', () => console.log('Book Added'));
bookEvents.on('bookUpdated', () => console.log('Book Updated'));
bookEvents.on('bookDeleted', () => console.log('Book Deleted'));

// GET all books
app.get('/books', async (req, res) => {
    const books = await readBooks();
    res.json(books);
});

// GET book by ID
app.get('/books/:id', async (req, res) => {
    const books = await readBooks();
    const book = books.find(b => b.id === parseInt(req.params.id));
    if (!book) return res.status(404).json({ message: "Book not found" });
    res.json(book);
});

// POST add new book
app.post('/books', async (req, res) => {
    const { title, author } = req.body;
    if (!title || !author) return res.status(400).json({ message: "Title and Author required" });

    const books = await readBooks();
    const newBook = { id: books.length + 1, title, author };
    books.push(newBook);
    await writeBooks(books);

    bookEvents.emit('bookAdded');
    res.status(201).json(newBook);
});

// PUT update book
app.put('/books/:id', async (req, res) => {
    const books = await readBooks();
    const index = books.findIndex(b => b.id === parseInt(req.params.id));
    if (index === -1) return res.status(404).json({ message: "Book not found" });

    books[index] = { ...books[index], ...req.body };
    await writeBooks(books);

    bookEvents.emit('bookUpdated');
    res.json(books[index]);
});

// DELETE book
app.delete('/books/:id', async (req, res) => {
    const books = await readBooks();
    const filteredBooks = books.filter(b => b.id !== parseInt(req.params.id));
    if (filteredBooks.length === books.length) return res.status(404).json({ message: "Book not found" });

    await writeBooks(filteredBooks);

    bookEvents.emit('bookDeleted');
    res.status(204).send();
});

app.use(express.json());

app.get('/', (req, res) => {
    res.json({ message: "Welcome to Book Management API" });
});

app.listen(4000, () => {
    console.log('Server running on http://localhost:4000');
});

