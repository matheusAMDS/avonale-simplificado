<script lang="ts">
import Button from "@/components/Button.vue";
import { useUserStore } from "@/stores/user";
import { mapStores } from "pinia";

export default {
  computed: {
    ...mapStores(useUserStore),
  },
  methods: {
    onLogout: function () {
      this.userStore.logout();

      this.$router.push({ name: "signin" });
    },
  },
  components: { Button },
};
</script>

<template>
  <div class="bg-background">
    <header
      class="container max-w-7xl mx-auto p-4 shadow-md flex items-center justify-between"
    >
      <h1>
        <strong class="hidden md:inline-block">AvonaleSimplificado</strong> |
        {{ $route.meta?.title }}
      </h1>

      <nav>
        <Button variant="basic" class="px-4" label="Sair" @click="onLogout" />
      </nav>
    </header>
    <div class="container max-w-7xl mx-auto">
      <slot />
    </div>

    <footer class="container max-w-7xl mx-auto">
      <p class="text-subtext font-semibold">Seila</p>
    </footer>
  </div>
</template>
