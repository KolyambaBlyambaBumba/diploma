class CartService {
  add (productId, count) {
    debugger
    const cart = JSON.parse(localStorage.getItem('cart') || '[]')
    const product = cart.filter((item) => item.productId === productId)[0]

    product ? product.count += count : cart.push({ productId, count })

    localStorage.setItem('cart', JSON.stringify(cart))
  }

  remove (productId, count) {

  }

  async getProducts () {

  }
}

export default new CartService()
