import productService from "@/services/ProductService";
import Observable from "@/utils/Observable";

class CartService {
  #changeObservable = new Observable('cartChange')

  /**
   * Добавляет в корзину продукт с определенным кол-м
   * @this CartService
   * @param {String} productId Id продукта для добавления в корзину, если продукт с таким id уже в корзине, то просто будет изменено кол-во
   * @param {Number} count Кол-во, которое нужно добавить. Может быть отрицательным, в этом случае кол-во продуктов в корзине уменьшится
   * @throws {Error} Когда кол-во продуктов меньше 1
   */
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

  /**
   * Удаляет продукт из корзины
   * @this CartService
   * @param {String} productId Id продукта для удаления из корзины
   */
  remove(productId) {
    // Получаем текущие продукты корзины
    const cart = this.getCartProducts()
    // Удаляем из массива элемент с id === productId и сохраняем корзину
    CartService.#saveCart(cart.filter((item) => item.productId !== productId))
    this.#changeObservable.fire()
  }

  /**
   * Возвращает продукты корзины
   * @this CartService
   * @return [{productId: String, count: Number}]
   */
  getCartProducts() {
    // Достаем из localStorage JSON строку корзины и десериализуем ее в массив продуктов корзины
    return JSON.parse(localStorage.getItem('cart') || '[]')
  }

  /**
   * Возвращает полную информацию о корзине
   * @this CartService
   * @return {Promise<{cardProducts: [{product: Product, count: Number, sum: Number}], sum: Number}>}
   */
  async getCartFullInfo() {
    const cart = this.getCartProducts()
    const cartProducts = [];
    // Пробегаемся по всем продуктам корзины
    for (const { productId, count } of cart) {
      // Получает полную инфу о продукте по его id
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

  /**
   * Удаляеят все продукты из корзины
   * @this CartService
   */
  clear() {
    // Просто сохраняем пустой массив как продукты корзины
    CartService.#saveCart([])
    this.#changeObservable.fire()
  }

  /**
   * Подписаться на событие
   * @this CartService
   * @param {String} eventName Название события, на которое нужно подписаться
   * @param {Function} callback Ф-ция, которая будет вызвана при срабатывании события
   * @return {Function} Ф-цию, которую нужно вызвать для отписки
   * @throws {Error} Когда eventName !== 'change'
   */
  on(eventName, callback) {
    // У нас только одно доступное событие 'change'. Кидаем ошибку для всего остального
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
