"use strict";
let price = 499.99;
let quantity = 2;
let toalAmount = price * quantity;
console.log("Total Amount:", toalAmount);
let costomerName = "Deepu Dhuriya";
let emial = "deepu@rrfcl.com";
console.log("Customer: ", costomerName.toLocaleUpperCase());
console.log("Email: ", emial);
let isLoggedIn = true;
let isPremiumUser = false;
if (isLoggedIn) {
    console.log("User is Logged in ");
}
console.log("Premium user?", isPremiumUser);
let cartItemsPrices = [199.99, 299.4, 149];
let tags = ["Angualr", "TypeScript", "WebAPI"];
console.log("Cart Prices:", cartItemsPrices);
console.log("Tags:", tags.join(", "));
let selectedCoupon = null; // can be string OR null
let deliveryInstruction; // declared but not assigned => undefined
console.log("Selected Coupon:", selectedCoupon); // null
console.log("Delivery Instruction:", deliveryInstruction);
// Using them safely:
if (selectedCoupon === null) {
    console.log("No coupon applied yet.");
}
if (deliveryInstruction === undefined) {
    console.log("No delivery instruction provided yet.");
}
// 6) any -> allows ANY type (TypeScript stops protecting you) - NOT recommended in Angular
let dynamicValue = "100";
console.log("dynamicValue (any) as string:", dynamicValue.toUpperCase()); // works now
dynamicValue = 100;
// The next line compiles fine, but will crash at runtime because 100 has no toUpperCase()
// console.log(dynamicValue.toUpperCase()); // Runtime error if you uncomment
// 7) unknown -> safer than any (forces you to check type before use)
let apiResponse = "SUCCESS";
// console.log(apiResponse.toUpperCase()); // Error: Object is of type 'unknown'
// Safe usage with type check (type narrowing)
if (typeof apiResponse === "string") {
    console.log("API Response (string):", apiResponse.toUpperCase());
}
apiResponse = 200;
if (typeof apiResponse === "number") {
    console.log("API Response (number):", apiResponse.toFixed(2));
}
/**
 * TypeScript Type Inference
 * Type Inference means:
 *  - You don't always need to write the type.
 *  - TypeScript "figures out" the type from the assigned value.
 *  - After inference, TypeScript enforces that type strictly.
 */
console.log("=== Type Inference Demo ===");
// 1) Inference from initial value
let courseName = "TypeScript Fundamentals";
// TypeScript inferred: courseName is a string
// So now courseName behaves like a string everywhere.
console.log("Course Name (upper):", courseName.toUpperCase()); // string method allowed
// courseName = 123; 
// Error (if you uncomment): Type 'number' is not assignable to type 'string'
// Because TypeScript already inferred courseName as string.
// 2) Inference from number calculation
let fee = 2000;
// inferred as number
let gst = fee * 0.18;
// inferred as number because it's a numeric calculation
let totalFee = fee + gst;
// inferred as number
console.log("Fee:", fee);
console.log("GST:", gst);
console.log("Total Fee:", totalFee);
// totalFee = "3000"; 
// Error (if you uncomment): Type 'string' is not assignable to type 'number'
// 3) Inference in arrays (very common in Angular)
let modules = ["Intro", "TypeScript", "Angular Basics"];
// inferred type: string[] (array of strings)
// So TypeScript allows only strings in this array.
modules.push("Routing"); // allowed (string)
// modules.push(100);     
// Error (if you uncomment): Argument of type 'number' is not assignable to parameter of type 'string'
console.log("=== End ===");
/**
 * TypeScript Interface
 * Interface = a "contract" that defines the exact SHAPE of an object.
 * It tells TypeScript:
 *   - which properties must exist
 *   - what type each property should be
 *   - which properties are optional
 *
 * In Angular, interfaces are commonly used for:
 *   - API response models (DTOs)
 *   - Component input models
 *   - Service method return types
 */
console.log("=== Interface Demo ===");
// 2) Create an object that MUST match the interface shape
// We are NOT creating an object of the interface
// We are creating plain JavaScript objects that are checked against the interface
// It means: Create a normal JavaScript object, and tell TypeScript to VERIFY that it matches IUser
const user1 = {
    id: 101,
    name: "Pranaya Rout",
    email: "pranaya@example.com"
    // isActive is optional, so we can skip it
};
const user2 = {
    id: 102,
    name: "Ravi",
    email: "ravi@example.com",
    isActive: true
};
console.log("User1:", user1);
console.log("User2:", user2);
// user1.id = "103"; 
// Compile-time error if uncommented: Type 'string' is not assignable to type 'number'
// 3) Interface for list/array of objects (very common in Angular)
const users = [user1, user2];
console.log("Total Users:", users.length);
// users.push({ id: 103, name: "A", email: 123 });
// Error if uncommented: Type 'number' is not assignable to type 'string' (email must be string)
console.log("=== End ===");
/**
 * TypeScript Functions
 * Goal: Understand function concepts in TypeScript:
 *  1) Parameter types
 *  2) Optional parameter (?)
 *  3) Default parameter
 *  4) Return type
 *  5) void return type
 */
console.log("=== Functions Demo ===");
/**
 * Calculates the final payable amount.
 * @param amount       -> required parameter (must be number)
 * @param discountPct  -> optional parameter (may be provided or not)
 * @param gstPct       -> default parameter (if not passed, 18 is used)
 * @returns number     -> function returns a number
 */
function calculatePayableAmount(amount, discountPct, // optional parameter (can be undefined)
gstPct = 18 // default parameter (used when caller doesn't pass it)
) {
    // If discountPct is not provided, treat it as 0
    const discount = amount * ((discountPct ?? 0) / 100);
    // Apply discount first
    const amountAfterDiscount = amount - discount;
    // Apply GST on discounted amount
    const gst = amountAfterDiscount * (gstPct / 100);
    // Final payable amount
    return amountAfterDiscount + gst;
}
// Call #1: Only required argument (discountPct not given, gstPct uses default 18)
const bill1 = calculatePayableAmount(2000);
console.log("Bill1 (no discount, default GST 18%):", bill1);
// Call #2: Discount given, GST uses default
const bill2 = calculatePayableAmount(2000, 10);
console.log("Bill2 (10% discount, default GST 18%):", bill2);
// Call #3: Discount and custom GST given
const bill3 = calculatePayableAmount(2000, 10, 5);
console.log("Bill3 (10% discount, GST 5%):", bill3);
// calculatePayableAmount("2000"); 
// Compile-time error if uncommented: Argument of type 'string' is not assignable to parameter of type 'number'
/**
 * A void function: returns nothing.
 * Common in Angular for logging, button click handlers, etc.
 */
function printInvoiceMessage(customerName) {
    console.log(`Invoice generated for: ${customerName}`);
    // no return statement needed because return type is void
}
printInvoiceMessage("Pranaya Rout");
console.log("=== End ===");
/**
 * TypeScript Classes
 * Goal: Understand class concepts in TypeScript:
 *  1) Class + Object creation (new)
 *  2) Constructor (initialization)
 *  3) Properties (data)
 *  4) Methods (behavior)
 *  5) Access modifiers: public, private, readonly
 *  6) Getter method (to safely expose private data)
 */
console.log("=== Classes Demo ===");
/**
 * A class is a blueprint to create objects.
 * In Angular, you often use classes for:
 * - Models (sometimes)
 * - Utility/Helper classes
 * - And Angular itself uses classes for Components/Services internally
 */
class BankAccount {
    // public: accessible from outside (default is public if not mentioned)
    accountHolderName;
    // readonly: can be set only once (usually in constructor) and cannot be changed later
    accountNumber;
    // private: accessible ONLY inside the class
    balance;
    constructor(accountHolderName, accountNumber, openingBalance) {
        // Initialize class properties when object is created
        this.accountHolderName = accountHolderName;
        this.accountNumber = accountNumber;
        this.balance = openingBalance;
    }
    // public method: can be called from outside
    deposit(amount) {
        if (amount <= 0) {
            console.log("Deposit amount must be greater than 0");
            return;
        }
        this.balance += amount;
        console.log(`Deposited: ${amount}. New Balance: ${this.balance}`);
    }
    // public method: can be called from outside
    withdraw(amount) {
        if (amount <= 0) {
            console.log("Withdraw amount must be greater than 0");
            return;
        }
        if (amount > this.balance) {
            console.log("Insufficient balance!");
            return;
        }
        this.balance -= amount;
        console.log(`Withdrawn: ${amount}. New Balance: ${this.balance}`);
    }
    // Getter method: a safe way to read private balance without exposing it directly
    getBalance() {
        return this.balance;
    }
}
// Create an object (instance) of the class using "new"
const account1 = new BankAccount("Pranaya Rout", "ACC-1001", 5000);
console.log("Account Holder:", account1.accountHolderName); // public property access
console.log("Account Number:", account1.accountNumber); // readonly property access
// account1.accountNumber = "ACC-9999";
// Compile-time error if uncommented: Cannot assign to 'accountNumber' because it is a read-only property
// account1.balance = 10000;
// Compile-time error if uncommented: Property 'balance' is private and only accessible within class 'BankAccount'
// Call methods (behavior)
account1.deposit(2000);
account1.withdraw(1000);
// Access private balance through a public method (getter)
console.log("Final Balance:", account1.getBalance());
console.log("=== End ===");
/**
 * TypeScript Inheritance
 * Goal: Understand inheritance concepts:
 *  1) Base class (Parent) and Derived class (Child)
 *  2) "extends" keyword
 *  3) Calling parent constructor using "super(...)"
 *  4) Inheriting parent properties/methods
 *  5) Method overriding (child changes parent behavior)
 */
console.log("=== Inheritance Demo ===");
// Step 1: Base (Parent) Class
// Represents common data and behavior for ALL users
class User {
    userId;
    name;
    email;
    constructor(userId, name, email) {
        this.userId = userId;
        this.name = name;
        this.email = email;
    }
    // Common behavior shared by all users
    getUserSummary() {
        return `${this.name} (${this.email})`;
    }
}
// Step 2: Derived (Child) Class
// AdminUser IS-A User, but with extra responsibilities
class AdminUser extends User {
    adminLevel;
    constructor(userId, name, email, adminLevel) {
        // Call parent constructor to initialize common fields
        super(userId, name, email);
        // Initialize admin-specific data
        this.adminLevel = adminLevel;
    }
    // Admin-specific behavior
    getAdminAccessInfo() {
        return `Admin Level: ${this.adminLevel}`;
    }
}
// Step 3: Create an Admin user object
const admin = new AdminUser(1, "Pranaya Rout", "pranaya@company.com", 5);
// Step 4: Use inherited + child behavior
console.log(admin.getUserSummary()); // inherited from AppUser
console.log(admin.getAdminAccessInfo()); // specific to AdminUser
/**
 * TypeScript Composition
 * Composition means: "Build a class by USING other objects (has-a relationship)"
 * instead of inheriting from another class (is-a relationship).
 *
 * Real-time scenario (very common in Angular apps):
 * A service needs:
 *   - Logger (to log messages)
 *   - ApiClient (to call APIs)
 *
 * Instead of making the service "extend" Logger/ApiClient (inheritance),
 * we COMPOSE the service by injecting/using them as dependencies.
 *
 * This example focuses ONLY on composition concepts:
 *  1) Separate small classes with single responsibility
 *  2) A bigger class "has" those classes (composition)
 *  3) The bigger class delegates work to them
 */
console.log("=== Composition Demo ===");
/**
 * Small class #1: Logger
 * Responsibility: Logging messages
 */
class Logger {
    info(message) {
        console.log(`[INFO] ${message}`);
    }
    error(message) {
        console.log(`[ERROR] ${message}`);
    }
}
/**
 * Small class #2: ApiClient
 * Responsibility: Simulate an API call
 * (In Angular, HttpClient plays this role)
 */
class ApiClient {
    get(url) {
        // Simulating an API response (for learning purpose)
        return `Dummy response from GET ${url}`;
    }
}
/**
 * Bigger class: UserService
 * Composition:
 *  - UserService HAS a Logger
 *  - UserService HAS an ApiClient
 *
 * It uses these objects to do its job.
 * This is "composition" (has-a), not inheritance (is-a).
 */
class UserService {
    // Composition: other services are used as properties
    logger;
    apiClient;
    constructor() {
        // Create instances of dependent classes
        this.logger = new Logger();
        this.apiClient = new ApiClient();
    }
    getUserById(userId) {
        this.logger.info(`Fetching user with Id = ${userId}`);
        const response = this.apiClient.get(`/api/users/${userId}`);
        this.logger.info(`API Response: ${response}`);
    }
}
// Compose UserService using those objects
const userService = new UserService();
// Use the composed service
userService.getUserById(101);
console.log("=== End ===");
/**
 * TypeScript Generics
 * Real-time Angular-style scenario:
 * When you call an API, the "wrapper" response format is usually the same:
 *   { isSuccess, message, data }
 *
 * But the type of "data" changes:
 *   - Login API returns: LoginData
 *   - Products API returns: Product[]
 *   - Profile API returns: UserProfile
 *
 * Generics solve this by letting you write ONE reusable type/class/function
 * that works with different data types safely.
 *
 * This example focuses ONLY on Generics:
 *  1) Generic interface ApiResponse<T>
 *  2) T represents "data type" decided at usage time
 *  3) Strong typing for different API responses without repeating code
 */
console.log("=== Generics Demo ===");
// ApiResponse<LoginData> means: data must be LoginData
const loginResponse = {
    isSuccess: true,
    message: "Login successful",
    data: {
        token: "JWT_TOKEN_ABC123",
        userName: "Pranaya"
    }
};
console.log("Login Message:", loginResponse.message);
console.log("Token:", loginResponse.data.token); // strongly typed
console.log("UserName:", loginResponse.data.userName); // strongly typed
// ApiResponse<Product[]> means: data must be an array of Product
const productsResponse = {
    isSuccess: true,
    message: "Products fetched",
    data: [
        { id: 1, name: "Mouse", price: 499 },
        { id: 2, name: "Keyboard", price: 999 }
    ]
};
console.log("Products Message:", productsResponse.message);
// Because data is Product[], TypeScript knows each item is Product
productsResponse.data.forEach((p) => {
    console.log(`Product: ${p.name} | Price: ${p.price}`);
});
// productsResponse.data.push({ id: 3, name: "Monitor" });
// Error if uncommented: Property 'price' is missing in type ...
console.log("=== End ===");
/**
 * TypeScript Enums
 * Real-time Angular-style scenario:
 * In apps, you often deal with "fixed set of allowed values" like:
 *   - OrderStatus: Pending, Paid, Shipped, Delivered, Cancelled
 *
 * If you use plain strings, typos can silently break logic:
 *   "Delevered" vs "Delivered"  (bug!)
 *
 * Enums solve this by:
 *   restricting values to a known set
 *   improving readability
 *   giving IntelliSense + refactor safety
 *
 * This example focuses ONLY on Enums:
 *  1) Creating an enum
 *  2) Using enum values instead of strings
 *  3) Using enum in a function and switch-case
 */
console.log("=== Enums Demo ===");
// 1) Enum: fixed set of allowed values
var OrderStatus;
(function (OrderStatus) {
    OrderStatus["Pending"] = "Pending";
    OrderStatus["Paid"] = "Paid";
    OrderStatus["Shipped"] = "Shipped";
    OrderStatus["Delivered"] = "Delivered";
    OrderStatus["Cancelled"] = "Cancelled";
})(OrderStatus || (OrderStatus = {}));
// Create an order with a valid enum value
const order1 = {
    orderId: 1001,
    customerName: "Pranaya",
    status: OrderStatus.Paid
};
console.log("Order:", order1);
// order1.status = "Delivered";
// Error if uncommented: Type '"Delivered"' is not assignable to type 'OrderStatus'
// (You must use OrderStatus.Delivered)
// 3) Function that behaves based on enum values (very common in UI logic)
function getOrderMessage(status) {
    // switch works perfectly with enums and makes logic clean and readable
    switch (status) {
        case OrderStatus.Pending:
            return "Your order is placed and waiting for payment.";
        case OrderStatus.Paid:
            return "Payment received. We will ship your order soon.";
        case OrderStatus.Shipped:
            return "Your order has been shipped.";
        case OrderStatus.Delivered:
            return "Order delivered successfully";
        case OrderStatus.Cancelled:
            return "Order was cancelled";
    }
}
console.log("Message:", getOrderMessage(order1.status));
// Update using enum (safe, no typo risk)
order1.status = OrderStatus.Delivered;
console.log("Updated Status:", order1.status);
console.log("Updated Message:", getOrderMessage(order1.status));
console.log("=== End ===");
/**
 * TypeScript Tuples
 * Tuple = an array with a FIXED length and FIXED types at each position.
 *
 * Real-time Angular-style scenario:
 * When you show a dropdown / list in UI, you often store each item as:
 *   [id, displayText]
 *
 * Example:
 *   [101, "Angular Basics"]
 *   [102, "TypeScript Fundamentals"]
 *
 * This example focuses ONLY on Tuple concepts:
 *  1) Defining a tuple type
 *  2) Creating tuple values
 *  3) Using tuples in an array (list of tuples)
 *  4) Why tuples prevent bugs
 */
console.log("=== Tuples Demo ===");
// 2) Create tuples (each tuple must follow the exact order)
const course1 = [101, "TypeScript Fundamentals"]; // correct
const course2 = [102, "Angular Basics"]; // correct
console.log("Course1:", course1);
console.log("Course2:", course2);
// const wrongCourse: CourseItem = ["Angular Basics", 103];
// Error if uncommented: Type 'string' is not assignable to type 'number'
// because tuple order matters: [number, string]
// 3) Real usage: list of courses for UI dropdown
const courseDropdown = [
    [201, "RxJS Essentials"],
    [202, "Angular Forms"],
    [203, "Angular Routing"]
];
// 4) Using tuple values safely (destructuring is very common)
courseDropdown.forEach(([id, title]) => {
    // id is number, title is string (TypeScript guarantees this)
    console.log(`Dropdown Item -> Id: ${id}, Title: ${title}`);
});
// 5) Why tuple helps: you can safely access by position
const selectedCourse = [301, "Angular HTTP Client"];
const selectedId = selectedCourse[0]; // number
const selectedTitle = selectedCourse[1]; // string
console.log("Selected Id:", selectedId);
console.log("Selected Title:", selectedTitle);
console.log("=== End ===");
/**
 * TypeScript Union Types
 * Union type means: a variable can hold ONE of multiple allowed types.
 * Example: string | null  => value can be a string OR null
 *
 * Real-time Angular-style scenario:
 * In Angular forms, a value is often:
 *   - present (string)
 *   - or not selected yet (null)
 *
 * Example: Coupon code field:
 *   - user enters: "SAVE10"   (string)
 *   - user leaves it empty:   null
 *
 * This example focuses ONLY on Union concepts:
 *  1) Creating a union type
 *  2) Assigning allowed values
 *  3) Type narrowing using if-check (so you can safely use the value)
 */
console.log("=== Union Types Demo ===");
// 1) Union type: coupon can be either a string OR null
let couponCode = null; // allowed (null is part of union)
console.log("Initial Coupon:", couponCode);
// couponCode = 100; 
// Error if uncommented: Type 'number' is not assignable to type 'string | null'
// 2) Later user enters a coupon
couponCode = "SAVE10"; // allowed (string is part of union)
console.log("Entered Coupon:", couponCode);
// 3) Real-time use: apply coupon only if it's a string (type narrowing)
function applyCouponIfAvailable(code) {
    // This check "narrows" the union:
    // Inside this if-block, TypeScript knows code is definitely a string.
    if (code !== null) {
        console.log(`Applying coupon: ${code.toUpperCase()}`);
        return;
    }
    // Here TypeScript knows code is null
    console.log("No coupon applied (user did not enter any).");
}
applyCouponIfAvailable(couponCode);
// 4) User clears the field (very common in forms)
couponCode = null;
applyCouponIfAvailable(couponCode);
console.log("=== End ===");
/**
 * TypeScript Intersection Types
 * Intersection type means: combine multiple types into ONE.
 *   A & B  => the final type must have ALL properties of A AND ALL properties of B
 *
 * Real-time Angular-style scenario:
 * In many apps, you have:
 *  1) Base audit fields for every record (createdBy, createdOn)
 *  2) Entity-specific fields (product fields, user fields, etc.)
 *
 * Instead of repeating audit fields in every model, we combine them using Intersection.
 *
 * This example focuses ONLY on Intersection concepts:
 *  1) Create two separate types
 *  2) Combine them using &
 *  3) Use the final type (must satisfy both)
 */
console.log("=== Intersection Types Demo ===");
// Valid object: has product fields + audit fields
const product = {
    id: 101,
    name: "Angular Course",
    price: 1999,
    createdBy: "Admin",
    createdOn: new Date()
};
console.log("Product:", product);
console.log("Product Name:", product.name);
console.log("Created By:", product.createdBy);
// const invalidProduct: ProductWithAudit = {
//   id: 102,
//   name: "TypeScript Course",
//   price: 1499
// };
// Error if uncommented: missing createdBy and createdOn (because intersection requires ALL fields)
console.log("=== End ===");
/**
 * TypeScript Conditional Statements
 * Goal: Understand  conditional statements:
 *   1) if
 *   2) if...else
 *   3) else if
 *   4) switch
 *
 * Real-time Angular-style scenario:
 * You call a Login API and get a response.
 * Based on the response, your app decides what to do:
 *   - show success message + redirect
 *   - show invalid credentials
 *   - show locked account message
 */
console.log("=== Conditional Statements Demo ===");
// Change this object value to test different conditions
const response = {
    status: "INVALID_CREDENTIALS",
    message: "Username or password is wrong",
    remainingAttempts: 2
};
// 1) if statement
// If user is successfully logged in, do success flow
if (response.status === "SUCCESS") {
    console.log("Login successful!");
    console.log("Redirect to Dashboard...");
}
// 2) if...else + 3) else if
// Handle multiple outcomes
if (response.status === "SUCCESS") {
    console.log("Welcome! Redirecting...");
}
else if (response.status === "INVALID_CREDENTIALS") {
    console.log("Invalid credentials!");
    // remainingAttempts is optional, so we must check before using it
    if (response.remainingAttempts !== undefined) {
        console.log(`Attempts left: ${response.remainingAttempts}`);
    }
}
else {
    // If it's not SUCCESS and not INVALID_CREDENTIALS, it must be ACCOUNT_LOCKED
    console.log("Account locked!");
    console.log("Please contact support.");
}
// 4) switch statement
// switch is cleaner when comparing ONE value against MANY fixed options
switch (response.status) {
    case "SUCCESS":
        console.log("Switch: Show dashboard page");
        break;
    case "INVALID_CREDENTIALS":
        console.log("Switch: Show invalid login error message");
        break;
    case "ACCOUNT_LOCKED":
        console.log("Switch: Show locked account message");
        break;
}
console.log("=== End ===");
/**
 * TypeScript Looping Statements
 * Goal: Understand looping statements:
 *   1) for      (index-based looping)
 *   2) for...of (best for arrays - very common in Angular)
 *   3) for...in (for object keys)
 *   4) while    (repeat until condition becomes false)
 *
 * Real-time Angular-style scenario:
 * Imagine you fetched a list of products from an API.
 * You want to:
 *   - loop through products and print them
 *   - calculate total value
 *   - loop through object properties (product details)
 *   - simulate retry attempts using while loop
 */
console.log("=== Looping Statements Demo ===");
// Simulated API response (array of products)
const products = [
    { id: 1, name: "Mouse", price: 499 },
    { id: 2, name: "Keyboard", price: 999 },
    { id: 3, name: "Monitor", price: 6999 }
];
// 1) for loop (index-based)
// Useful when you need the index number
for (let i = 0; i < products.length; i++) {
    const item = products[i];
    if (!item)
        continue;
    console.log(`Index: ${i} -> ${item.name} (${item.price})`);
}
// 2) for...of loop (best for arrays)
// Most commonly used in TypeScript/Angular for arrays
console.log("\n2) for...of loop (array values):");
let totalValue = 0;
for (const p of products) {
    console.log(`Product: ${p.name}, Price: ${p.price}`);
    totalValue += p.price; // calculate total value
}
console.log("Total Value:", totalValue);
// 3) for...in loop (object keys)
// Use for...in when you want to loop through keys of an object
console.log("\n3) for...in loop (object keys):");
const selectedProduct = { id: 10, name: "Laptop", price: 55000 };
// for...in gives keys as strings: "id", "name", "price"
for (const key in selectedProduct) {
    // key is a property name, so we access value using bracket notation
    const value = selectedProduct[key];
    console.log(`${key} : ${value}`);
}
// Note: Avoid using for...in for arrays (it iterates keys/indexes, not values)
// 4) while loop (repeat until condition becomes false)
// Real-time usage: retry mechanism (very common in API calls)
console.log("\n4) while loop (retry simulation):");
let attempt = 1;
const maxAttempts = 3;
let isApiSuccess = false;
while (attempt <= maxAttempts && isApiSuccess === false) {
    console.log(`Attempt ${attempt}: Calling API...`);
    // Simulating API success only on 3rd attempt
    if (attempt === 3) {
        isApiSuccess = true;
        console.log("API Call Success!");
    }
    else {
        console.log("API Call Failed. Retrying...");
    }
    attempt++;
}
console.log("=== End ===");
