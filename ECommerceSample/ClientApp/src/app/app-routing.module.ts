import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    redirectTo: "e-shop",
    pathMatch: "full"
  },
  {
    path: "e-shop",
    loadChildren: () => import("./e-shop/e-shop.module").then(m => m.EShopModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
