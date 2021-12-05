import { createRouter, createWebHistory } from "vue-router";
// import Home from "../views/Home.vue";
import TimelineTab from "../views/TimelineTab.vue"

const routes = [
  {
    path: "/",
    name: "Timeline",
    // component: Home,
    component: TimelineTab,
  },
  // {
  //   path: "/about",
  //   name: "About",
  //   component: () =>
  //     import( "../views/About.vue"),
  // },
  {
    path: '/news/:id',
    component: () => import("../views/FullEvent.vue")
  },
  {
    path: '/news',
    component: () => import("../views/Home.vue")
  },
  {
    path: '/newPost',
    component: () => import("../views/NewPost.vue")
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
