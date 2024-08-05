import { defineStore } from "pinia";
import type { ActionResult } from ".";

import api from '@/services/api'

interface AccountInfo {
  id: string
  userId: string
  balance: number
}

export const useAccountStore = defineStore('account', {
  state: () => ({
    accountInfo: {} as AccountInfo
  }),
  actions: {
    async fetchAccountInfo(): Promise<ActionResult<AccountInfo>> {
      try {
        const response = await api.get("/Account/Me")

        this.accountInfo = response.data

        console.log("aaa", response.data)

        return { success: true, data: response.data }
      } catch (error: any) {
        if (error.response)
          return { success: false, error: error.response.data }

        return { success: false, error: error.message }
      }
    }, 
    async makeDeposit(toAccount: string, amount: number) {
      // try {
      //   const response = await api.post(`/Account/${toAccount}/Deposit`)

      // } catch (error) {
        
      // }
    }
  }

})
