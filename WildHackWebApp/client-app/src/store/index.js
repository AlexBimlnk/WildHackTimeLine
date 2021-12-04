import { createStore } from "vuex";

export default createStore({
  state: {
    // Для таймлайна
    dataForTimeline: [],

    // Для ленты
    contents: [
      {
        title: "Камчатка новости",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
        year: 2019,
      },
    ],

    // Для цветов
    maxRating: 0,
    minRating: 10,
  },
  mutations: {
    changeMax(state, el) {
      state.maxRating = el;
    },
    changeMin(state, el) {
      state.minRating = el;
    },
    setNormalizeColor(state) {
      const ratings = state.dataForTimeline.map((el) => el.rating);
      const max = Math.max(...ratings);
      const min = Math.min(...ratings);
      state.normalizeColors =
        ratings.map((rating) => (rating - min) * 100) / (max - min);
    },
    clearTimeline(state) {
      state.dataForTimeline = [];
    },
    forTest_west(state) {
      for (let i = 0; i < 3; i++) {
        state.dataForTimeline.push(state.contents[i]);
      }
    },
    forTest_east(state) {
      for (let i = 3; i < state.contents.length; i++) {
        state.dataForTimeline.push(state.contents[i]);
      }
    },
    setDataForTimeline(state, data) {
      state.dataForTimeline = data;
    },
    setDataForLineNews(state, data) {
      state.contents.push(data);
    },
    addTestElement(state) {
      state.dataForTimeline.unshift({
        title: "Test elem",
        link: "/wefwefwef",
        picture: "/qwfqf",
        date: "00 00 00",
      });
    },
    setRandomRating(state) {
      state.dataForTimeline.forEach((el) => {
        const randomElement = Math.floor(Math.random() * 500);
        el.rating = randomElement;
      });
    },
  },
  actions: {
    async fetchTimelineData(context) {
      const res = await fetch("/api/EcologyEvents");
      const data = await res.json();
      context.commit("setDataForTimeline", data);
      // Тестовое заполнение рейтинга для цвета кружков
      context.commit("setRandomRating");
      // Нормализуем цвета в отельном массиве
      context.commit("setNormalizeColor");
    },
    async fetchLineNews(context) {
      const res = await fetch("/api/EcologyEvents");
      const data = await res.json();
      data.forEach((el) => context.commit("setDataForLineNews", el));
    },
  },
  modules: {},
});
