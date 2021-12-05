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
      <div class="end-line">
        <button @click="showMore" class="show-more">Показать больше</button>
      </div>
    </div>
  </div>
</template>

<script>
// [] 1. При нажатии на кнопку показать больше и включенном режиме "По популярности", новые элементы не учитываются в рейтинге популярных
// [] 2. При сортировке по дате необходимо скрывать кнопку "Показать больше"

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
      this.$store.dispatch("fetchTimeLineSomePart", this.$store.state.dataForTimeline.length);
    }
  },
  data() {
    return {
      timeline: false,
    };
  },
  methods: {
    async showMore() {
      await this.$store.dispatch('fetchTimeLineSomePart', this.$store.state.dataForTimeline.length)
    },
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
.end-line {
  width: 100%;
  text-align: center;
}
.show-more {
  padding: 15px 20px;
  background-color: #05352d;
  margin: 20px auto;
  text-align: center;
  color: #fff;
  border-radius: 10px;
}
h1 {
  font-size: 40px;
  text-align: center;
}
</style>
