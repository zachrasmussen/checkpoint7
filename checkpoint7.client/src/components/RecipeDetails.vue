<template>
  <!-- SECTION this is the modal that pops up when the recipe card is clicked. -->
  <div class="row">
    <div class="col-12">
      <div
        class="modal fade"
        id="recipeDetails"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true"
      >
        <div class="modal-dialog modal-dialog-centered modal-xl">
          <div class="modal-content">
            <div class="container-fluid">
              <div class="row">
                <div class="col-12 col-md-5 p-0 m-0">
                  <img
                    src="https://images.unsplash.com/photo-1568901346375-23c9450c58cd?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=999&q=80"
                    alt=""
                    class="img-fluid"
                  />
                </div>
                <div class="col-10 col-md-7">
                  <div class="pt-3 justify-content-start d-flex">
                    <p class="title-font pb-2 m-0 p-0">
                      <b>Bacon Hamburger</b>
                    </p>
                  </div>
                  <div class="justify-content-start d-flex">
                    <p class="desc-font">A classic for BBQ parties</p>
                  </div>
                  <div class="justify-content-evenly d-flex m-2 mt-2 mb-3 pb-2">
                    <div class="col-10 col-md-6 order-2 order-md-1 shadow mx-2">
                      <div class="steps text-white p-2 rounded-top">
                        <h4>Recipe Steps</h4>
                      </div>
                      <div class="text-start p-3 border rounded-bottom">
                        <div class="scrolling">
                          <p>
                            1. In a Dutch oven, cook bacon over medium heat
                            until crisp. Remove to paper towels with a slotted
                            spoon; drain, reserving 1 tablespoon drippings.
                            Saute onion in drippings until tender. Add garlic;
                            cook 1 minute longer.
                          </p>

                          <p>
                            2. Stir in the broth, pumpkin, salt, nutmeg and
                            pepper. Bring to a boil. Reduce heat; simmer,
                            uncovered, for 10 minutes. Cool slightly.
                          </p>
                          <p>
                            3. In a blender, process soup in batches until
                            smooth. Return all to pan. Stir in cream; heat
                            through. Add cheese; stir until melted. Sprinkle
                            each serving with parsley, bacon and, if desired,
                            additional cheese.
                          </p>
                        </div>
                        <form>
                          <label for="description"></label>
                          <input
                            type="text"
                            name="description"
                            id="description"
                            class="w-100"
                            placeholder="Enter new step"
                          />
                        </form>
                      </div>
                    </div>
                    <div class="col-10 col-md-6 order-1 order-md-2 shadow mx-2">
                      <div class="steps text-white p-2 rounded-top">
                        <h4>Ingredients</h4>
                      </div>
                      <div class="text-start p-3 border rounded-bottom">
                        <div class="scrolling">
                          <p>
                            4 bacon strips<br />
                            chopped 1 medium onion<br />
                            chopped 3 garlic cloves<br />
                            minced 6 cups chicken broth 1 can (29 ounces)<br />
                            solid-pack pumpkin <br />
                            1/2 teaspoon salt <br />
                            1/4 teaspoon ground nutmeg <br />
                            1/8 teaspoon pepper <br />
                            1 cup heavy whipping cream <br />
                            1 cup shredded Gouda cheese <br />
                            2 tablespoons minced fresh parsley <br />
                            Additional shredded Gouda cheese, optional
                          </p>
                        </div>
                        <form class="align-items-end d-flex">
                          <label for="description"></label>
                          <input
                            type="text"
                            name="description"
                            id="description"
                            class="w-100"
                            placeholder="Enter new step"
                          />
                        </form>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- SECTION this end's the section for the modal that pops up when the recipe card is clicked. -->
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
  height: 100%;
  object-fit: cover;
  object-position: center;
}
.recipe-item div {
  position: relative;
}
.title-font {
  font-size: 25px;
  color: black;
}
.desc-font {
  font-size: 20px;
  color: black;
}
.item-name {
  position: absolute;
  bottom: 0;
  background: rgba(218, 217, 217, 0.4);
  border: 0.5px solid #a3a3a3;
  backdrop-filter: blur(10px);
}
.steps {
  background-color: #0096fa;
}
.scrolling {
  height: 50vh;
  overflow-y: auto;
}
</style>
