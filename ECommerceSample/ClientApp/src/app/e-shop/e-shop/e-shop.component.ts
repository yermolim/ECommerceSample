import { Component, OnDestroy, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Subscription } from "rxjs";

import { EShopService } from "../shared/services/e-shop.service";
import { ProductService } from "../shared/services/product.service";
import { Product } from "../shared/models/product";

@Component({
  selector: "app-e-shop",
  templateUrl: "./e-shop.component.html",
  styleUrls: ["./e-shop.component.css"]
})
export class EShopComponent implements OnInit, OnDestroy {
  private _subscriptions: Subscription[] = [];

  constructor(protected _router: Router,
    protected _activatedRoute: ActivatedRoute,
    protected _productService: ProductService,
    public eShopService: EShopService) { }

  ngOnInit() {
    this._productService.getAllProductCategoriesAsync()
      .then(cat => this.eShopService.categories = cat.sort((a, b) => a.name?.localeCompare(b.name)));

    this._subscriptions.push(
      this.eShopService.selectedProduct$.subscribe(p => this.onSelectedProductChange(p))
    );
  }

  ngOnDestroy() {
    this._subscriptions.forEach(s => s.unsubscribe());
  }

  onSelectedProductChange(product: Product) {
    if (product) {
      this.navigateToProductDescription();
    } else {
      this.navigateToProductList();
    }
  }

  hideCart() {
    this.eShopService.isCartShown = false;
  }
  
  private navigateToProductList() {
    this._router.navigate(["./product-list"], { 
      relativeTo: this._activatedRoute,
      state: {},
    });
  }
  
  private navigateToProductDescription() {
    this._router.navigate(["./product-description"], { 
      relativeTo: this._activatedRoute,
      state: {},
    });
  }
}
