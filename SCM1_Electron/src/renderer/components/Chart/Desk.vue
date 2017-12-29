<template>
  <transition name="fade">
    <div>
      <component :is="modalName"></component>
      <desk-station-side></desk-station-side>
    </div>
  </transition>
</template>

<script>
import DeskStationSide from '@/components/Chart/DeskStationSide'

export default {
  components: {
    DeskStationSide
  }
}
</script>
