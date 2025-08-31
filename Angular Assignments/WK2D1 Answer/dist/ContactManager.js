"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ContactManager = void 0;
class ContactManager {
    constructor() {
        this.contacts = [];
        this.nextId = 1;
    }
    addContact(contact) {
        const newContact = {
            id: this.nextId++,
            name: contact.name,
            email: contact.email,
            phone: contact.phone
        };
        this.contacts.push(newContact);
        console.log(` Contact "${contact.name}" added successfully with ID: ${newContact.id}`);
    }
    viewContacts() {
        if (this.contacts.length === 0) {
            console.log(" No contacts found.");
            return [];
        }
        console.log(" All Contacts:");
        this.contacts.forEach(contact => {
            console.log(`ID: ${contact.id}, Name: ${contact.name}, Email: ${contact.email}, Phone: ${contact.phone}`);
        });
        return this.contacts;
    }
    modifyContact(id, updatedContact) {
        const contactIndex = this.contacts.findIndex(contact => contact.id === id);
        if (contactIndex === -1) {
            console.log(` Error: Contact with ID ${id} does not exist.`);
            return;
        }
        // Update only the provided fields
        this.contacts[contactIndex] = {
            ...this.contacts[contactIndex],
            ...updatedContact,
            id: id // Ensure ID doesn't change
        };
        console.log(`Contact with ID ${id} modified successfully.`);
    }
    deleteContact(id) {
        const contactIndex = this.contacts.findIndex(contact => contact.id === id);
        if (contactIndex === -1) {
            console.log(`Error: Contact with ID ${id} does not exist.`);
            return;
        }
        const deletedContact = this.contacts.splice(contactIndex, 1)[0];
        console.log(`Contact "${deletedContact.name}" (ID: ${id}) deleted successfully.`);
    }
    // Helper method to find contact by ID
    findContactById(id) {
        return this.contacts.find(contact => contact.id === id);
    }
}
exports.ContactManager = ContactManager;
