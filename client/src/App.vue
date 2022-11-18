<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { v4 as uuid } from 'uuid'
import WeatherForecast from './components/WeatherForecast.vue'
import { getAllWeatherForecasts } from './api/weather-forecast'
import type { WeatherForecastDetails } from './types'

const weatherForecasts = ref<WeatherForecastDetails[]>()

onMounted(async () => {
  weatherForecasts.value = await getAllWeatherForecasts()
})
</script>

<template>
  <div class="text-center selection:bg-green-100">
    <h1 class="text-3xl font-light">Weather Forecast</h1>
    <br />
    <p>Forecast tells that:</p>
    <br />
    <section class="flex flex-col gap-3">
      <WeatherForecast
        v-if="weatherForecasts"
        v-for="weatherForecast in weatherForecasts"
        :key="uuid()"
        :details="weatherForecast"
      />
      <div v-else>An error occurred.</div>
    </section>
  </div>
</template>

<style></style>
