import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { firstValueFrom } from "rxjs";

@Injectable()
export class OrderService {

  constructor(protected _httpClient: HttpClient) { }
  
  // just a dummy implementation. api always return true
  public async sendOrder(): Promise<boolean> {
    try {
      return await firstValueFrom(this._httpClient.post<boolean>("api/orders", {}));
    } catch (error) {
      // TODO: handle error. show toast or something like this
      return false;
    }
  }
}
