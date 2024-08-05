<script lang="ts">
import Layout from "../components/Layout.vue";
import Button from "../components/Button.vue";

import { useAccountStore } from "@/stores/account";
import { useUserStore } from "@/stores/user";

import { mapStores } from "pinia";

export default {
  data() {
    return {};
  },
  computed: {
    ...mapStores(useUserStore, useAccountStore),
  },
  async mounted() {
    try {
      const response = await this.accountStore.fetchAccountInfo();

      console.log(response);

      if (!response.success) alert(response.error);
    } catch (error) {
      console.log("eitaaa", error);
    }
  },
  components: { Layout, Button },
};
</script>

<template>
  <Layout>
    <main>
      <section class="bg-black flex flex-start rounded p-8 flex flex-col">
        <div>
          <h2 class="text-3xl text-subtext">Seu saldo</h2>
          <p class="text-5xl font-semibold">
            {{
              accountStore.accountInfo.balance.toLocaleString("pt-br", {
                style: "currency",
                currency: "BRL",
              })
            }}
          </p>
        </div>
        <div class="flex flex-start mt-8 space-x-2">
          <Button
            class="hover:bg-primary inline-block w-auto"
            @click="() => $router.push({ name: 'makedeposit' })"
            label="Depositar"
            variant="basic"
          />
          <Button
            class="hover:bg-primary inline-block w-auto"
            @click="() => $router.push({ name: 'maketransfer' })"
            label="Transferir"
            variant="basic"
          />
        </div>
      </section>
      <section></section>
    </main>
  </Layout>
</template>
