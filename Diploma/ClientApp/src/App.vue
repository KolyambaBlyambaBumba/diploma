<template>
  <div class="header_wrapper"></div>
  <div class="header">
    <div class="header_top">
      <div class="header_top_text"><strong>Сувенирное мыло ручной работы <br>в Витебске</strong></div>
      <div class="logo">
        <a href="/"><img src="@/assets/logo.png" alt=""></a>
      </div>
      <div class="tel">
        <a href="tel:+375298185951">+375 29 818 59 51 МТС</a><br>
        <a href="tel:+375445712753">+375 44 571 27 53 А1</a>
      </div>
    </div>

    <div class="header_bottom">
      <nav class="nav">
        <router-link to="/" class="nav_rl">Главная</router-link>
        <router-link to="/catalog" class="nav_rl">Каталог</router-link>
        <router-link to="/delivery" class="nav_rl">Оплата и доставка</router-link>
        <router-link to="/contacts" class="nav_rl">Контакты</router-link>
      </nav>
      <router-link to="/cart" class="nav_cart">Корзина
        <span class="nav_cart_count" v-if="productsInCart">{{ productsInCart }}</span>
      </router-link>
    </div>
  </div>

  <router-view />
  <div class="footer">
    <p>2022 © Все права защищены</p>
    <div class="links">
      <a href="https://vk.com/alwa_soap">
        <img src="@/assets/vk_link.svg" alt="" id="vk_img">
      </a>
      <a href="https://instagram.com/alwa_soap?igshid=YmMyMTA2M2Y=">
        <img src="@/assets/instagram_link.svg" alt="" id="instagram_img">
      </a>
    </div>
  </div>
</template>

<script>
import cartService from "@/services/CartService";

export default {
  components: {},
  data() {
    return {
      productsInCart: 0
    };
  },

  created() {
    const updateProductsInCart = () => this.productsInCart = cartService.getCartProducts().length
    this.cartChangeUnsubscription = cartService.on("change", updateProductsInCart)
    updateProductsInCart()
  },

  unmounted() {
    this.cartChangeUnsubscription()
  }
}
</script>

<style lang="scss">
* {
  margin: 0;
  padding: 0;
}

#app {
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  font-size: 14pt;
  font-family: Roboto, sans-serif;
  font-weight: normal;
}

.header_wrapper {
  display: flex;
  max-width: 1200px;
  width: 100%;
  height: 165px;
  margin-bottom: 10px;
}

.header {
  display: flex;
  justify-content: space-around;
  align-items: center;
  max-width: 1200px;
  width: 100%;
  flex-direction: column;
  position: fixed;
  top: 0;
  z-index: 99;
  background-color: #fff;
}

.header_top {
  display: flex;
  width: 100%;
  justify-content: space-between;
  margin-top: 10px;
  margin-bottom: 10px;
  align-items: center;

  .header_top_text {
    max-width: 20%;
    margin-left: 20px;
  }

  strong {
    margin: 0;
    font-size: 0.65em;
    font-weight: normal;
  }
}

.tel a{
  max-width: 20%;
  font-size: 0.65em;
  margin-right: 20px;
  text-decoration: none;
  color: inherit;
}

.logo img {
  width: 160px;
  transition: 1s;

  &:hover {
    transform: scale(1.4);
  }
}

.header_bottom {
  display: flex;
  width: 100%;
  height: 60px;
  background-color: #333;
  justify-content: space-between;
  align-items: center;
  border-radius: 3px;
}

.nav {
  display: flex;
  list-style-type: none;
  width: 80%;
  padding-left: 50px;

  .nav_rl {
    text-decoration: none;
    margin-right: 50px;
    //color: #754847;
    color: #fff;
    position: relative;
  }

  .nav_rl::before {
    content: '';
    bottom: 0;
    left: 0;
    position: absolute;
    width: 100%;
    height: 2px;
    background-color: #fff;
    transform: scaleX(0);
    transition: 0.1s;
  }

  .nav_rl:hover::before {
    text-decoration: underline;
    text-underline-offset: 3px;
    text-decoration-thickness: 2px;
    transform: scaleX(1);
  }
}

.nav_cart {
  margin-right: 50px;
  text-decoration: none;
  color: #fff;
  position: relative;
}

.nav_cart::before {
    content: '';
    bottom: 0;
    left: 0;
    position: absolute;
    width: 100%;
    height: 2px;
    background-color: #fff;
    transform: scaleX(0);
    transition: 0.1s;
  }

  .nav_cart:hover::before {
    text-decoration: underline;
    text-underline-offset: 3px;
    text-decoration-thickness: 2px;
    transform: scaleX(1);
  }

  .nav_cart_count {
    position: absolute;
    width: 25px;
    height: 25px;
    border: 3px solid #64aa00;
    border-radius: 50%;
    background-color: #64aa00;
    text-align: center;
    right: -30px;
    bottom: 0;
    box-sizing: border-box;
    font-size: 12pt;
    font-weight: 600;
    padding-right: 1px;
    padding-top: 1px;
  }

.footer {
  display: flex;
  justify-content: space-between;
  align-items: center;
  max-width: 1200px;
  width: 100%;
  height: 50px;
  background-color: #333;
  border-radius: 3px;
  color: #fff;
  margin-top: 10px;
  position: fixed;
  bottom: 0;

  p {
    margin-left: 20px;
    font-size: 8pt;
  }
}

.links {
  display: flex;
  align-items: center;
  margin-right: 20px;

  a {
    height: 25px;
  }
}

#vk_img {
  width: 25px;

  &:hover {
    transform: scale(1.1);
  }
}

#instagram_img {
  width: 25px;
  margin-left: 10px;

  &:hover {
    transform: scale(1.1);
  }
}
</style>
