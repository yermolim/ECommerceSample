import { Component, Input, OnInit } from "@angular/core";
import { EShopService } from "../shared/services/e-shop.service";
import { Product } from "../shared/models/product";

@Component({
  selector: "app-product-list",
  templateUrl: "./product-list.component.html",
  styleUrls: ["./product-list.component.css"]
})
export class ProductListComponent implements OnInit {
  constructor(public eShopService: EShopService) { }

  ngOnInit() {
    
  }
}
