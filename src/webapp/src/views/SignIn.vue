<script lang="ts">
import api from "@/services/api";
import router from "@/router";

import signInImage from "../assets/images/undraw_signin.svg";
import TextField from "@/components/FormInput.vue";
import Button from "@/components/Button.vue";

import { useUserStore } from "@/stores/user";
import { mapStores } from "pinia";
export default {
  data() {
    return {
      image: signInImage,
      form: {
        email: "",
        password: "",
      },
    };
  },
  computed: {
    ...mapStores(useUserStore),
  },
  methods: {
    async formSubmit() {
      try {
        const response = await this.userStore.signIn(
          this.form.email,
          this.form.password,
        );

        if (response.success) {
          console.log("oiiiiii");
          router.push("home");
        } else {
          alert(response.error);
        }
      } catch (error) {
        console.log(error);
      }
    },
  },
  components: { TextField, Button },
};
</script>

<template>
  <main
    class="container h-screen max-w-6xl mx-auto bg-background flex flex-col md:flex-row md:flex-nowrap justify-center items-center md:space-x-24"
  >
    <section class="w-full max-w-md">
      <img :src="image" />
    </section>
    <section class="flex-1 space-y-8 bg-black p-8 rounded-lg">
      <h1 class="text-4xl md:text-5xl font-semibold text-center">
        Bem vindo de volta!
      </h1>

      <form @submit.prevent="formSubmit" class="space-y-8">
        <fieldset class="space-y-3">
          <TextField type="email" label="E-mail" v-model="form.email" />

          <TextField type="password" label="Senha" v-model="form.password" />
        </fieldset>

        <Button type="submit" variant="primary" label="Entrar" />
      </form>

      <div class="flex justify-center">
        <router-link to="/signup">Já está cadastrado?</router-link>
      </div>
    </section>
  </main>
</template>
