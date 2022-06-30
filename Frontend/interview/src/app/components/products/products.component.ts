import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SaleProduct } from 'src/app/models/sale-product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  readonly displayedColumns: string[] = ['productName', 'category', 'color', 'size', 'price', 'quantity'];
  form: FormGroup;
  products: SaleProduct[] = [];

  constructor(private productsService: ProductsService,
    private snackBar: MatSnackBar,
    private fb: FormBuilder) {
    this.form = this.fb.group({
      category: [''],
      color: [''],
      size: ['']
    });
  }

  ngOnInit(): void {
    this.pullProducts();
  }

  pullProducts(): void {
    let category = this.form.controls['category'].value ?? '';
    let color = this.form.controls['color'].value ?? '';
    let size = this.form.controls['size'].value ?? '';

    this.productsService.getProducts(category, color, size).subscribe(products => {
      this.products = products.map(p => {
        return {
          productId: p.productId,
          productName: p.productName,
          category: p.category,
          color: p.color,
          size: p.size,
          price: p.price,
          quantity: 0,
        } as SaleProduct;
      });
    });
  }

  checkout(): void {
    this.productsService.createSale({
      userEmail: 'someUserEmail',
      products: this.products.filter(p => p.quantity > 0)
    }).subscribe(total => {
      this.snackBar.open(`The sale has been created, the total amount is ${total}`, 'OK');
    });
  }
}
