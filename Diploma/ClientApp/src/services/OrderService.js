import cartService from "@/services/CartService";

const apiUrl = process.env.VUE_APP_API_ROOT

class OrderService {
  async createOrderFromCart(name, email, phone) {
    const body = {
      name,
      email,
      phone: phone || null,
      items: cartService.getCartProducts()
    }

    const response = await fetch(`${apiUrl}/api/orders`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(body)
    });

    if (!response.ok)
    {
      throw new Error("Ошибка при отправке заказа")
    }

    cartService.clear()
  }
}

export default new OrderService()
