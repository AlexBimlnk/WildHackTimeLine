<template>
  <div class="sidebar">
    <ul id="slide-out" class="sidenav">
      <li><h6>Сортировка ленты</h6></li>
    </ul>
    <a href="#" data-target="slide-out" class="sidenav-trigger"
      ><i class="material-icons">menu</i></a
    >
  </div>
</template>

<script>
import M from "../../node_modules/materialize-css/dist/js/materialize";
export default {
  mounted() {
    M.AutoInit();
  },
};
</script>

<style lang="less" scoped>
h6 {
  text-align: center;
  font-size: 20px;
  margin: 30px 0;
}
a {
  color: #fff;
}
.material-icons {
  font-size: 30px;
}
.sidenav {
  top: 112px;
  background-color: #f0f0f0;
  // box-shadow: none;
}
</style>

<style lang="less">
.sidenav-overlay {
  background-color: rgba(0, 0, 0, 0) !important;
}
</style>
