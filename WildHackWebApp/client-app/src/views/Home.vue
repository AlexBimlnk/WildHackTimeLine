<template>
  <div class="home-page">
    <h1>Новостной портал по Камчатке</h1>
    <!-- <button @click="showTimeLine">Показать таймлайн</button>
    <button @click="hiddenTimeline">Скрыть таймлайн</button> -->
    <timeline-map v-if="timeline" />
    <div class="container-timeline">
      <small-card
        @click="openOriginalSite(content.link)"
        v-for="content in $store.state.dataForTimeline"
        :key="content"
        :cardContent="content"
      />
    </div>
  </div>
</template>

<script>
// import newsCard from "../components/newsCard.vue";
import smallCard from "../components/smallCard.vue"
import timelineMap from "../components/timelineMap.vue";

export default {
  components: {
    // newsCard,
    timelineMap,
    smallCard,
  },
  mounted() {
    if (this.$store.state.dataForTimeline.length === 0) {
      this.$store.dispatch("fetchTimelineData");
    }
  },
  data() {
    return {
      timeline: false,
    };
  },
  methods: {
    openCardNews(item) {
      this.$router.push(`/news/${item.title}`);
    },
    openOriginalSite(url) {
      window.location.href = `${url}`;
    },
    showTimeLine() {
      this.$store.dispatch("fetchTimelineData");
      this.timeline = true;
    },
    clearTimeline() {
      this.$store.commit("clearTimeline");
    },
    hiddenTimeline() {
      // this.clearTimeline()
      this.timeline = false;
    },
  },
};
</script>

<style lang="less" scoped>
h1 {
  font-size: 40px;
  text-align: center;
}
</style>
