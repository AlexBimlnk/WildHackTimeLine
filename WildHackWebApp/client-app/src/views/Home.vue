<template>
  <div class="home-page">
    <h1>Clear template</h1>
    <div class="container">
      <news-card />
    </div>
  </div>
</template>

<script>
import newsCard from "../components/newsCard.vue";
export default {
  components: {
    newsCard,
  },
};
</script>

