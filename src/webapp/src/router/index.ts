import Vue from "vue";
import VueRouter from "vue-router";
import HomeView from "../views/HomeView.vue";
import SignIn from "@/views/SignIn.vue";
import { useUserStore } from "@/stores/user";
import SignUp from "@/views/SignUp.vue";
import MakeDeposit from "@/views/MakeDeposit.vue";

const router = new VueRouter({
  mode: "history",
  base: import.meta.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "signin",
      component: SignIn,
      meta: {
        title: "Bem-vindo à Avonale"
      }
    },
    {
      path: "/cadastrar",
      name: "signup",
      component: SignUp,
      meta: {
        title: "Cadastre-se"
      }
    },
    {
      path: "/home",
      name: "home",
      component: HomeView,
      meta: {
        requiresAuth: true,
        title: "Sua conta"
      },
    },
    {
      path: "/home/novodeposito",
      name: "makedeposit",
      component: MakeDeposit,
      meta: {
        requiresAuth: true,
        title: "Novo Depósito"
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
