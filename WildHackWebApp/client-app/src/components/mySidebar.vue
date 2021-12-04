<template>
  <div class="my-sidebar">
    <h6>Настроить ленту</h6>

    <ul class="collapsible">
      <li>
        <div class="collapsible-header">
          <i class="material-icons">sync</i>
          Свежее
        </div>
      </li>
      <li>
        <div class="collapsible-header">
          <i class="material-icons">whatshot</i>
          Популярные
        </div>
      </li>
      <li>
        <div class="collapsible-header">
          <i class="material-icons">event</i>
          По дате
        </div>
        <div class="collapsible-body">
          <div class="inputs-block">
            <input
              v-model="stateDate"
              class="equal-size"
              type="text"
              placeholder="с"
            />
            <p class="equal-size date-p">:</p>
            <input
              v-model="endDate"
              class="equal-size"
              type="text"
              placeholder="по"
            />
          </div>
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
import M from "../../node_modules/materialize-css/dist/js/materialize";
export default {
  mounted() {
    M.AutoInit();
  },
  data() {
    return {
      startDate: "",
      endDate: "",
    };
  },
};
</script>

<style lang="less" scoped>
.date-p {
  padding: 0 20px;
}
h6 {
  text-align: center;
  font-weight: 700;
  font-size: 20px;
  padding: 40px 0;
}
.my-sidebar {
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
  background-color: #F0F0F0 !important;
}
.collapsible {
  box-shadow: none;
  &-header {
    background: #f0f0f0;
    box-shadow: none;
  }
}
.equal-size {
  flex-grow: 1;
}
.inputs-block {
  display: flex;
}
.my-sidebar {
  position: fixed;
  top: 112px;
  left: 0;
  background-color: rgba(0, 0, 0, 0);
  width: 300px;
  height: 100vh;
}
</style>
