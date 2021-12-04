<template>
  <div class="sidebar">
    <ul id="slide-out" class="sidenav">
      <li><h6>Сортировка ленты</h6></li>
      <ul class="collapsible">
        <li>
          <div class="collapsible-header">
            <i class="material-icons">local_fire_department</i>
            Популярные
          </div>
        </li>
        <li>
          <div class="collapsible-header">
            <i class="material-icons">refresh</i>
            Свежее
          </div>
        </li>
        <li>
          <div class="collapsible-header">
            <i class="material-icons">alarm</i>
            По дате
          </div>
          <div class="collapsible-body">
            <div class="date-block">
              <input type="text" class="date-input date-item" placeholder="с" />
              <p class="date-item">-</p>
              <input type="text" class="date-input date-item" placeholder="по" />
            </div>
          </div>
        </li>
      </ul>
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
.collapsible-body {
  padding: 0 50px !important;
}
.date-block {
  display: flex;
  justify-content: center;
  align-items: center;
}
.date-item {
  flex-grow: 1;
  &:not(:last-child) {
    margin-right: 10px;
  }
}
p {
  text-align: center;
  background-color: rgba(0, 0, 0, 0) !important;
}
.date-input {
  width: 20px !important;
}
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
  // position: fixed;
}
.sidenav {
  top: 112px;
  background-color: #f0f0f0;
  // box-shadow: none;
}
</style>

<style lang="less">
.sidenav-overlay {
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5) !important;
  top: 0;
  left: 300px !important;
  overflow-y: scroll;
}
.sidebar {
  position: fixed;
}
</style>
