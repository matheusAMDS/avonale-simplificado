import Vue from "vue";
import { createPinia, PiniaVuePlugin } from "pinia";

import App from "./App.vue";
import router from "./router";

import "./assets/main.css";
import VueRouter from "vue-router";

Vue.use(PiniaVuePlugin);

const pinia = createPinia()

Vue.use(VueRouter);

new Vue({
  render: (h) => h(App),
  pinia,
  router,
}).$mount("#app");
