<template>
  <div class="home">
    jompa
    <div class="home_content">
      <img src="@/assets/s123.png" alt="">
    </div>
  </div>
</template>"
<script>
export default {
  name: 'HomeView',
  components: {
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
    height: 100px;

    img {
      width: 100px;

    }
  }

  .home_content {
    background-color: indianred;
    height: 200px;
  }

</style>
