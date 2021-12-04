<template>
  <div class="gradient-bg">
    <div class="map-bg">
      <div class="scroll-timeline">
        <timeline-only />
      </div>
    </div>
  </div>
</template>

<script>
import timelineOnly from "./timelineOnly.vue";
export default {
  mounted() {
    this.$store.dispatch('fetchTimelineData')
  },
  components: {
    timelineOnly,
  },
};
</script>

<style lang="less" scoped>
.gradient-bg {
  background: linear-gradient(to bottom right, #05352d 0%, #233b19 100%);
}
.map-bg {
  background: url("../assets/map9.png") no-repeat center center;
  background-size: 80%;
  height: 90vh;
}
.scroll-timeline {
  height: 100%;
  overflow-y: scroll;
}
</style>
