<template>
  <div class="container" style="max-width: 512px">
    <h3>Редактирование</h3>
    <div class="col">
      <div class="card blue-grey darken-1 center-align">
        <div class="card-content white-text">
          <form class="col s12">
            <div class="col">
              <div class="input-field col s6">
                <input
                    v-model="name"
                    id="first_name"
                    type="text"
                >
                <label for="first_name">Имя</label>
              </div>
              <div class="input-field col s6">
                <input
                    v-model="secondName"
                    id="last_name" type="text">
                <label for="last_name">Фамилия</label>
              </div>
            </div>
            <div class="col">
              <div class="input-field col s6">
                <input
                    v-model="phoneNumber"
                    id="phoneNumber" type="text"
                >
                <label for="phoneNumber">Номер телефона</label>
              </div>
              <div class="input-field col s6">
                <input
                    v-model="email"
                    id="email"
                    type="email"
                >
                <label for="email">Email</label>
              </div>
            </div>
            <input 
                class="btn" style="margin-right: 5px" type="button" value="Редактировать"
                @click="getUser($route.params.id)"
            />
            <button class="btn red btn-return" @click="$router.push('/')">Отмена</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Edit",
  data(){
    return{
      name: '',
      secondName: '',
      phoneNumber: '',
      email: '',
      gender: '',
      statusCode: ''
    }
  },
  methods:{
    async getUser(id){
      let response = await fetch(`/api/entry/${id}`);
        if(response.ok) {
          let data = await response.json();
          console.log(data)
          this.name = data.name;
          this.secondName = data.secondName;
          this.phoneNumber = data.phoneNumber;
          this.email = data.email;
        }
    }
  },
  mounted() {
    this.getUser()
  }
}
</script>

<style scoped>

</style>