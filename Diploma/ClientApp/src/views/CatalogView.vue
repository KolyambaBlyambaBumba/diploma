<template>
  <div class="catalog">
    <ProductCard v-for="product in products" :key="product.name" v-bind="product"></ProductCard>
  </div>
</template>

<script>
import ProductCard from '@/components/ProductCard.vue'
import s123 from '@/assets/s123.png'

export default {
  name: 'CatalogView',
  components: {
    ProductCard
  },
  data () {
    return {
      products: [
        {
          image: s123,
          name: 'Букет',
          description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit quo autem ut.',
          cost: 25
        },
        {
          image: s123,
          name: 'Букет 2',
          description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit quo autem ut.',
          cost: 30
        }
      ]
    }
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
