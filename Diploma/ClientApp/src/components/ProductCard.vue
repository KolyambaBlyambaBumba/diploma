<template>
    <div class="product_card">
      <div class="img_container">
        <img :src="image" alt="">
      </div>
      <div class="product_name"><h3>{{ name }}</h3></div>
      <div class="product_description">{{ description }}</div>
      <div class="product_cost">{{ cost }} руб.</div>
      <transition name="mode-fade" mode="out-in">
        <input class="card_btn" type="button" value="В корзину" @click="addToCart" v-if="!isInCart">
        <router-link to="/cart" v-else>
        <input class="card_btn_done" type="button" value="В корзине">
        </router-link>
      </transition>
    </div>
</template>

<script>
export default {
  name: 'ProductCard',
  props: {
    image: String,
    name: String,
    description: String,
    cost: Number,
    id: String,
    isInCart: Boolean
  },
  emits: [ 'addToCart' ],
  methods: {
    addToCart () {
      this.$emit('addToCart')
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
  }

  .img_container {
    width: 300px;
    height: 200px;
    display: flex;
    justify-content: center;

    img {
      max-width: 300px;
      max-height: 200px;
      border-radius: 3px;
    }
  }

  .product_name {
    h3 {
      font-size: 14pt;
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

  .mode-fade-enter-active, .mode-fade-leave-active {
    transition: opacity .3s ease;
  }

  .mode-fade-enter-from, .mode-fade-leave-to {
    opacity: 0
  }
</style>
