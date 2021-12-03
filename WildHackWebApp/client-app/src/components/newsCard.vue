<template>
  <div class="card">
    <div class="withPadding">
      <div class="card-title">
        <h5>{{cardContent.title}}</h5>
      </div>
      <div class="description">
        <p>
          {{cardContent.text}}
        </p>
      </div>
    </div>
    <div class="img-block">
      <img :src="cardContent.img" alt="" />
    </div>
    <div class="reaction withPadding">
      <div class="like"></div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    cardContent: {
      type: Object,
    }
  }
}
</script>

<style lang="less" scoped>
.withPadding {
  padding: 10px 20px;
}
.card {
  display: block;
  border-radius: 10px;
  margin: 50px auto 0;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.5);
  width: 640px;
  &-title {
    font-weight: 900;
    font-size: 30px;
  }
}
img {
  width: 100%;
}
.like {
  width: 30px;
  height: 30px;
  background: url("../assets/icons/heart.png") no-repeat center center;
  background-size: 100%;
}
</style>
