<template>
    <div class="product_card" v-if="rem">
      <img :src="image" alt="">
      <div class="card_container">
        <div class="product_name"><h3>{{ name }}</h3></div>
        <input class="count" type="number" min="1" max="99" :value="count">
        <input class="remove_button" type="button" value="Удалить" @click="removeFromCart">
        <div class="product_cost">{{ cost }} руб.</div>
      </div>
    </div>
</template>

<script>
  import cartService from '@/services/CartService'

  export default {
    name: 'CartProductCard',
    props: {
      image: String,
      name: String,
      cost: Number,
      count: Number,
      id: String
    },
    data () {
      return {
        rem: true
      }
    },
    methods: {
      removeFromCart () {
        cartService.remove(this.id, 1)
      }
    }
  }
</script>

<style lang="scss" scoped>
.product_card {
  max-width: 700px;
  display: flex;
  flex-direction: row;
  align-items: center;
  font-size: 9pt;
  margin: 0 0 10px 10px;
  padding-bottom: 10px;
  border-bottom: 1px solid rgba(51, 51, 51, 0.5);


  img {
    max-width: 200px;
    margin-right: 10px;
    border-radius: 3px;
  }
}

.card_container {
  display: flex;
}

.product_name {
  h3 {
    font-size: 14pt;
    margin-right: 50px;
    width: 150px;
    max-width: 150px;
  }
}

.product_cost {
  font-weight: bold;
  font-size: 12pt;
}

.count {
  width: 30px;
  text-align: center;
  margin-right: 20px;
}

.remove_button {
  padding: 0 10px;
  cursor: pointer;
  border: 0;
  border-radius: 3px;
  background-color: #808080;
  color: #fff;
  transition: .1s;
  margin-right: 50px;
}

.remove_button:hover {
  background-color: #6e6e6e;
}
</style>
