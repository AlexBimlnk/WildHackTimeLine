import { createRouter, createWebHistory } from "vue-router";
import Home from "../views/Home.vue";

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
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
    path: '/timeline',
    component: () => import("../views/TimelineTab.vue")
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
