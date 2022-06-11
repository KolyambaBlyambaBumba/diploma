<template>
  <div class="home">
    <div class="images_catalog">
      <div class="img_item"><img src="@/assets/home_images/i11.png" alt=""></div>
      <div class="img_item"><img src="@/assets/home_images/i22.jpg" alt=""></div>
      <div class="img_item"><img src="@/assets/home_images/i33.jpg" alt=""></div>
      <div class="img_item"><img src="@/assets/home_images/i44.jpg" alt=""></div>
      <div class="img_item"><img src="@/assets/home_images/i55.jpg" alt=""></div>
      <div class="img_item"><img src="@/assets/home_images/i66.jpg" alt=""></div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'HomeView',
  components: {
  },
  data () {
    return {

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

  .images_catalog {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
  }

  .img_item {
    display: flex;
    align-items: center;

    img {
      width: 290px;
      margin: 0 15px 10px 0;
    }
  }
</style>

<!--<style>-->
<!--.carousel_img {-->
<!--  max-width: 1180px;-->
<!--  max-height: 580px;-->
<!--  border-radius: 3px;-->
<!--  }-->
<!--</style>-->
