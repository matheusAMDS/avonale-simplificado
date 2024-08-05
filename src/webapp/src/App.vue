<script lang="ts">
import { onBeforeMount } from "vue";
import { useUserStore } from "@/stores/user";

import { mapStores } from "pinia";
import router from "./router";

export default {
  computed: {
    ...mapStores(useUserStore),
  },
  async beforeMount() {
    const savedAccessToken = localStorage.getItem("token");

    try {
      if (savedAccessToken) {
        const response = await this.userStore.getUserData();

        if (response.success) router.push("/home");
        else router.push({ name: "signin" });
      } else {
        router.push({ name: "signin" });
      }
    } catch {
      router.push({ name: "signin" });
    }
  },
};
</script>

<template>
  <div id="app" class="h-full min-h-screen">
    <router-view />
  </div>
</template>
