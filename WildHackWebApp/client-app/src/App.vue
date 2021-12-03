<template>
  <router-view />
</template>

<script>
export default {
  async mounted() {
    const res = await fetch('/api/EcologyEvents')
    const data = await res.json()
    this.$store.commit('setDataForTimeline', data)
    console.log(data)
  }
}
</script>

<style lang="less">
.container-timeline {
  width: 650px;
  margin: 0 auto;
}
</style>