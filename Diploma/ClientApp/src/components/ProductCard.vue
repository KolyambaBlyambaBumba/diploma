<template>
    <div class="product_card">
        <img src="@/assets/s123.png" alt="">
        <div class="product_name"><h3>букет</h3></div>
        <div class="product_description">Lorem ipsum dolor sit amet consectetur adipisicing elit. Suscipit quo autem ut.</div>
        <div class="product_cost">25 руб.</div>
        <input type="button" value="в корзину">
    </div>
</template>

<script>
export default {
  name: 'ProductCard',
  components: {
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
