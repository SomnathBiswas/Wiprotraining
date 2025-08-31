"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const ContactManager_1 = require("./ContactManager");
function main() {
    const contactManager = new ContactManager_1.ContactManager();
    console.log("=== Contact Manager Application ===\n");
    // Test 1: Add contacts
    console.log("1. Adding contacts...");
    contactManager.addContact({
        name: "John Doe",
        email: "john.doe@email.com",
        phone: "123-456-7890"
    });
    contactManager.addContact({
        name: "Jane Smith",
        email: "jane.smith@email.com",
        phone: "987-654-3210"
    });
    contactManager.addContact({
        name: "Bob Johnson",
        email: "bob.johnson@email.com",
        phone: "555-123-4567"
    });
    console.log("\n2. Viewing all contacts...");
    contactManager.viewContacts();
    // Test 3: Modify existing contact
    console.log("\n3. Modifying contact...");
    contactManager.modifyContact(2, {
        name: "Jane Wilson",
        email: "jane.wilson@email.com"
    });
    // Test 4: Try to modify non-existing contact
    console.log("\n4. Trying to modify non-existing contact...");
    contactManager.modifyContact(999, { name: "Non Existing" });
    console.log("\n5. Viewing contacts after modification...");
    contactManager.viewContacts();
    // Test 6: Delete a contact
    console.log("\n6. Deleting contact...");
    contactManager.deleteContact(1);
    // Test 7: Try to delete non-existing contact
    console.log("\n7. Trying to delete non-existing contact...");
    contactManager.deleteContact(999);
    console.log("\n8. Final contact list...");
    contactManager.viewContacts();
}
// Run the application
main();
