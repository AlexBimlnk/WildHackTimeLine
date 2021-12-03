import { createStore } from "vuex";

export default createStore({
  state: {
    dataForTimeline: [],
    contents: [
      {
        title: "Камчатка новости",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
        year: 2019,
      },
      {
        title: "Камчатка новости 1",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
        year: 2019,
      },
      {
        title: "Камчатка новости 2",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
        year: 2019,
      },
      {
        title: "Камчатка новости 3",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
        year: 2019,
      },
      {
        title: "Камчатка новости 4",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
        year: 2019,
      },
      {
        title: "Камчатка новости 5",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
        year: 2019,
      },
      {
        title: "Камчатка новости 6",
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
  },
  actions: {},
  modules: {},
});
