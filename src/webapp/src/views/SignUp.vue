<script lang="ts">
import api from "@/services/api";
import router from "@/router";

import signUpImage from "../assets/images/undraw_signup.svg";
import TextField from "@/components/FormInput.vue";
import Button from "@/components/Button.vue";

import { useUserStore } from "@/stores/user";
import { mapStores } from "pinia";

export default {
  data() {
    return {
      image: signUpImage,
      form: {
        firstName: "Teste",
        lastName: "Sila",
        email: "matheusa56@gmail.com",
        cpf: "06504166510",
        password: "Matheusa56@",
      },
    };
  },
  computed: {
    ...mapStores(useUserStore),
  },
  methods: {
    async formSubmit() {
      try {
        const response = await this.userStore.signUp({
          ...this.form,
        });
        if (response.success) {
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
    class="container h-screen max-w-6xl mx-auto bg-background flex flex-col md:flex-revert md:flex-row md:flex-nowrap justify-center items-center md:space-x-24"
  >
    <section class="hidden md:block w-full max-w-md space-y-8 md:space-y-16">
      <h1 class="text-4xl md:text-5xl font-semibold text-center">
        Olá, seja bem vindo!
      </h1>
      <img :src="image" />
    </section>
    <section class="flex-1 space-y-8 bg-black p-8 rounded-lg">
      <form @submit.prevent="formSubmit" class="space-y-8">
        <fieldset class="space-y-3">
          <fieldset class="w-full flex flex-row space-x-4">
            <TextField class="w-full" label="Nome" v-model="form.firstName" />

            <TextField
              class="w-full"
              label="Sobrenome"
              v-model="form.lastName"
            />
          </fieldset>

          <TextField type="email" label="E-mail" v-model="form.email" />

          <TextField label="CPF" v-model="form.cpf" />

          <TextField type="password" label="Senha" v-model="form.password" />
        </fieldset>

        <Button type="submit" variant="primary" label="Cadastrar" />
      </form>

      <div class="flex justify-center">
        <router-link to="/">Já está cadastrado?</router-link>
      </div>
    </section>
  </main>
</template>
