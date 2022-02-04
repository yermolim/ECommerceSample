import { Product } from "./product";

export interface ProductCategory
{
  id: string;
  name: string;

  products: Product[];
}
