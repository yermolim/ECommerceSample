import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { EShopComponent } from "./e-shop/e-shop.component";
import { ProductDescriptionComponent } from "./product-description/product-description.component";
import { ProductListComponent } from "./product-list/product-list.component";

const routes: Routes = [
  {
    path: "",
    redirectTo: "product-list",
    pathMatch: "full"
  },
  {
    path: "",
    component: EShopComponent,
    children: [
      {
        path: "product-list",
        component: ProductListComponent,
      },
      {
        path: "product-description",
        component: ProductDescriptionComponent,
      },
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EShopRoutingModule { }
