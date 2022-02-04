import { Component, OnDestroy, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Subscription } from "rxjs";

import { Product } from "../shared/models/product";
import { EShopService } from "../shared/services/e-shop.service";
import { ProductService } from "../shared/services/product.service";

@Component({
  selector: "app-product-description",
  templateUrl: "./product-description.component.html",
  styleUrls: ["./product-description.component.css"]
})
export class ProductDescriptionComponent implements OnInit, OnDestroy {
  private _subscriptions: Subscription[] = [];
  
  product: Product;

  addToCartForm: FormGroup;

  constructor(protected _productService: ProductService,
    protected _eShopService: EShopService) { }

  ngOnInit() {
    this._subscriptions.push(
      this._eShopService.selectedProduct$.subscribe(p => {
        this.product = p;   
        if (!this.product) {
          return;
        }     
        this.addToCartForm = new FormGroup({
          amount: new FormControl(1, [Validators.min(1), Validators.max(this.product.numberOfItemsInStock)])
        });
      })
    );
  }

  ngOnDestroy() {
    this._subscriptions.forEach(s => s.unsubscribe());
  }

  get amount(): FormControl {
    return this.addToCartForm?.get("amount") as FormControl;
  }

  onSubmit() {
    this._eShopService.cartContent.addToCart(this.product, +this.amount.value);
  }
}
