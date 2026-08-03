/**
 * Type Alias
 * Scenario:
 * Imagine you call an API to fetch products.
 * The API returns a standard response format:
 *   { isSuccess, message, data }
 *
 * We will create Type Aliases for:
 *  1) Product (object shape)
 *  2) ApiResponse<T> (generic reusable response shape)
 *  3) ProductResponse (a readable alias for ApiResponse<Product[]>)
 */

console.log("================ Alia Demo ==================");
type Product ={
    id:number;
    name:string;
    price:number;
};
type ApiResponse<T> ={
    isSuccess:boolean;
    message:string;
    data:T;
};

type ProductResponse = ApiResponse<Product[]>;
const response: ProductResponse={
    isSuccess:true;
    message : "Products getched succesfully";
    data:[
        {id:1, name:"Mouse",price: 49},
        {id:2,name:"keyboard",price:999}
    ]
};
console.log("Message:",response.message);
response.data.forEach((p) => {
    console.log(`Product: ${p.name} | Price: ${p.price}`);
});
console.log("=========== End ==========");


