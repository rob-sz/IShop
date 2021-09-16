import * as service from './Service';

export interface Category {
    name: string,
    description: string
};

export interface Product {
    id: string,
    name: string,
    description: string,
    category: Category
};

export interface ProductResult {
    products: Product[]
};

export const getProducts = async (category: string, keyword: string) => {
    const response = await service.api.get<ProductResult>(
        "/Products", 
        {
            "Category": category, 
            "Keyword": keyword
        });
  
    if (response.ok && response.data) {
      //alert(JSON.stringify(response.data));
      return (response.data);
    }
  };
  