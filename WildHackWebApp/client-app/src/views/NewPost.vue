<template>
  <div class="container white-container">
    <div class="padding-block">
      <input class="writer-block title" type="text" placeholder="Заголовок" />
      <textarea name="writer-block mainPartOfPost"></textarea>
    </div>
  </div>
</template>

<script>
export default {
  // mounted() {
  //   const textarea = document.querySelector('textarea');
  //   textarea.addEventListener('keydown', (e) => {
  //     if (e.key === "Enter") {
  //       this.textarea_hight += 1
  //       console.log(1)
  //     }
  //   })
  // },
  data() {
    return {
      textarea_hight: 1,
    }
  },
  methods: {
    newLine() {
      this.textarea_hight++;
      console.log(this.textarea_hight)
    }
  }
}
</script>

<style lang="less" scoped>
.writer-block {
  &:not(:first-child) {
    padding-top: 40px !important;
  }
}
textarea {
  height: 500px;
  border: none;
  font-weight: 500;
  font-size: 24px;
  &:focus {
    outline: none;
  }
}
.padding-block {
  padding: 40px 100px;
}
.title {
  display: block;
  font-size: 40px !important;
  font-weight: 900;
  &::placeholder {
    font-size: 30px;
  }
}
.white-container {
  height: 100vh;
  background-color: #fff;
}
</style>

<style lang="less">
input {
  border-bottom: none !important;
  box-shadow: none !important;
}
</style>
