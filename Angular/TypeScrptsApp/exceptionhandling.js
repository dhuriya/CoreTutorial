"use strict";
/**
 * Exception Handling
 * Scenario:
 * You receive product data from an API as JSON text.
 * Sometimes the API response can be invalid JSON or missing required fields.
 *
 * This example focuses on:
 *  1) try
 *  2) catch
 *  3) finally
 *  4) throwing custom errors using throw
 */
console.log("================= Exception Handling Demo ===============");
function parseProductJson(jsonText) {
    try {
        const obj = JSON.parse(jsonText);
        if (typeof obj.id !== number)
            throw new error("Invalid or missing 'id'");
        if (typeof obj.name !== string)
            throw new error("Invalid or missing 'name'");
        if (typeof obj.price !== number)
            throw new error("Invalid or missing 'price'");
        return { id: obj.id, name: obj.name, price: obj.price };
    }
    catch (error) {
        console.log("Parsing failed:", error.message);
        throw error;
    }
    finally {
        console.log("Finally: parseProductJson() completed.");
    }
}
// Test with a valid API JSON response
try {
    const validJson = `{"id": 1, "name": "Mouse", "price": 499}`;
    const product = parseProductJson(validJson);
    console.log("Product Parsed:", product);
}
catch {
    // caller-level handling (optional)
    console.log("Caller: Could not process validJson (unexpected).");
}
// Test with invalid JSON (will throw)
try {
    const invalidJson = `{"id": 1, "name": "Mouse", "price": }`; // broken JSON
    const product = parseProductJson(invalidJson);
    console.log(product); // won't reach here
}
catch {
    console.log("Caller: Showing user-friendly message -> 'Something went wrong. Try again.'");
}
console.log("=== End ===");
