import api from "@/services/api";
import { defineStore } from "pinia";
import type { ActionResult } from "@/stores";

interface UserInfo {
  firstName: string
  lastName: string
  email: string
  cpf: string
  type: "Admin" | "Common"
}

interface SignUpInput {
  firstName: string
  lastName: string
  email: string
  password: string
  cpf: string
}

export const useUserStore = defineStore("user", {
  state: () => ({
    info: {} as UserInfo,
    token: localStorage.getItem('token')
  }),
  getters: {
    name: state => state.info.firstName + "" + state.info.lastName,
    isLoggedIn: state => !!state.token
  },
  actions: {
    async getUserData(): Promise<ActionResult<UserInfo>> {
      if (!this.token) return {
        success: false,
        error: "Usuário não está autenticado"
      };

      const response = await api.get("/User/MyInfo");
      if (response.status != 200) {
        console.log("getUserData", response.data)
        this.info = response.data
        return {
          success: false,
          error: `Não foi possível recuperar os dados do usuário`
        }
      } else {
        return { success: true, data: response.data };
      }
    },
    async signIn(email: string, password: string): Promise<ActionResult> {
      const response = await api.post("/Auth", {
        email: email,
        password: password,
      });

      if (response.status === 200 || response.status === 201) {
        const token = response.data as string

        localStorage.setItem("token", token);

        this.token = token

        const userDataResponse = await this.getUserData();
        if (userDataResponse.success && userDataResponse.data) {

          return { success: true }
        } else {
          return { success: false, error: "Erro ao buscar dados do usuário" }
        }
      } else {
        return { success: false, error: "Erro na tentativa de login" }
      }
    },
    async signUp(input: SignUpInput): Promise<ActionResult> {
      try {
        const response = await api.post("/User", input)

        return { success: true, data: response.data }
      } catch (error: any) {
        return { success: false, error: error.response.data }
      }
    },
    logout() {
      localStorage.removeItem("token")

      this.token = ""
      this.info = {} as UserInfo
    }
  },
})
