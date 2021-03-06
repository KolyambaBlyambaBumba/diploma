<template>
  <PopupForm v-model:popup-visible="popupVisible"/>
  <div class="cart">
    <div v-if="cart.cartProducts.length">
      <transition-group name="product_list">
        <cart-product-card v-for="cartProduct in cart.cartProducts"
         :key="cartProduct.product.id"
         v-bind="cartProduct"
         @remove="() => removeFromCart(cartProduct.product.id)"
         @countChange="newCount => changeCount(cartProduct.product.id, newCount)"
        />
      </transition-group>
    </div>
    <div class="cart_empty" v-else>Ваша корзина пуста</div>
    <div class="total_sum_container" v-if="cart.cartProducts.length">
      <div class="total_sum">Итого: {{cart.sum}} руб.</div>
    </div>
  </div>
  <input v-if="cart.cartProducts.length" class="cart_form_btn" type="button" value="Заказать" @click="popupOpen">
</template>

<script>
import PopupForm from '@/components/PopupForm'
import CartProductCard from '@/components/CartProductCard'
import cartService from "@/services/CartService"

export default {
  name: 'CartView',
  components: {
    PopupForm,
    CartProductCard
  },
  data: function () {
    return {
      cart: {
        cartProducts: [],
        count: 0,
        sum: 0
      },
      popupVisible: false,
    }
  },

  async created () {
    // Добавляем подписку для перезагрузки представления корзины при ее изменении
    this.cartChangeUnsubscription = cartService.on('change', async () => await this.loadCart())
    await this.loadCart()
  },

  unmounted() {
    this.cartChangeUnsubscription()
  },

  methods: {
    async removeFromCart(productId) {
      cartService.remove(productId)
    },

    async changeCount(productId, newCount) {
      const cartProduct = this.cart.cartProducts.filter(p => p.product.id === productId)[0]
      cartService.add(productId, newCount - cartProduct.count)
    },

    async loadCart() {
      this.cart = await cartService.getCartFullInfo()
    },

    popupOpen() {
      this.popupVisible = true
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
  margin-bottom: 60px;
}

.cart_form_btn:hover {
  background-color: #f0c800;
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

.product_list-item {
  display: inline-block;
  margin-right: 10px;
}
.product_list-enter-active,
.product_list-leave-active {
  transition: all .3s ease;
}
.product_list-enter-from,
.product_list-leave-to {
  opacity: 0;
  transform: translateX(50px);
}
</style>
