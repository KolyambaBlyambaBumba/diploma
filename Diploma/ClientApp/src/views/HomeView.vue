<template>
  <div class="home">
    <div class="home_content">
      <img src="@/assets/s123.png" alt="">
    </div>
  </div>
  <vue-carousel :data="data" :controls="false"></vue-carousel>
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
        `<div class="example-slide"><img src="${s123}" alt=""></div>`,
        `<div class="example-slide"><img src="${s123}" alt=""></div>`,
        `<div class="example-slide"><img src="${s123}" alt=""></div>`
      ]
    }
  }
}
</script>

<style lang="scss" scoped>
  .home {
    background-color: lightblue;
    display: flex;
    align-items: center;
    max-width: 1200px;
    width: 100%;
    flex-direction: column;

    img {
      width: 220px;
    }
  }
</style>
