<template>
  <div class="timeline-event">
    <a :href="content.link">
      <div class="card timeline-content">
        <div class="card-content teal white-text">
          <p>
            {{ content.title }}
          </p>
        </div>
      </div>
    </a>
    <!-- <div class="timeline-badge red lighten-3 white-text"></div> -->
    <div class="timeline-badge white-text around-white" :style="{backgroundColor: `rgb(0, ${normalizedColor}, 0)`}"></div>
    <div class="year">{{ content.date }}</div>
  </div>
</template>

<script>
export default {
  props: {
    content: {
      type: Object,
    },
    idx: {
      type: Number,
    },
  },
  mounted() {
    if (this.content.rating > this.$store.state.maxRating) {
      this.$store.commit("changeMax", this.content.rating);
    }
    if (this.content.rating < this.$store.state.minRating) {
      this.$store.commit("changeMin", this.content.rating);
    }
  },
  computed: {
    normalizedColor() {
      return ((this.content.rating - this.$store.state.minRating) * 255) / (this.$store.state.maxRating - this.$store.state.minRating);
    },
  },
};
</script>

<style lang="less" scoped>
@import url("../../node_modules/materialize-css/dist/css/materialize.min.css");
.around-white {
  // border: 1px solid white;
  box-shadow: 0 0 5px rgba(255, 255, 255, 0.8);
}
.card {
  background: rgba(0, 0, 0, 0) !important;
  box-shadow: none;
  &:hover {
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
  }
}
.card-content {
  background: rgba(0, 0, 0, 0) !important;
  text-align: right;
}
.year {
  color: #fff;
  display: block;
  position: absolute;
  width: 16px;
  height: 16px;
  top: calc(50% - 8px);
  right: calc(50% - 35px);
}
body {
  background-color: #eee;
}
.timeline {
  position: relative;
  .timeline-event {
    position: relative;
    padding-top: 5px;
    padding-bottom: 5px;
    .timeline-content {
      position: relative;
      width: calc(50% - 50px);
      display: block;
    }
    &::before {
      display: block;
      content: "";
      width: 1px;
      height: calc(50% - 30px);
      position: absolute;
      background: #d2d2d2;
      left: calc(50% - 1px);
      top: 0;
    }
    &::after {
      display: block;
      content: "";
      width: 1px;
      height: calc(50% - 30px);
      position: absolute;
      background: #d2d2d2;
      left: calc(50% - 1px);
      top: calc(50% + 30px);
    }
    &:first-child::before,
    &:last-child::after {
      display: none;
    }
    &:nth-child(even) .timeline-content {
      //   margin-left: calc(50% + 50px);
    }
    &:nth-child(odd) .timeline-content {
      //   margin-left: 0;
    }
  }
  .timeline-badge {
    display: block;
    position: absolute;
    width: 16px;
    height: 16px;
    background: #d2d2d2;
    top: calc(50% - 8px);
    right: calc(50% - 8px);
    border-radius: 50%;
    text-align: center;
    cursor: default;
    i {
      font-size: 25px;
      line-height: 40px;
    }
  }
}

@media (max-width: 600px) {
  .timeline {
    .timeline-event {
      .timeline-content {
        width: calc(100% - 70px);
      }
      &::before,
      &::after {
        left: 19px;
      }
      &:nth-child(even) .timeline-content,
      &:nth-child(odd) .timeline-content {
        margin-left: 70px;
      }
    }
    .timeline-badge {
      left: 12px;
    }
  }
}
.card {
  width: 450px !important;
  &::after {
    content: "";
    width: 120px;
    background-color: #fff;
    height: 1px;
    position: absolute;
    right: -130px;
    top: 50%;
  }
}
.card-title {
  // font-weight: 600!important;
  line-height: 1em;
  &.gradient {
    display: block;
    position: absolute;
    bottom: 0px;
    padding-bottom: 64px;
    display: block;
    width: 100%;
    background-color: rgba(0, 0, 0, 0);
    background: linear-gradient(
      to bottom,
      rgba(125, 185, 232, 0) 0%,
      rgba(0, 0, 0, 0.4) 50%,
      rgba(0, 0, 0, 0.8) 100%
    );
  }
}
</style>
