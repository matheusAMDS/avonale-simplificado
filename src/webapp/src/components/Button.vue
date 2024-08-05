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
    btnVariant: function () {
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
  <button
    :type="type"
    :class="['p-2 rounded w-auto', btnVariant]"
    @click="$emit('click')"
  >
    <span class="font-medium">{{ label }}</span>
  </button>
</template>
