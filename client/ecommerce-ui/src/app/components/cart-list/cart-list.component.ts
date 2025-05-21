import { Component, inject, OnInit } from '@angular/core';
import { Product, ProductService } from '../../../services/product.service';
import { CommonModule } from '@angular/common';
import { CartItemComponent } from '../cart-item/cart-item.component';

@Component({
  selector: 'app-cart-list',
  standalone: true,
  imports: [CommonModule, CartItemComponent],
  templateUrl: './cart-list.component.html',
  styleUrl: './cart-list.component.scss'
})
export class CartListComponent implements OnInit {
  private productService = inject(ProductService);
  products: Product[] = [];

  ngOnInit(): void {
    this.productService.getAllProducts().subscribe(
      response => this.products = response
    );
  }

}
