import { createStore } from "vuex";

export default createStore({
  state: {
    contents: [
      {
        title: "Камчатка новости",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
      },
      {
        title: "Камчатка новости 1",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
      },
      {
        title: "Камчатка новости 2",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
      },
      {
        title: "Камчатка новости 3",
        text: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptas minima eum provident illum praesentium, unde ipsa sit assumenda,",
        img: require("../assets/testPicture.jpg"),
      },
    ],
  },
  mutations: {},
  actions: {},
  modules: {},
});
