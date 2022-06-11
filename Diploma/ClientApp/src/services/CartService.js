import productService from "@/services/ProductService";
import Observable from "@/utils/Observable";

class CartService {
  #changeObservable = new Observable('cartChange')

  add(productId, count) {
    const cart = this.getCartProducts();

    // Получаем продукт из корзины
    let product = cart.filter((item) => item.productId === productId)[0]

    // Если продукт в корзине есть, то увеличиваем кол-во
    if (product) {
      product.count += count
    }
    // Иначе добавляем новый продукт с переданным кол-м
    else {
      product = { productId, count }
      cart.push(product)
    }

    if (product.count < 1) {
      throw new Error("Количество не может быть меньше 1")
    }

    CartService.#saveCart(cart)

    this.#changeObservable.fire()
  }

  remove(productId) {
    const cart = this.getCartProducts()
    CartService.#saveCart(cart.filter((item) => item.productId !== productId))
    this.#changeObservable.fire()
  }

  getCartProducts() {
    return JSON.parse(localStorage.getItem('cart') || '[]')
  }

  async getCartFullInfo() {
    const cart = this.getCartProducts()
    const cartProducts = [];
    for (const { productId, count } of cart) {
      const product = await productService.getProductById(productId);
      cartProducts.push({
        product,
        count: count,
        sum: product.cost * count
      })
    }

    return {
      cartProducts,
      sum: cartProducts.reduce((sum, item) => sum += item.sum, 0)
    }
  }

  clear() {
    CartService.#saveCart([])
    this.#changeObservable.fire()
  }

  on(eventName, callback) {
    if (eventName !== "change") {
      throw new Error(`Некоректное имя события ${eventName}`)
    }

    return this.#changeObservable.subscribe(callback);
  }

  static #saveCart(cart) {
    localStorage.setItem('cart', JSON.stringify(cart))
  }
}

export default new CartService()
