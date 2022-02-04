import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { Product } from "../shared/models/product";
import { EShopService } from "../shared/services/e-shop.service";

@Component({
  selector: "app-product-list-item",
  templateUrl: "./product-list-item.component.html",
  styleUrls: ["./product-list-item.component.css"]
})
export class ProductListItemComponent implements OnInit {
  @Input() product: Product;

  constructor(public eShopService: EShopService) { }

  ngOnInit() {

  }

  addToCart() {
    this.eShopService.cartContent.addToCart(this.product, 1);
  }
  
  setItemAsSelected() {
    this.eShopService.selectedProduct = this.product;
  }
}
