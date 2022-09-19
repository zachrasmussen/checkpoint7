<template>
  <header class="p-4 bg-white">
    <Navbar />
  </header>
  <main class="bg-white">
    <router-view />
  </main>
  <footer></footer>
</template>

<script>
import { computed } from 'vue';
import { AppState } from './AppState';

export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
</style>
