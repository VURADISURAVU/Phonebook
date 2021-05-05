<template>
  <transition name="modal">
    <div class="modal-mask">
      <div class="modal-wrapper">
        <div class="modal-container">
          <div class="col">
              <div class="card-content white-text">
                <form class="col s12">
                  <div class="col">
                    <div class="input-field col s6">
                      <input
                          v-model="contact.name"
                          id="first_name"
                          type="text"
                      >
                      <label for="first_name">Имя</label>
                    </div>
                    <div class="input-field col s6">
                      <input
                          v-model="contact.secondName"
                          id="last_name" type="text">
                      <label for="last_name">Фамилия</label>
                    </div>
                  </div>
                  <div class="col">
                    <div class="input-field col s6">
                      <input
                          v-model="contact.phoneNumber"
                          id="phoneNumber" type="text"
                      >
                      <label for="phoneNumber">Номер телефона</label>
                    </div>
                    <div class="input-field col s6">
                      <input
                          v-model="contact.email"
                          id="email"
                          type="email"
                      >
                      <label for="email">Email</label>
                    </div>
                  </div>
                  <input
                      class="btn" style="margin-right: 5px" type="button" value="Редактировать"
                      @click="editContact"
                  />
                  <p></p>
                  <button class="btn red" @click="$emit('close')">
                    Закрыть
                  </button>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
  </transition>
</template>

<script>
export default {
  name: "Modal",
  data(){
    return{
      name: '',
      secondName: '',
      phoneNumber: '',
      email: '',
    }
  },
  props:{
    contact: {}
  },
  methods:{
    async editContact(){
      await fetch("api/entry/update", {
        method: "PUT",
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.contact)
      }).then(response => {
        response.json()
        console.log(response)
        if(response.ok){
          this.$emit('close')
          this.$emit('update')
        }
      })
    }
  }
}
</script>

<style scoped>
  .modal-mask {
    position: fixed;
    z-index: 9998;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    display: table;
    transition: opacity 0.3s ease;
  }
  
  .modal-wrapper {
    display: table-cell;
    vertical-align: middle;
  }
  
  .modal-container {
    width: 500px;
    margin: 0px auto;
    padding: 20px 30px;
    background-color: #607d8b;
    border-radius: 2px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
    transition: all 0.3s ease;
    font-family: Helvetica, Arial, sans-serif;
  }
  
  .modal-header h3 {
    margin-top: 0;
    color: #42b983;
  }
  
  .modal-body {
    margin: 20px 0;
  }
  
  .modal-default-button {
    display: block;
    margin-top: 1rem;
  }
  
  .modal-enter {
    opacity: 0;
  }
  
  .modal-leave-active {
    opacity: 0;
  }
  
  .modal-enter .modal-container,
  .modal-leave-active .modal-container {
    -webkit-transform: scale(1.1);
    transform: scale(1.1);
  }
</style>