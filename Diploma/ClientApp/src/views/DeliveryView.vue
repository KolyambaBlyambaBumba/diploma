<template>
    <div class="delivery">
      <div class="del_container_one">
        <h3>Сроки изготовления:</h3>
        <ul>
          <li>букетов 3-5 дней</li>
          <li>сувенирного мыла 2-3 дня</li>
          <li>бомбочек для ванн 5-7 дней</li>
        </ul>
        <p>В период праздников сроки могут быть увеличены, в зависимости от загруженности</p>
      </div>

      <div class="del_container_two">
        <h3>Доставка:</h3>
        <ul>
          <li>Самовывоз г. Витебск по предварительной оговоренности.</li>
          <li>Доставка по городу до подъезда при заказе от 50 рублей.</li>
          <li>Пересылка белпочтой: стоимость пересылки оплачивается покупателем в почтовом отделении в соответствии с тарифами Белпочты</li>
          <li>Пересылка европочтой: стоимость пересылки оплачивается покупателем в почтовом отделении  в соответствии с тарифами Европочты</li>
        </ul>
        <h3>Оплата:</h3>
        <ul>
          <li>Оплата наличными денежными средствами при доставке по городу и самовывозе </li>
          <li>Оплата наложенным платежом: услуга почты дает вам возможность оплатить товар при получении заказа в почтовом отделении</li>
        </ul>
        <p>Другие способы оплаты оговариваются по телефону или электронной почте.</p>
      </div>
    </div>
</template>

<script>
export default {
  name: 'DeliveryView',
  components: {
  }
}
</script>

<style lang="scss" scoped>
  .delivery {
    margin-left: 50px;
  }
  .del_container_one {
    display: flex;
    flex-direction: column;

    h3 {
      margin-bottom: 10px;
      text-transform: uppercase;
      font-size: 14pt;
    }

    li {
      margin: 10px 0;
      list-style: none;
      font-size: 12pt;
    }

    li:before {
      content: '-';
      position: relative;
      left: -5px;
    }

    p {
      margin-top: 10px;
      font-size: 12pt;
    }
  }

  .del_container_two {
    display: flex;
    flex-direction: column;

    h3 {
      margin-top: 30px;
      margin-bottom: 10px;
      text-transform: uppercase;
      font-size: 14pt;
    }

    li {
      margin: 10px 0;
      font-size: 12pt;
      list-style: decimal;
    }

    p {
      margin-top: 10px;
      font-size: 12pt;
    }
  }
</style>
