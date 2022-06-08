<template>
    <div class="product_card">
        <img :src="image" alt="">
        <div class="product_name"><h3>{{ name }}</h3></div>
        <div class="product_description">{{ description }}</div>
        <div class="product_cost">{{ cost }} руб.</div>
        <input class="card_btn" type="button" value="В корзину" @click="addToCart">
        <router-link to="/cart">
          <input class="card_btn_done" type="button" value="В корзине">
        </router-link>
    </div>
</template>

<script>
import cartService from '@/services/CartService'

export default {
  name: 'ProductCard',
  props: {
    image: String,
    name: String,
    description: String,
    cost: Number,
    id: String
  },
  methods: {
    addToCart () {
      cartService.add(this.id, 1)
    }
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
    margin: 0 10px 25px;

    img {
      max-width: 300px;
      border-radius: 3px;
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

  .card_btn {
    padding: 7px 12px;
    cursor: pointer;
    border: 0;
    border-radius: 3px;
    background-color: #f07800;
    color: #fff;
    transition: .1s;
  }

  .card_btn:hover {
    background-color: #dc780a;
  }

  .card_btn_done {
    padding: 7px 12px;
    cursor: pointer;
    border: 0;
    border-radius: 3px;
    background-color: #64aa00;
    color: #fff;
    transition: .1s;
    //display: none;
  }

  .card_btn_done:hover {
    background-color: #64b428;
  }
</style>
