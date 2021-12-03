<template>
  <div class="home-page">
    <h1>Новостной портал по Камчатке</h1>
    <button @click="showTimeLine">Показать таймлайн</button>
    <button @click="hiddenTimeline">Скрыть таймлайн</button>
    <timeline v-if="timeline" />
    <div class="container-timeline">
      <news-card
        @click="openCardNews(content)"
        v-for="content in $store.state.contents"
        :key="content"
        :cardContent="content"
      />
    </div>
  </div>
</template>

<script>
import newsCard from "../components/newsCard.vue";
import timeline from "../components/timeline.vue"
export default {
  components: {
    newsCard,
    timeline
  },
  data() {
    return {
      timeline: false,
    };
  },
  methods: {
    openCardNews(item) {
      this.$router.push(`/news/${item.title}`)
    },
    showTimeLine() {
      this.timeline = true
    },
    clearTimeline() {
      this.$store.commit('clearTimeline')
    },
    hiddenTimeline() {
      // this.clearTimeline()
      this.timeline = false
    }
  },
};
</script>
