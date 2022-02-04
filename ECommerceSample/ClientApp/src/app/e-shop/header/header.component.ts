import { Component, OnInit } from "@angular/core";
import { EShopService } from "../shared/services/e-shop.service";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.css"]
})
export class HeaderComponent implements OnInit {
  private _title = "E-Shop";
  public get title(): string {
    return this._title;
  }

  constructor(public eShopService: EShopService) { }

  ngOnInit() {

  }

  toggleCart() {
    this.eShopService.isCartShown = !this.eShopService.isCartShown;
  }
}
