# Book Management REST API

A Node.js + Express.js REST API to manage a list of books stored in a JSON file.  
Supports CRUD operations (Create, Read, Update, Delete) and logs events when books are added, updated, or deleted.

---

## File Structure

book-api/
├── data/
│   └── books.json
├── services/
│   └── bookService.js
├── server.js
├── package.json
└── README.md

## Setup Instructions

## 1. Clone or Create Project

If you haven’t already, create the project folder:

```bash
mkdir book-api
cd book-api
npm init -y
npm install express
npm install nodemon --save-dev```


## 2. Inside package.json

"scripts": {
  "start": "nodemon server.js"
}

##  API Endpoints

- **GET /** → Welcome message  
- **GET /books** → Get all books  
- **GET /books/:id** → Get a book by ID  
- **POST /books** → Add a new book  
  - Body: `{ "title": "Book1", "author": "Author1" }`  
- **PUT /books/:id** → Update a book by ID  
  - Body: `{ "title": "Updated Title" }`  
- **DELETE /books/:id** → Delete a book by ID  


