import Vue from "vue";
import VueRouter from "vue-router";
import HomeView from "../views/HomeView.vue";
import SignIn from "@/views/SignIn.vue";
import { useUserStore } from "@/stores/user";

const router = new VueRouter({
  mode: "history",
  base: import.meta.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "signin",
      component: SignIn,
    },
    {
      path: "/home",
      name: "home",
      component: HomeView,
      meta: {
        requiresAuth: true
      },
    }
  ],
});

router.beforeEach((to, from, next) => {
  const userStore = useUserStore()

  if (!to.meta?.requiresAuth) next()

  if (to.meta?.requiresAuth && !userStore.isLoggedIn)
    next({ name: 'signin' })
  else next()
})

export default router;
