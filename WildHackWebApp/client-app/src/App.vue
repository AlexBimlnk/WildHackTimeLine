<template>
  <div class="app" :class="{'timeline-tab': $route.fullPath === '/timeline'}">
    <main-navbar :isTimeline="$route.fullPath === '/timeline'" />
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
  padding-top: 112px;
}
.container-timeline {
  width: 650px;
  margin: 0 auto;
}
.timeline-tab {
  height: 100vh;
  overflow: hidden;
}
.collapsible-body, .collapsible-body p{
  background-color: #F0F0F0;
}
</style>
