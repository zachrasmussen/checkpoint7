<template>
  <div class="rounded bg-img shadow">
    <div class="row">
      <nav class="navbar navbar-expand-lg bg-transparent px-5">
        <div class="d-flex justify-content-end">
          <form class="d-flex" role="search">
            <input
              class="form-control rounded-0"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />

            <button class="btn btn-light text-dark rounded-0" type="submit">
              <i class="mdi mdi-magnify"></i>
            </button>
          </form>
        </div>

        <div
          class="collapse navbar-collapse justify-content-end d-flex"
          id="navbarText"
        >
          <!-- LOGIN COMPONENT HERE -->
          <Login />
        </div>
      </nav>
    </div>
    <div class="row">
      <h3 class="text-center text-white title-font">All-Spice</h3>
      <h5 class="text-center sub-title-font">Cherish Your Family</h5>
      <h5 class="text-center sub-title-font">And Their Cooking!</h5>
    </div>

    <div class="row justify-content-center d-flex">
      <div
        class="
          col-4
          d-flex
          justify-content-evenly
          bg-white
          p-3
          mini-nav
          rounded
          shadow-lg
        "
      >
        <h5 class="text-center text-dark">Home</h5>
        <h5 class="text-center text-dark">My Recipes</h5>
        <h5 class="text-center text-dark">Favorites</h5>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    return {};
  },
};
</script>

<style scoped>
a:hover {
  text-decoration: none;
}
.nav-link {
  text-transform: uppercase;
}
.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
.bg-img {
  background-image: url("https://images.unsplash.com/photo-1466637574441-749b8f19452f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=880&q=80");
  height: 42vh;
  background-position: center;
  background-repeat: none;
  background-size: cover;
}
.title-font {
  font-family: "Dancing Script", cursive;
  font-size: 75px;
  text-shadow: 1px 1px 25px #414141;
  color: white;
}
.sub-title-font {
  font-family: "Poppins", sans-serif;
  text-shadow: 1px 1px 25px #414141;
  color: white;
}
.mini-nav {
  transform: translateY(30px);
}
</style>
