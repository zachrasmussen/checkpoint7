<template>
  <section
    class="
      row
      p-4
      justify-content-md-start justify-content-center
      d-flex
      flex-row
    "
  >
    <!-- SECTION this is the template for the recipe cards -->
    <!-- NOTE to action the modal for the recipe details is in the image -->
    <div class="col-10 col-md-12 recipe-item mb-5">
      <img
        src="https://images.unsplash.com/photo-1568901346375-23c9450c58cd?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=999&q=80"
        alt=""
        class="img-fluid rounded shadow selectable"
        data-bs-toggle="modal"
        data-bs-target="#recipeDetails"
      />
      <div class="col-12 col-md-12 justify-content-center d-flex title-card">
        <p class="col-10 col-md-10 text-white text-start p-2 item-name">
          <b>Bacon Hamburger</b><br />
          A classic for BBQ parties
        </p>
      </div>

      <!-- NOTE this ends the section for the button to activate the modal -->
    </div>

    <!-- SECTION end of the template section -->
    <!-- <div class="col-10 col-md-4 recipe-item mb-5">
      <img
        src="https://images.unsplash.com/photo-1524334788144-6dc88da21500?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80"
        alt=""
        class="img-fluid rounded shadow"
      />
      <div class="col-12 col-md-12 justify-content-center d-flex title-card">
        <p class="col-10 col-md-10 text-white text-start p-2 item-name">
          <b>Fish'n Chips</b><br />
          Fish love it and so will you!
        </p>
      </div>
    </div>
    <div class="col-10 col-md-4 recipe-item mb-5">
      <img
        src="https://images.unsplash.com/photo-1551248429-40975aa4de74?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=990&q=80"
        alt=""
        class="img-fluid rounded shadow"
      />
      <div class="col-12 col-md-12 justify-content-center d-flex title-card">
        <p class="col-10 col-md-10 text-white text-start p-2 item-name">
          <b>Shrimp Salad</b><br />
          So good a rabbit would eat it!
        </p>
      </div>
    </div> -->
    <div class="col-12">
      <RecipeDetails />
    </div>
  </section>
</template>

<script>
export default {
  setup() {
    return {};
  },
};
</script>

<style scoped>
img {
  height: 20em;
  width: 100%;
  object-fit: cover;
  object-position: center;
}
.recipe-item div {
  position: relative;
}

.item-name {
  position: absolute;
  bottom: 0;
  background: rgba(218, 217, 217, 0.4);
  border: 0.5px solid #a3a3a3;
  backdrop-filter: blur(10px);
}
</style>
