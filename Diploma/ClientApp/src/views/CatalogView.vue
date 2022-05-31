<template>
  <div class="catalog">
    <ProductCard></ProductCard>
  </div>
</template>

<script>
import ProductCard from '@/components/ProductCard.vue'
export default {
  name: 'CatalogView',
  components: {
    ProductCard
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
