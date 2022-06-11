const apiUrl = process.env.VUE_APP_API_ROOT

class ProductService {
  async getProducts() {
    return await (await fetch(`${apiUrl}/api/products`)).json()
  }

  async getProductById(id) {
    return await (await fetch(`${apiUrl}/api/products/${id}`)).json()
  }
}

export default new ProductService()
