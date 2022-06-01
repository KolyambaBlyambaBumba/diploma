<template>
  <div class="header_wrapper"></div>
  <div class="header">
    <div class="header_top">
      <div class="header_top_text"><strong>Сувенирное мыло ручной работы <br>в Витебске</strong></div>
      <div class="logo">
        <img src="@/assets/logo.png" alt="">
      </div>
      <div class="tel">+375 29 818 59 51 МТС<br>+375 44 571 27 53 А1</div>
    </div>

    <div class="header_bottom">
      <nav class="nav">
        <router-link to="/" class="nav_rl">Главная</router-link>
        <router-link to="/catalog" class="nav_rl">Каталог</router-link>
        <router-link to="/delivery" class="nav_rl">Оплата и доставка</router-link>
        <router-link to="/contacts" class="nav_rl">Контакты</router-link>
      </nav>
      <router-link to="/cart" class="nav_cart">Корзина</router-link>
    </div>
  </div>

  <router-view/>
  <div class="footer">
    <div class="footer_info">text</div>
    <div class="links">
      <a href="https://vk.com/alwa_soap"><img src="@/assets/vk_link.svg" alt="" id="vk_img"></a>
      <a href="https://instagram.com/alwa_soap?igshid=YmMyMTA2M2Y="><img src="@/assets/instagram_link.svg" alt="" id="insta_img"></a>
    </div>
  </div>
</template>

<script>
export default {
  components: {}
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
  z-index: 999;
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

.tel {
  max-width: 20%;
  font-size: 0.65em;
  margin-right: 20px;
}

.logo img {
  width: 160px;
}

.header_bottom {
  display: flex;
  width: 100%;
  height: 60px;
  background-color: #333;
  justify-content: space-between;
  align-items: center;
}

.nav {
  display: flex;
  list-style-type: none;
  width: 80%;
  padding-left: 50px;

  .nav_rl {
    text-decoration: none;
    padding-right: 50px;
    //color: #754847;
    color: #fff;
  }

  .nav_rl:hover {
    text-decoration: underline;
  }
}

.nav_cart {
  padding-right: 50px;
}

.footer {
  display: flex;
  justify-content: space-between;
  align-items: center;
  max-width: 1200px;
  width: 100%;
  height: 50px;
  align-items: center;
  background-color: #333;
  color: #fff;
  margin-top: 10px;
  position: fixed;
  bottom: 0;
}

.links {
  display: flex;
  align-items: center;

  a {
    height: 25px;
  }
}

#vk_img {
  width: 25px;

  &:hover {
    opacity: 0.8;
  }
}

#insta_img {
  width: 20px;

  &:hover {
    opacity: 0.8;
  }
}
</style>
