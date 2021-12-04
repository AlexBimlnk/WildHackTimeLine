<template>
  <div class="container white-container">
    <div class="padding-block">
      <input v-model="title" class="writer-block title" type="text" placeholder="Заголовок" />
      <textarea v-model="text" name="writer-block mainPartOfPost"></textarea>
      <button class="btn-send waves-effect waves-light" @click="sendUserPost">Отправить</button>
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
      title: "",
      text: "",
      textarea_hight: 1,
    }
  },
  methods: {
    newLine() {
      this.textarea_hight++;
      console.log(this.textarea_hight)
    },
    async sendUserPost() {
      let res = await fetch("url", {
        method: "POST",
        body: JSON.stringify({title: this.title, text: this.text})
      })
      let result = res.json()
      console.log(result)
    }
  }
}
</script>

<style lang="less" scoped>
.btn-send {
  margin: 50px 0 0 0;
  color: #fff;
  border: none;
  box-shadow: 1px 1px 1px rgba(0, 0, 0, 0.5);
  background-color: #05352d;
  padding: 15px 20px !important;
}
.writer-block {
  &:not(:first-child) {
    padding-top: 40px !important;
  }
}
textarea {
  resize: none;
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
