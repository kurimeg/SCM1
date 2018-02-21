<template>
    <div>
<<<<<<< HEAD
        <component :is="tabName"></component>
    </div>
  </transition>
=======
      <component :is="tabName"></component>
    </div>  
>>>>>>> 5fde66c9acadf126d7c9035a5ce97bdbd62e87ab
</template>

<script>
import DeskStationSide from '@/components/Chart/DeskStationSide'
import DeskSeaSide from '@/components/Chart/DeskSeaSide'
import * as constants from '@/assets/constants'
import { mapState } from 'vuex'

export default {
  components: {
    DeskStationSide, DeskSeaSide
  },
  computed: {
    ...mapState('tab', {
      tabName (state) {
        switch (state.floorPlaceDv) {
          case 'F01':
            return constants.TAB_NAME_STATION_SIDE
          case 'F02':
            return constants.TAB_NAME_SEA_SIDE
        }
      }
    })
  }
}
</script>
