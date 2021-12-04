<template>
  <div class="card">
    <div class="withPadding">
      <div class="card-title">
        <h5>{{ cardContent.title }}</h5>
      </div>
      <div class="description">
        <p>
          {{ cardContent.text }}
        </p>
      </div>
    </div>
    <div class="img-block">
      <img :src="cardContent.pictureLink" alt="" />
    </div>
    <div @click.stop class="reaction withPadding">
      <p class="like">{{ like }}</p>
      <span @click="like++" class="material-icons"> expand_less </span>
      <span @click="useless++" class="material-icons"> expand_more </span>
      <p class="useless">{{ useless }}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    cardContent: {
      type: Object,
    },
  },
  data() {
    return {
      like: 10,
      useless: 3,
    };
  },
};
</script>

<style lang="less" scoped>
.material-icons {
  user-select: none;
  &:hover {
    cursor: pointer;
  }
}
.reaction {
  display: flex;
  width: 100%;
  justify-content: center;
  &:hover {
    cursor: initial;
  }
  & p {
    color: black;
    font-size: 20px;
    padding: 0;
    margin: 0;
    align-self: center;
  }
  & .like {
    color: #2ea83a;
  }
  & .useless {
    color: crimson
  }
}
.material-icons {
  font-size: 40px;
  align-self: center;
}
.withPadding {
  padding: 10px 20px;
}
.card {
  box-shadow: 0 0 20px rgba(37, 63, 26, 0.5);
  display: block;
  border-radius: 10px;
  margin: 50px auto 0;
  width: 640px;
  &:hover {
    box-shadow: 0 0 30px rgba(37, 63, 26, 0.8);
    cursor: pointer;
  }
  &-title {
    font-weight: 900;
    font-size: 30px;
  }
}
img {
  width: 100%;
}
</style>
