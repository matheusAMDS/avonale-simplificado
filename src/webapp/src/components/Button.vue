<script lang="ts">
import type { PropType } from "vue";

type ButtonVariant = "primary" | "secondary" | "basic";

export default {
  props: {
    type: String,
    label: {
      type: String,
    },
    variant: {
      type: String as PropType<ButtonVariant>,
    },
  },
  computed: {
    bgColor: function () {
      return {
        "bg-primary": this.variant == "primary",
        "bg-secondary": this.variant == "secondary",
        "bg-muted": this.variant == "basic",
      };
    },
  },
};
</script>

<template>
  <button :type="type" :class="['w-full p-2 rounded', bgColor]">
    <span class="font-medium">{{ label }}</span>
  </button>
</template>
