<template>
  <div class="card">
    <div class="withPadding">
      <div class="date">
        <span>{{ cardContent.date }}</span>
      </div>
      <div class="row">
        <div class="col" :class="{m7: cardContent.pictureLink !== null, m12: cardContent.pictureLink === null}">
          <div class="card-title">
            <h5>{{ cardContent.title }}</h5>
          </div>
        </div>
        <div class="col m5">
          <div class="img-block">
            <img :src="cardContent.pictureLink" alt="" />
          </div>
        </div>
      </div>

      <div @click.stop class="reaction withPadding">
        <span @click="like" class="material-icons"> expand_less </span>
        <p
          :class="{
            like: cardContent.rating > 0,
            useless: cardContent.rating < 0,
            common: cardContent.rating === 0,
          }"
        >
          {{ cardContent.rating }}
        </p>
        <span @click="dislike" class="material-icons"> expand_more </span>
      </div>
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
      like_bool: true,
      startState: 0,
      dislike_bool: true,
      rating: 0,
    };
  },
  methods: {
    async like() {
      if (this.like_bool) {
        this.$store.commit("like", this.cardContent); // like во vuex
        await fetch(`/api/EcologyEvents/${this.cardContent.id}`, {
          method: "PUT",
          body: JSON.stringify(this.cardContent),
        });
        this.like_bool = false;
        this.dislike_bool = true;
        if (this.startState === this.rating) {
          this.resetResults();
        }
      }
    },
    async dislike() {
      if (this.dislike_bool) {
        this.$store.commit("dislike", this.cardContent); // dislike во vuex
        await fetch(`/api/EcologyEvents/${this.cardContent.id}`, {
          method: "PUT",
          body: JSON.stringify(this.cardContent),
        });
        this.dislike_bool = false;
        this.like_bool = true;
        if (this.startState === this.rating) {
          this.resetResults();
        }
      }
    },
    resetResults() {
      this.like_bool = true;
      this.dislike_bool = true;
    },
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
    color: crimson;
  }
  & .common {
    color: black;
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
  border-radius: 10px;
}
</style>
