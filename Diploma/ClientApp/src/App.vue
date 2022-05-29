<template>

  <div class="header">
    <div class="hh"></div>
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
        <router-link to="/contact" class="nav_rl">Контакты</router-link>
      </nav>
      <div class="cart"><a href="">Корзина</a></div>
    </div>
  </div>

  <router-view/>
  <div class="footer">
    <div class="footer_info">text</div>
    <div class="links">
      <a href="https://vk.com/alwa_soap">1</a>
      <a href="https://vk.com/away.php?to=https%3A%2F%2Finstagram.com%2Falwa_soap%3Figshid%3DYmMyMTA2M2Y%3D&cc_key=">2</a>
    </div>
  </div>
</template>

<script>

</script>

<style lang="scss">
#app {
  display: flex;
  justify-content: center;
  flex-direction: column;
  align-items: center;
  font-size: 14pt;
  font-family: Roboto, sans-serif;
  font-weight: normal;
}

.header {
  display: flex;
  justify-content: space-around;
  align-items: center;
  max-width: 1200px;
  width: 100%;
  flex-direction: column;
  margin-bottom: 10px;
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

.cart {
  padding-right: 50px;
}

.footer {
  display: flex;
  justify-content: space-around;
  align-items: center;
  max-width: 1200px;
  width: 100%;
  height: 50px;
  align-items: center;
  background-color: #333;
  color: #fff;
  margin-top: 10px;
}

</style>
<script>export default {
  components: {}
}
</script>
