<template>
  <div class="home">
    <div class="home_content">
      <img src="@/assets/s123.png" alt="">
    </div>
  </div>
</template>

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

    img {
      width: 220px;

    }
  }
</style>
