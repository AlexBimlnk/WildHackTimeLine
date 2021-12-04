<template>
  <div class="app">
    <main-navbar />
    <router-view />
  </div>
</template>

<script>
import mainNavbar from "./components/mainNavbar.vue"
export default {
  components: {
    mainNavbar
  }
}
</script>

<style lang="less">
.app {
  background-color: #F0F0F0;
}
.container-timeline {
  width: 650px;
  margin: 0 auto;
}
</style>
