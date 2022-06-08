<template>
  <cart-product-card v-for="product in products" :key="product.id" v-bind="product"></cart-product-card>
  <input class="cart_form" type="button" value="Заказать">
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
.cart_form {
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

.cart_form:hover {
  background-color: #f0c800;
}

.cart_form:active {
  background-color: #ff3205;
}
</style>
