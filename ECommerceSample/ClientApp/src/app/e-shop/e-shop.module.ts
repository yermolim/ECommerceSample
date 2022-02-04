import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CartComponent } from "./cart/cart.component";
import { HeaderComponent } from "./header/header.component";
import { CategoriesComponent } from "./categories/categories.component";
import { ProductListComponent } from "./product-list/product-list.component";
import { ProductDescriptionComponent } from "./product-description/product-description.component";
import { EShopComponent } from "./e-shop/e-shop.component";
import { EShopService } from "./shared/services/e-shop.service";
import { EShopRoutingModule } from "./e-shop-routing.module";
import { ProductListItemComponent } from "./product-list-item/product-list-item.component";
import { ReactiveFormsModule } from "@angular/forms";
import { ProductService } from "./shared/services/product.service";
import { OrderService } from "./shared/services/order.service";

@NgModule({
  declarations: [
    CartComponent,
    HeaderComponent,
    CategoriesComponent,
    ProductListComponent,
    ProductDescriptionComponent,
    EShopComponent,
    ProductListItemComponent,
  ],
  imports: [
    CommonModule,
    EShopRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [
    EShopService,
    ProductService,
    OrderService,
  ]
})
export class EShopModule { }
