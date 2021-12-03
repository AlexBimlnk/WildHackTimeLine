<template>
  <div class="home-page">
    <h1>Clear template</h1>
    <div class="container-timeline">
      <news-card
        @click="openCardNews(content)"
        v-for="content in $store.state.contents"
        :key="content"
        :cardContent="content"
      />
    </div>
    <timeline />
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
  // data() {
  //   return {};
  // },
  methods: {
    openCardNews(item) {
      this.$router.push(`/news/${item.title}`)
    },
  },
};
</script>
