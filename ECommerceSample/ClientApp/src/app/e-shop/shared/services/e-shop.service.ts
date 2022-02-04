import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { CartContent } from "../models/cart-content";

import { Product } from "../models/product";
import { ProductCategory } from "../models/product-category";

@Injectable()
export class EShopService {
  private readonly _cartContent = new CartContent([]);
  get cartContent(): CartContent {
    return this._cartContent;
  }
  isCartShown = false;

  private _categories: ProductCategory[] = [];
  get categories(): ProductCategory[] {
    return this._categories;
  }
  set categories(value: ProductCategory[]) {
    this._categories = value ?? [];
    this.selectedCategory = this._categories.length
      ? this._categories[0]
      : null;
  }

  private _selectedCategory: ProductCategory = null;
  get selectedCategory(): ProductCategory {
    return this._selectedCategory;
  }
  set selectedCategory(value: ProductCategory) {
    this._selectedCategory = value;
    this.isCartShown = false;
    this.selectedProduct = null;
  }

  private readonly _selectedProduct = new BehaviorSubject<Product>(null);
  set selectedProduct(value: Product) {
    this._selectedProduct.next(value);
  }
  readonly selectedProduct$ = this._selectedProduct.asObservable();

  constructor() { }
}
