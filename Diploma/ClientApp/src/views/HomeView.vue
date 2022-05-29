<template>
  <div class="home">
    jompa
    <div class="home_content">
      <img src="@/assets/s123.png" alt="">
    </div>
  </div>
</template>"
<script>
// @ is an alias to /src

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
    margin-top: 165px;
    height: 700px;

    img {
      width: 100px;

    }
  }

  .home_content {
    background-color: indianred;
    height: 200px;
  }

</style>
