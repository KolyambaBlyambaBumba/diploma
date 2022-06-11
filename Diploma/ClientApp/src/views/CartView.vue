<template>
  <div class="cart">
    <cart-product-card v-for="cartProduct in cart.cartProducts"
      :key="cartProduct.product.id"
      v-bind="cartProduct"
      @remove="() => removeFromCart(cartProduct.product.id)"
      @countChange="newCount => changeCount(cartProduct.product.id, newCount)"
    />
    <div class="total_sum_container">
      <div class="total_sum">Итого: {{cart.sum}} руб.</div>
    </div>
    <div class="cart_empty">Ваша корзина пуста</div>
  </div>
  <input class="cart_form_btn" type="button" value="Заказать">
</template>

<script>

import CartProductCard from '@/components/CartProductCard'
import cartService from "@/services/CartService";

export default {
  name: 'CartView',
  components: {
    CartProductCard
  },
  data: function () {
    return {
      cart: {
        cartProducts: [],
        count: 0,
        sum: 0
      }
    }
  },

  async created () {
    await this.loadCart()
  },

  methods: {
    async removeFromCart(productId) {
      cartService.remove(productId)
      await this.loadCart()
    },

    async changeCount(productId, newCount) {
      const cartProduct = this.cart.cartProducts.filter(p => p.product.id === productId)[0]
      cartService.add(productId, newCount - cartProduct.count)
      await this.loadCart()
    },

    async loadCart() {
      this.cart = await cartService.getCartFullInfo()
    },

    clearCart() {
      cartService.clear()
      this.loadCart()
    }
  }
}
</script>

<style lang="scss" scoped>
.cart {
  display: flex;
  max-width: 1200px;
  width: 100%;
  flex-direction: column;
  position: relative;
}

.cart_form_btn {
  max-width: 100px;
  padding: 10px 15px;
  cursor: pointer;
  border: 0;
  border-radius: 3px;
  background-color: #ffdc00;
  color: #000;
  font-size: 11pt;
  font-weight: 600;
  transition: .1s;
}

.cart_form_btn:hover {
  background-color: #f0c800;
}

.cart_form_btn:active {
  background-color: #ff3205;
}

.total_sum_container {
  position: absolute;
  right: 10px;
  margin-top: 30px;
}

.total_sum {
  position: fixed;
  transform: translateX(-100%);
  min-width: 160px;
  font-weight: 600;
  font-size: 13pt;
  text-decoration: underline;
  text-underline-offset: 3px;
  text-decoration-thickness: 2px;
}

.cart_empty {
  display: flex;
  justify-content: center;
  align-items: center;
  color: #333;
  height: 500px;
}
</style>
