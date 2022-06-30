import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { Sale } from '../models/sale';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private readonly rootUrl = 'products';

  constructor(private httpClient: HttpClient) { }

  getProducts(category: string = '', color: string = '', size: string = ''): Observable<Product[]> {
    return this.httpClient.get<Product[]>(`/api/${this.rootUrl}?category=${category}&color=${color}&size=${size}`);
  }

  createSale(sale: Sale): Observable<number> {
    return this.httpClient.post<number>(`/api/${this.rootUrl}/sale`, sale);
  }
}
