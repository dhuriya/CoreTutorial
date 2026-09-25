import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProductCard } from '../product-card/product-card';
import { Product } from '../store-models';

@Component({
  imports: [ProductCard],
  selector: 'app-product-grid',
  styleUrl: './product-grid.css',
  templateUrl: './product-grid.html',
})
export class ProductGrid {
  /*
    @Input() products (Parent → Child)
    - Parent (StoreContainer) sends the product list to display
    - Example binding: [products]="filteredProducts"
  */
 @Input() products: Product[] = [];
 /*
    @Output() addToCart (Child → Parent)
    - ProductGrid will emit the product when user clicks "Add" inside ProductCard
    - Parent listens like: (addToCart)="onAddToCart($event)"
  */
 @Output() addToCart = new EventEmitter<Product>(); 
 /*
     @Output() viewDetails (Child → Parent)
    - ProductGrid will emit the product when user clicks "View" inside ProductCard
    - Parent listens like: (viewDetails)="onViewDetails($event)"
  */
 @Output() viewDetails = new EventEmitter<Product>();
  /*
     Called when ProductCard raises its (add) event.
    - This method simply forwards the same product upward to the parent.
    - ProductGrid itself does NOT update cart count (parent handles that logic).
  */
 onAdd(product: Product){
  this.addToCart.emit(product);//// Emit selected product to StoreContainer
 }
 /*
     Called when ProductCard raises its (view) event.
    - This method forwards the product upward to the parent.
    - Parent sets selectedProduct and shows Quick View panel.
  */
 onView(product: Product){
  this.viewDetails.emit(product);// Emit selected product to StoreContainer
 }
}
