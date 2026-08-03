"use strict";
/**
 * TypeScript Access Modifiers
 * Goal: Understand access modifiers:
 *   1) public    -> accessible from anywhere (default)
 *   2) private   -> accessible only inside the class
 *   3) protected -> accessible inside the class + its child classes (inheritance)
 */
console.log("=== Access Modifiers Demo ===");
// Step 1: Base class
class UserAccount {
    // public -> accessible from anywhere (default)
    userName;
    // private -> accessible ONLY inside this class
    password;
    // protected -> accessible inside this class and subclasses
    accountStatus;
    constructor(userName, password) {
        this.userName = userName;
        this.password = password;
        this.accountStatus = "ACTIVE";
    }
    // public method -> can be called from outside
    getAccountInfo() {
        console.log("User:", this.userName);
        console.log("Status:", this.accountStatus);
        // password is accessible here because we are INSIDE the class
        console.log("Password length:", this.password.length);
    }
}
// Step 2: Child class (realistic extension)
class AdminAccount extends UserAccount {
    constructor(userName, password) {
        super(userName, password);
    }
    // Method inside child class
    updateStatus(newStatus) {
        // protected member is accessible in subclass
        this.accountStatus = newStatus;
        console.log("Account status updated to:", this.accountStatus);
        // private member is NOT accessible here
        // console.log(this.password); // Compile-time error
    }
}
// Step 3: Create object
const admin = new AdminAccount("Pranaya", "secret123");
// Step 4: Access members
console.log(admin.userName); // public allowed
admin.getAccountInfo(); // public method allowed
admin.updateStatus("SUSPENDED");
// private and protected members NOT accessible from outside
// console.log(admin.password);       // Error: private
// console.log(admin.accountStatus);  // Error: protected
