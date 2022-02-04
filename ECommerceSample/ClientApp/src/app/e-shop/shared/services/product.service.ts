import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";

import { Product } from "../models/product";
import { ProductCategory } from "../models/product-category";

@Injectable()
export class ProductService {

  constructor(protected _httpClient: HttpClient) { }

  async getAllProductCategoriesAsync(): Promise<ProductCategory[]> {
    return this.tryCatchWrapperAsync<ProductCategory[]>(
      () => firstValueFrom(this._httpClient.get<ProductCategory[]>("api/products/categories")), 
      []
    );
  }
  
  async getAllProductsAsync(): Promise<Product[]> {
    return this.tryCatchWrapperAsync<Product[]>(
      () => firstValueFrom(this._httpClient.get<Product[]>("api/products")), 
      []
    );
  }
  
  async getCategoryAsync(id: string): Promise<ProductCategory> {
    return this.tryCatchWrapperAsync<ProductCategory>(
      () => firstValueFrom(this._httpClient.get<ProductCategory>(`api/products/categories/${id}`)), 
      null
    );
  }
  
  async getCategoryProductsAsync(id: string): Promise<Product[]> {
    return this.tryCatchWrapperAsync<Product[]>(
      () => firstValueFrom(this._httpClient.get<Product[]>(`api/products/categories/${id}/products`)), 
      []
    );
  }
  
  async getProductAsync(id: string): Promise<Product> {
    return this.tryCatchWrapperAsync<Product>(
      () => firstValueFrom(this._httpClient.get<Product>(`api/products/${id}`)), 
      null
    );
  }
  
  async checkProductAvailabilityAsync(id: string, amount: number): Promise<boolean> {
    return this.tryCatchWrapperAsync<boolean>(
      () => firstValueFrom(this._httpClient.get<boolean>(`api/products/${id}/instock`, 
        { params: new HttpParams().set("count", amount) })), 
      false
    );
  }

  // TODO: move somewhere else to the shared module if used in multiple services
  private async tryCatchWrapperAsync<T>(callback: () => Promise<T>, fallbackValue: T): Promise<T> {
    try {
      return await callback();
    } catch (error) {
      // TODO: handle error. show toast or something like this
      return fallbackValue;
    }
  }
}
