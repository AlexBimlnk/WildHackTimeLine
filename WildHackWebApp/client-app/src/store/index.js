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
  },
  mutations: {
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
      state.contents.push(data)
    },
    addTestElement(state) {
      state.dataForTimeline.unshift({title: 'Test elem', link: "/wefwefwef", picture: "/qwfqf", date: "00 00 00"})
    }
  },
  actions: {
    async fetchTimelineData(context) {
      const res = await fetch('/api/EcologyEvents')
      const data = await res.json()
      context.commit('setDataForTimeline', data)
    },
    async fetchLineNews(context) {
      const res = await fetch('/api/EcologyEvents')
      const data = await res.json()
      data.forEach(el => context.commit('setDataForLineNews', el))
    }
  },
  modules: {},
});
