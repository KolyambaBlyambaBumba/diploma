<template>
  <div class="catalog">
    <ProductCard v-for="product in products" :key="product.id" v-bind="product"></ProductCard>
  </div>
</template>

<script>
import ProductCard from '@/components/ProductCard.vue'
import productService from '@/services/ProductService'

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

  async created () {
    this.products = await productService.getProducts()
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
