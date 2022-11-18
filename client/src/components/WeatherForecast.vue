<script setup lang="ts">
import type { WeatherForecastDetails } from '@/types'

interface Props {
  details: WeatherForecastDetails
}

const props = defineProps<Props>()
</script>
<template>
  <article>
    <h2>For date: {{ new Date(props.details.date).toLocaleDateString() }}</h2>
    <p>Temperature in Celsius: {{ props.details.temperatureC.toFixed(0) }}</p>
    <p>
      Temperature in Fahrenheit: {{ props.details.temperatureF.toFixed(0) }}
    </p>
    <details>
      <summary>Summary:</summary>
      {{ props.details.summary }}
    </details>
  </article>
</template>
<style></style>
