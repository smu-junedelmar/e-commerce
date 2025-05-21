import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

export interface CartItem {
  _id?: string;
  name: string;
  description: string;
  price: number;
  stock: number;
  quantity?: number;  // optional for cart
}

@Component({
  selector: 'app-cart-item',
  imports: [CommonModule],
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.scss'],
  standalone: true
})
export class CartItemComponent {
  @Input() item!: CartItem;
}
