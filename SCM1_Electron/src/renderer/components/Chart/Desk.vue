<template>
  <transition name="fade">
    <div>
      <!-- <component :is="modalName"></component> -->
      <desk-sea-side></desk-sea-side>
    </div>
  </transition>
</template>

<script>
import DeskStationSide from '@/components/Chart/DeskStationSide'
import DeskSeaSide from '@/components/Chart/DeskSeaSide'

export default {
  components: {
    DeskStationSide, DeskSeaSide
  }
}
</script>
