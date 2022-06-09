<template>
  <div class="home">
    <vue-carousel :data="data" :controls="false" indicator-type="disc" :interval="1000" class="carousel_div"></vue-carousel>
  </div>
</template>

<script>
import VueCarousel from '@chenfengyuan/vue-carousel'
import s123 from '@/assets/s123.png'

export default {
  name: 'HomeView',
  components: {
    VueCarousel
  },
  data () {
    return {
      data: [
        `<div><img src="${s123}" alt="" class="carousel_img"></div>`,
        `<div><img src="${s123}" alt="" class="carousel_img"></div>`,
        `<div><img src="${s123}" alt="" class="carousel_img"></div>`,
        `<div><img src="${s123}" alt="" class="carousel_img"></div>`,
        `<div><img src="${s123}" alt="" class="carousel_img"></div>`
      ]
    }
  }
}
</script>

<style lang="scss" scoped>
  .home {
    display: flex;
    align-items: center;
    max-width: 1200px;
    width: 100%;
    height: 100%;
    flex-direction: column;
  }
</style>

<style>
.carousel_img {
  max-width: 1180px;
  max-height: 580px;
  border-radius: 3px;
  }
</style>
