<template>
  <div class="main-navbar">
    <span @click="isSidebar = !isSidebar" class="material-icons my-menu">
      menu
    </span>
    <transition>
      <my-sidebar v-if="isSidebar" />
    </transition>

    <nav class="nav-extended" :class="{ 'nav-timeline': isTimeline }">
      <div class="container">
        <div class="nav-wrapper">
          <a href="#" class="brand-logo center">Новости Камчатки</a>
          <a href="#" data-target="mobile-demo" class="sidenav-trigger"
            ><i class="material-icons sidenav-overlay">menu</i></a
          >
        </div>
        <div class="nav-content">
          <ul class="tabs tabs-transparent">
            <li class="tab"><router-link to="/">Лента</router-link></li>
            <li class="tab">
              <router-link to="/timeline">Таймлайн</router-link>
            </li>
            <li class="tab">
              <router-link to="/newPost">Предложить пост</router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
import mySidebar from "./mySidebar.vue";
export default {
  props: {
    isTimeline: {
      type: Boolean,
    },
  },
  components: { mySidebar },
  data() {
    return {
      isSidebar: false,
    };
  },
};
</script>

<style lang="less" scoped>
.my-menu {
  position: fixed;
  top: 30px;
  left: 20px;
  z-index: 100;
  user-select: none;
  font-size: 40px;
  color: #fff;
  &:hover {
    cursor: pointer;
  }
}
nav {
  background: linear-gradient(
    to bottom right,
    #05352d 0%,
    #133823 100%
  ) !important;
  position: fixed;
  top: 0;
  left: 0;
  z-index: 10;
}
.sidebar {
  // position: fixed;
  z-index: 11;
  top: 30px;
  left: 10px;
}
ul {
  display: flex;
  justify-content: center;
}
</style>

<style lang="less">
.nav-timeline {
  padding-right: 19px;
}
</style>
