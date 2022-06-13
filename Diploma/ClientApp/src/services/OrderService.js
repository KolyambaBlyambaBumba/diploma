import cartService from "@/services/CartService";

const apiUrl = process.env.VUE_APP_API_ROOT

class OrderService {
  /**
   * Создать заказ из содержимого корзины
   * @this OrderService
   * @param {String} name Имя заказчика
   * @param {String} email Email заказчика
   * @param {String} phone Телефон заказчика
   * @return {Promise}
   * @throws {Error} Когда не удалось создать заказ
   */
  async createOrderFromCart(name, email, phone) {
    // Формируем тела заказа
    const body = {
      name,
      email,
      phone: phone || null,
      items: cartService.getCartProducts()
    }

    // Отправляем HTTP запрос за сервер для создания заказа
    const response = await fetch(`${apiUrl}/api/orders`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      // Сериализуем заказ в JSON и помещаем в тело запроса
      body: JSON.stringify(body)
    });

    // Если не удалось создать заказ, кидаем ошибку
    if (!response.ok)
    {
      throw new Error("Ошибка при отправке заказа")
    }

    // Очищаем корзину после успешного создания заказа
    cartService.clear()
  }
}

export default new OrderService()
