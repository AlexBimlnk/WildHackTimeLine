<template>
  <div class="timeline">
    <div class="container">
      <div class="timeline">

        <timeline-event v-for="i in 10" :key="i" />
      </div>
    </div>
  </div>
</template>
<script>
import timelineEvent from "./timelineEvent.vue"
export default {
  components: {
    timelineEvent,
  }
}
</script>

<style lang="less" scoped>
.timeline {
  height: 100vh !important;
  overflow-y: scroll;
}
</style>


