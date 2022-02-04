import { Component, OnInit } from "@angular/core";
import { EShopService } from "../shared/services/e-shop.service";
import { OrderService } from "../shared/services/order.service";
import { ProductService } from "../shared/services/product.service";

@Component({
  selector: "app-cart",
  templateUrl: "./cart.component.html",
  styleUrls: ["./cart.component.css"]
})
export class CartComponent implements OnInit {
  private _title = "Shopping bag";
  public get title(): string {
    return this._title;
  }

  inStock: boolean;
  orderError: boolean;
  orderSuccess: boolean;

  constructor(public eShopService: EShopService,
    private _productService: ProductService,
    private _orderService: OrderService) { }

  ngOnInit() {
    // the first check during on the cart opening
    this.checkAvailableAmountsAsync();
  }

  async confirmOrderAsync() {
    // additional check if case some of the items run out of stock while the cart was opened
    const inStock = await this.checkAvailableAmountsAsync();
    if (!inStock) {
      return;
    }

    const result = await this._orderService.sendOrder();
    if (result) {
      this.eShopService.cartContent.clearCart();
      this.orderSuccess = true;
      setTimeout(() => this.orderSuccess = false, 3000);
      await this.checkAvailableAmountsAsync();
    } else {
      this.orderError = true;
      setTimeout(() => this.orderSuccess = false, 3000);
    }
  }

  private async checkAvailableAmountsAsync(): Promise<boolean> {
    let result = true;
    if (!this.eShopService.cartContent.items.length) {
      result = null;
    } else {
      for (const item of this.eShopService.cartContent.items) {
        const available = await this._productService.checkProductAvailabilityAsync(item.product.id, item.amount);
        if (!available) {
          result = false;
          break;
        }
      }
    }

    this.inStock = result;
    return result;
  }
}
