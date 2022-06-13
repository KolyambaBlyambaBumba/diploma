<template>
    <div class="product_card">
      <img :src="product.image" alt="">
      <div class="card_container">
        <div class="product_name"><h3>{{ product.name }}</h3></div>
        <input class="count" type="number" min="1" max="99" :value="currentCount" @change="onCountChange">
        <input class="remove_button" type="button" value="Удалить" @click="removeFromCart">
        <div class="product_cost">{{ sum }} руб.</div>
      </div>
    </div>
</template>

<script>
  export default {
    name: 'CartProductCard',
    props: {
      product: {
        image: String,
        name: String,
        cost: Number,
        id: String
      },
      count: Number,
      sum: Number
    },

    emits: [ 'countChange', 'remove' ],

    data() {
      return {
        currentCount: this.count
      }
    },

    methods: {
      removeFromCart() {
        this.$emit('remove')
      },

      onCountChange(e) {
        let newCount = e.target.valueAsNumber;
        // Валидация, чтобы не установить меньше 1 и больше 99
        if (newCount < 1) {
          newCount = 1;
        }
        else if (newCount > 99) {
          newCount = 99;
        }

        this.currentCount = newCount;
        this.$emit('countChange', newCount)
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
