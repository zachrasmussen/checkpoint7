<template>
  <div class="home flex-grow-1 d-flex justify-content-evenly p-4">
    <RecipeCard />
  </div>
  <div>
    <i
      class="
        mdi mdi-plus-circle
        fixed-bottom
        add-recipe
        justify-content-end
        d-flex
        px-2
      "
      data-bs-toggle="modal"
      data-bs-target="#exampleModal"
    ></i>

    <NewRecipeCard />
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
.add-recipe {
  font-size: 3em;
  color: #0096fa;
  cursor: pointer;
}
</style>
