import MainPage from "@/components/MainPage";
import VueRouter from "vue-router";
import CreateEntry from "@/components/CreateEntry";
import Edit from "@/components/Edit";

export default new VueRouter({
  mode: 'history',
  routes: [
    {
      path: '/',
      component: MainPage
    },
    {
      path: '/create',
      component: CreateEntry
    },
    {
      path: '/edit/:id',
      component: Edit
    }
  ]
})


