<template>
    <div class="cart">
      <div class="product_card">
        <img src="@/assets/s123.png" alt="">
        <div class="card_container">
          <div class="product_name"><h3>Name</h3></div>
          <div class="product_description">Text</div>
          <div class="product_cost">123 руб.</div>
        </div>
          <input class="count" type="number" name="" value="1" min="1" max="99">
          <input class="remove_button" type="button" value="remove">
      </div>
      
      <div class="product_card">
        <img src="@/assets/s123.png" alt="">
        <div class="card_container">
          <div class="product_name"><h3>Name</h3></div>
          <div class="product_description">Text</div>
          <div class="product_cost">123 руб.</div>
        </div>
          <input class="count" type="number" name="" value="1" min="1" max="99">
          <input class="remove_button" type="button" value="remove">     
      </div><div class="product_card">
        <img src="@/assets/s123.png" alt="">
        <div class="card_container">
          <div class="product_name"><h3>Name</h3></div>
          <div class="product_description">Text</div>
          <div class="product_cost">123 руб.</div>
        </div>
          <input class="count" type="number" name="" value="1" min="1" max="99">
          <input class="remove_button" type="button" value="remove">     
      </div>
    </div>
</template>

<script>

export default {
  name: 'CartView',
  components: {
  }
}
</script>

<style lang="scss" scoped>
  .cart {
    display: flex;
    max-width: 1200px;
    width: 100%;
    flex-direction: column;
  }

  .product_card {
    max-width: 500px;
    display: flex;
    flex-direction: row;
    align-items: center;
    font-size: 9pt;
    margin: 10px 25px 0;
    padding-bottom: 10px;
    border-bottom: 1px solid #000;
    

    img {
      max-width: 200px;
      margin-right: 10px;
    }

    input {
      margin-left: 10px;
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
    font-size: 10pt;
    margin: 5px 0;
  }

  .count {
    width: 30px;
    text-align: center;
  }

  .remove_button {

  }
</style>
