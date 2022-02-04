import { Product } from "./product";

export interface CartContentItem {
  product: Product; 
  amount: number;
}

export class CartContent {
  private _items: CartContentItem[];
  get items(): CartContentItem[] {
    return this._items;
  }
  set items(value: CartContentItem[]) {
    this._items = value ?? [];
  }

  constructor(items: CartContentItem[]) {
    this.items = items;
  }

  get length(): number {
    return this._items.length;
  }

  get totalPrice(): number {
    return this.items.reduce((pv, cv) => pv + cv.amount * cv.product.price, 0);
  }

  addToCart(product: Product, amount: number) {
    if (!product || !amount || amount < 1) {
      return;
    }
    amount = Math.floor(amount);

    const found = this._items.find(i => i.product.id === product.id);
    if (found) {
      found.amount += amount;
    } else {
      this._items.push({product, amount});
    }
  }

  clearCart() {
    this._items = [];
  }
}
