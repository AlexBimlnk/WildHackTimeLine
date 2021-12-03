<template>
  <div class="full-event">
    <h1>{{ content.title }}</h1>
    <p>{{ content.text }}</p>
    <img :src="content.img" alt="">
  </div>
</template>

<script>
export default {
  mounted() {
    this.searchItemOnTitle(this.$route.params.id);
  },
  data() {
    return {
      content: {},
    };
  },
  methods: {
    searchItemOnTitle(title) {
      this.content = this.$store.state.contents.find(
        (el) => el.title === title
      );
    },
  },
};
</script>

<style lang="less" scoped>
img {
    width: 100%;
}
</style>
