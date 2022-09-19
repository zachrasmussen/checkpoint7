<template>
  <div
    class="modal fade"
    id="exampleModal"
    tabindex="-1"
    aria-labelledby="exampleModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header recipe-title-bg">
          <h5 class="modal-title text-white" id="exampleModalLabel">
            New Recipe
          </h5>
        </div>
        <div class="modal-body">
          <form action="">
            <label for="title" class="col-5 mx-2">Title</label>
            <label for="category" class="col-5 mx-2">Category</label>
            <input
              type="text"
              id="title"
              class="col-5 mx-2 mt-1"
              placeholder="Title"
            />
            <input
              type="select"
              class="col-5 mx-2 mt-1"
              placeholder="Category"
            />

            <label for="sub-title" class="col-9 mx-2 mt-3">Sub Title</label>
            <input
              type="text"
              id="title"
              class="col-10 mx-2 mt-1"
              placeholder="Details ..."
            />
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-outline" data-bs-dismiss="modal">
            Cancel
          </button>
          <button type="button" class="btn submit-color">Submit</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped lang="scss">
.recipe-title-bg {
  background-color: #0096fa;
  width: 100%;
}
.submit-color {
  background-color: #0096fa;
  color: white;
}
</style>
