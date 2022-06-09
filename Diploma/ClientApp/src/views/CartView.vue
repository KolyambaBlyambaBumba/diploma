<template>
  <div class="cart">
    <cart-product-card v-for="product in products" :key="product.id" v-bind="product"></cart-product-card>
    <div class="total_sum_container">
      <div class="total_sum">Итого: 123,00 руб.</div>
    </div>
  </div>
  <input class="cart_form_btn" type="button" value="Заказать">
</template>

<script>

import CartProductCard from '@/components/CartProductCard'
import productService from '@/services/ProductService'
export default {
  name: 'CartView',
  components: {
    CartProductCard
  },
  data: function () {
    return {
      products: []
    }
  },

  async created () {
    this.products = await productService.getProducts()
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
</style>
