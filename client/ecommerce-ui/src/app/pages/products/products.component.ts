import { Component } from '@angular/core';
import { CartListComponent } from "../../components/cart-list/cart-list.component";

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CartListComponent],
  templateUrl: './products.component.html',
  styleUrl: './products.component.scss'
})
export class ProductsComponent {

}
