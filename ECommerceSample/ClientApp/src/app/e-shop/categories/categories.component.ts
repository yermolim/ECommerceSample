import { Component, Input, OnInit, Output, EventEmitter } from "@angular/core";
import { ProductCategory } from "../shared/models/product-category";
import { EShopService } from "../shared/services/e-shop.service";

@Component({
  selector: "app-categories",
  templateUrl: "./categories.component.html",
  styleUrls: ["./categories.component.css"]
})
export class CategoriesComponent implements OnInit {
  constructor(public eShopService: EShopService) { }

  ngOnInit() {

  }
}
