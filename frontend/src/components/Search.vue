<template>
  <section class="search">
    <input class="search-box" type="search" placeholder="Søk" v-model="term" @input="search" />
    <select v-model="selected" @change="search">
      <option :value="null" selected="selected">Alle</option>
      <option v-for="type in dishTypes" :key="type.name">{{type.name}}</option>
    </select>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "Search",
  data() {
    return {
      term: null,
      dishTypes: ["Alle"],
      selected: null
    };
  },
  created() {
    let dishListURL = `https://localhost:5001/dishtypes`;
    axios.get(dishListURL).then(response => {
      this.dishTypes = response.data;
    });
  },
  methods: {
    search() {
      if (this.term != "" && this.selected) {
        this.$router.push({
          query: { dish: this.term, type: this.selected }
        });
      } else if (this.selected) {
        this.$router.push({
          query: { type: this.selected }
        });
      } else if (this.term) {
        this.$router.push({
          query: { dish: this.term }
        });
      } else {
        this.$router.push({
          query: { dish: this.term }
        });
      }
    }
  }
};
</script>

<style scoped>
.search {
  display: grid;
  grid-template-columns: 1fr auto;
  gap: 20px;
}

.search-box {
  padding: 10px;
}

@media only screen and (min-width: 800px) {
  .search-box {
    padding: 15px 10px;
  }
}
</style>