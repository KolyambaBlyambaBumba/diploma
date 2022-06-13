const apiUrl = process.env.VUE_APP_API_ROOT

class ProductService {
  /**
   * Получить список всех продуктов
   * @this ProductService
   * @return {Promise<Product[]>}
   */
  async getProducts() {
    return await (await fetch(`${apiUrl}/api/products`)).json()
  }

  /**
   * Получить продукт по его id
   * @this ProductService
   * @param {String} id Id продукта
   * @return {Promise<Product>}
   */
  async getProductById(id) {
    return await (await fetch(`${apiUrl}/api/products/${id}`)).json()
  }
}

export default new ProductService()
