<template>
    <div class="contacts">
      <div class="container_one">
        <h3>Обо мне</h3>
        <p>Меня зовут Алина, и я Ваш личный мыловар!</p>
        <p>Моя душа всегда тянулась к творчеству, а мозги – к учебе. <br>И я пошла на курсы по мыловарению, чем убила двух зайцев сразу.</p>
        <p>Моя цель – дарить возможность вам радовать своих близких подарками из мыла.</p>
      </div>

      <div class="container_two">
        <p>Режим работы: ПН-ПТ 12.00-20.00</p>
        <p>Сб, вс. 10.00-20.00</p>
        <p>На сайте заказы принимаются круглосуточно, обрабатываются в рабочее время.</p>
      </div>

      <div class="container_three">
        <p>Телефоны:</p>
        <a href="tel:+375298185951">+375 29 818 59 51 МТС</a>
        <a href="tel:+375445712753">+375 44 571 27 53 А1</a>
        <p>Почта:</p>
        <a href="mailto:alwasoap@yandex.ru">alwasoap@yandex.ru</a>
        <p>Адрес: Республика Беларусь, г. Витебск р-н Билево</p>
        <p>Актуальная информация о нас и общение онлайн на страницах в социальных сетях.</p>
        <a href="https://vk.com/alwa_soap">ВК</a>
        <a href="https://instagram.com/alwa_soap?igshid=YmMyMTA2M2Y=">Инстаграм</a>
      </div>
    </div>
</template>

<script>
export default {
  name: 'ContactsView',
  components: {
  }
}
</script>

<style lang="scss" scoped>
  .contacts {
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .container_one, .container_two, .container_three {
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .container_one {

    h3 {
      font-size: 14pt;
      margin-bottom: 10px;
    }

    p {
      font-size: 12pt;
      margin-bottom: 10px;
    }
  }

  .container_two {
    margin-top: 25px;

    p {
      font-size: 12pt;
      margin-bottom: 10px;
    }

    p:nth-child(1) {
      margin-bottom: 0;
    }
  }

  .container_three {
    margin-top: 25px;

    p {
      font-size: 12pt;
      margin-bottom: 10px;
    }

    a {
      font-size: 12pt;
      text-decoration: none;
    }

    p:first-child {
      margin: 1px;
    }

    a:nth-child(3) {
      margin-bottom: 10px;
    }

    p:nth-child(4) {
      margin: 1px;
    }

    a:nth-child(5) {
      margin-bottom: 25px;
    }

    a:hover {
      text-decoration: underline;
    }
  }


























</style>
