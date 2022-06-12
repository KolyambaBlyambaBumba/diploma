<template>
  <transition name="bounce">
    <div class="popup_overlay" @click="popupClose" v-if="popupVisible">
    <div class="popup" @click.stop>
      <div class="popup_close" @click="popupClose">x</div>
      <div class="popup_title">Оставить заявку</div>
      <form action="">
        <div class="popup_form">
          <label for="name">Введите имя *</label>
          <input type="text" id="name" required placeholder="Имя">
          <label for="email">Введите E-mail *</label>
          <input type="text" id="email" required placeholder="email@mail.by">
          <label for="tel">Введите номер телефона</label>
          <input type="tel" id="tel" placeholder="+375291234567">
          <input type="submit" id="cart_submit" value="Отправить" @click="popupClose">
        </div>
      </form>
    </div>
    </div>
  </transition>
</template>

<script>
  export default {
    name: 'PopupForm',

    props: {
      popupVisible: {
        type: Boolean,
        default: false
      }
    },

    methods: {
      popupClose () {
        this.$emit('update:popupVisible', false)
      }
    }
  }
</script>

<style lang="scss" scoped>
  .popup_overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    z-index: 999;
  }

  .popup {
    position: absolute;
    width: 350px;
    height: 400px;
    background-color: #fff;
    top: 200px;
    left: 50%;
    margin-left: -190px;
    z-index: 1000;
    border-radius: 3px;
  }

  .popup_close {
    position: absolute;
    top: 15px;
    right: 15px;
    cursor: pointer;
    color: #000;
    width: 20px;
    height: 20px;
    font-size: 14pt;
  }

  .popup_close:hover {
    transform: scale(1.2);
  }

  .popup_title {
    margin-left: 15px;
    margin-top: 15px;
    font-size: 15pt;
  }

  .popup_form {
    display: flex;
    flex-direction: column;
    align-items: flex-start;

    label {
      margin-bottom: 5px;
      margin-top: 30px;
      margin-left: 15px;
    }

    input {
      width: 88%;
      height: 30px;
      font-size: 14pt;
      margin-left: 15px;
      padding-left: 5px;
    }
  }

  #cart_submit {
    width: 91%;
    margin-top: 40px;
    cursor: pointer;
    border: 0;
    border-radius: 3px;
    background-color: #ffdc00;
    font-size: 12pt;
    font-weight: 600;
    transition: .1s;
  }

  #cart_submit:hover {
    background-color: #f0c800;
  }

  .bounce-enter-active {
    animation: bounce-in .3s ease-out both;
  }

  .bounce-leave-active {
    animation: bounce-in .3s reverse ease-in both;
  }

  @keyframes bounce-in {
    0% {
      transform: scale(0);
    }

    100% {
      transform: scale(1);
    }
  }
</style>
