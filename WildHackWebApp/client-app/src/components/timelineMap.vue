<template>
  <div class="block-on-click">
    <div class="row timeline_map">
      <div class="col m6 timeline-scroll">
        <div class="timeline">
          <div class="container">
            <div class="timeline">
              <timeline-event
                v-for="content in $store.state.dataForTimeline"
                :key="content"
                :content="content"
              />
            </div>
          </div>
        </div>
      </div>
      <div class="col m6 col-for-map">
        <div class="map">
          <div class="point point-west"></div>
          <div class="point point-east"></div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import timelineEvent from "./timelineEvent.vue";
export default {
  components: {
    timelineEvent,
  },
  methods: {
    fetchWest() {
      this.$store.commit('clearTimeline')
      this.$store.commit('forTest_west')
    },
    fetchEast() {
      this.$store.commit('clearTimeline')
      this.$store.commit('forTest_east')
    }
  },
};
</script>

<style lang="less" scoped>
.map {
  position: relative;
}
.point {
  width: 20px;
  height: 20px;
  border-radius: 10px;
  background-color: yellow;
  transition: 0.2s;
  &-west {
    position: absolute;
    top: 150px;
    right: 290px;
  }
  &-east {
    position: absolute;
    top: 350px;
    right: 460px;
  }
  &:hover {
    background-color: rgb(211, 211, 93);
    cursor: pointer;
  }
}
.timeline_map {
  height: 90vh;
}
.col-for-map {
  height: 100%;
}
.timeline-scroll {
  height: 100% !important;
  overflow-y: scroll;
}
.map {
  background: url("../assets/map1.png") no-repeat center center;
  // background-size: 80%;
  width: 100%;
  height: 100%;
}
</style>
