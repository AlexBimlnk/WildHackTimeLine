<template>
  <div class="timeline">
    <div class="timeline-container">
      <div class="timeline">
        <transition-group
          enter-active-class="animated bounceInDown"
        >
          <timeline-event
            v-for="content in $store.state.dataForTimeline"
            :key="content"
            :content="content"
          />
        </transition-group>
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
      this.$store.commit("clearTimeline");
      this.$store.commit("forTest_west");
    },
    fetchEast() {
      this.$store.commit("clearTimeline");
      this.$store.commit("forTest_east");
    },
  },
};
</script>

<style lang="less" scoped>
.timeline {
  height: 100vh;
}
.timeline-container {
  width: 1200px;
  margin: 0 auto;
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
</style>
