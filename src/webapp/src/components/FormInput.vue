<script lang="ts">
export default {
  props: {
    value: String,
    label: String,
    id: String,
    type: String,
  },
};
</script>

<template>
  <div class="flex flex-col">
    <label v-if="label" :for="id" class="font-semibold mb-1">
      {{ label }}
    </label>
    <input
      :class="'bg-muted rounded p-2'"
      :id="id"
      :type="type"
      v-bind:value="value"
      v-on:input="$emit('input', $event.target.value)"
    />
  </div>
</template>
