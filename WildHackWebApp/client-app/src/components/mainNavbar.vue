<template>
  <div class="main-navbar">
    <sidebar class="sidebar" />
    <nav class="nav-extended">
      <div class="container">
        <div class="nav-wrapper">
          <a href="#" class="brand-logo center">Новости камчатки</a>
          <a href="#" data-target="mobile-demo" class="sidenav-trigger"
            ><i class="material-icons">menu</i></a
          >
        </div>
        <div class="nav-content">
          <ul class="tabs tabs-transparent">
            <li class="tab"><router-link to="/">Лента</router-link></li>
            <li class="tab">
              <router-link to="/timeline">Таймлайн</router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </div>
</template>

<script>
import sidebar from "./sidebar.vue";
export default {
  components: { sidebar },
};
</script>

<style lang="less" scoped>
nav {
  background: linear-gradient(to bottom right, #05352d 0%, #233b19 100%) !important;
}
.sidebar {
  position: absolute;
  top: 30px;
  left: 10px;
}
ul {
  display: flex;
  justify-content: center;
}
</style>
