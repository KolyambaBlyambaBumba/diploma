<template>
  <div class="catalog">
    <ProductCard v-for="product in products" :key="product.id" v-bind="product" @addToCart="() => addToCart(product.id)"/>
  </div>
</template>

<script>
import ProductCard from '@/components/ProductCard.vue'
import productService from '@/services/ProductService'
import cartService from "@/services/CartService";

export default {
  name: 'CatalogView',
  components: {
    ProductCard
  },
  data () {
    return {
      products: []
    }
  },

  methods: {
    async addToCart(productId) {
      cartService.add(productId, 1)
      await this.loadProducts()
    },

    async loadProducts() {
      const cartProducts = cartService.getCartProducts()
      this.products = (await productService.getProducts())
        .map(p => ({
          ...p,
          isInCart: Boolean(cartProducts.find(cp => cp.productId === p.id))
        }))
    }
  },

  async created () {
    await this.loadProducts()
  }
}
</script>

<style lang="scss" scoped>
  .catalog {
    max-width: 1200px;
    width: 100%;
    display: flex;
    flex-wrap: wrap;
    justify-content: space-around;
  }
</style>
