<script lang="ts">
import Button from "@/components/Button.vue";
import TextField from "@/components/FormInput.vue";
import Layout from "@/components/Layout.vue";

import { mapStores } from "pinia";
import { useAccountStore } from "@/stores/account";

export default {
  computed: {
    ...mapStores(useAccountStore),
  },
  components: { Layout, Button, TextField },
  methods: {
    async onSubmit() {},
  },
};
</script>

<template>
  <Layout>
    <main class="container max-w-xl mx-auto">
      <Button label="Voltar" @click="() => $router.back()" />

      <h1 class="text-5xl font-semibold">Fazer Depósito</h1>

      <form @submit.prevent=""></form>
    </main>
  </Layout>
</template>
