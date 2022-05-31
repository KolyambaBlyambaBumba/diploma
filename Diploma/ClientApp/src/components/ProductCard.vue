<template>
    <div class="product_card">
        <img :src="image" alt="">
        <div class="product_name"><h3>{{ name }}</h3></div>
        <div class="product_description">{{ description }}</div>
        <div class="product_cost">{{ cost }} руб.</div>
        <input type="button" value="В корзину">
    </div>
</template>

<script>
export default {
  name: 'ProductCard',
  props: {
    image: String,
    name: String,
    description: String,
    cost: Number
  }
}
</script>

<style lang="scss" scoped>
  .product_card {
    max-width: 300px;
    display: flex;
    flex-direction: column;
    align-items: center;
    font-size: 10pt;
    margin: 0 10px;
    margin-bottom: 25px;

    img {
      max-width: 300px;
    }
  }

  .product_name {
    h3 {
      font-size: 16pt;
      margin: 5px 0;
    }
  }

  .product_cost {
    font-weight: bold;
    font-size: 11pt;
    margin: 5px 0;
  }
</style>
