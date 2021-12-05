<template>
  <div class="timeline">
    <div class="timeline-container">
      <div class="timeline">
        <transition-group enter-active-class="animated bounceInDown">
          <timeline-event
            v-for="content in $store.state.dataForTimeline"
            :key="content"
            :content="content"
          />
        </transition-group>
        <div class="end-line">
          <button @click="showMore" class="show-more">Показать больше</button>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import timelineEvent from "./timelineEvent.vue";
export default {
  mounted() {
    console.log(this.$store.state.dataForTimeline);
  },
  components: {
    timelineEvent,
  },
  computed: {
    normalizeColors() {
      const dataRes = this.$store.state.dataForTimeline;
      const ratings = dataRes.map((el) => el.rating);
      console.log(...ratings);
      const max = Math.max(...ratings);
      const min = Math.min(...ratings);
      console.log(max, min);
      return ratings.map((rating) => (rating - min) * 100) / (max - min);
    },
  },
  methods: {
    async showMore() {
      await this.$store.dispatch('fetchTimeLineSomePart', this.$store.state.dataForTimeline.length)
    },
  }
};
</script>

<style lang="less" scoped>
.end-line {
  width: 100%;
  text-align: center;
}
.show-more {
  padding: 15px 20px;
  background-color: #03463a;
  margin: 20px auto;
  text-align: center;
  color: #fff;
  border-radius: 10px;
}
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
