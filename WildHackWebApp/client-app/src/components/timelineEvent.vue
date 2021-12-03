<template>
  <div class="timeline-event">
    <div class="card timeline-content">
      <div class="card-content teal white-text">
        <p>
          {{ content.title }}
        </p>
      </div>
    </div>
    <div class="timeline-badge red lighten-3 white-text"></div>
    <div class="year">{{$store.state.dataForTimeline[0].date.fullDate}}</div>
  </div>
</template>

<script>
export default {
  props: {
    content: {
      type: Object,
    },
  },
};
</script>

<style lang="less" scoped>
@import url("../../node_modules/materialize-css/dist/css/materialize.min.css");
.year {
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
      width: 2px;
      height: calc(50% - 30px);
      position: absolute;
      background: #d2d2d2;
      left: calc(50% - 1px);
      top: 0;
    }
    &::after {
      display: block;
      content: "";
      width: 2px;
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
