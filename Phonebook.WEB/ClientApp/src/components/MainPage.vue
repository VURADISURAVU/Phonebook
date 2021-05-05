<template>
  <div class="loading-center" v-if="loading">
    <pulse-loader></pulse-loader>
  </div>
  <div v-else class="container" style="max-width: 900px">
    <h1>Телефонная книга</h1>
    <button 
        class="btn primary green" 
        style="margin-bottom: 20px;" 
        @click="$router.push('/create')"
    >
      Добавить контакт
    </button>
    
    <modal v-if="isEdit" :contact="tempContact" @update="getAllEntries" @close="isEdit = false"></modal>
    
    <table class="highlight">
      <thead>
      <tr>
        <th>Имя</th>
        <th>Фамилия</th>
        <th>Номер телефона</th>
        <th>Почта</th>
        <th>Пол</th>
        <th>День рождения</th>
        <th></th>
      </tr>
      </thead>

      <tbody v-for="contact in contacts" :key="contact.id">
      <tr>
        <td>{{contact.name}}</td>
        <td>{{contact.secondName}}</td>
        <td>{{contact.phoneNumber}}</td>
        <td>{{contact.email}}</td>
        <td>{{contact.gender}}</td>
        <td>{{contact.birthday.toLocaleDateString()}}</td>
        <td class="table-btn">
          <button class="btn" style="margin-right: 5px" @click="getUser(contact.id)">
            <img class="edit-img" src="../assets/pencil.png" alt="pencil" width="30" height="30">
          </button>
          <button @click="removeEntry(contact.id)" class="btn red">x</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import PulseLoader from 'vue-spinner/src/PulseLoader'
import Modal from "@/components/Modal";

export default {
  name: "MainPage",
  components:{
    'PulseLoader': PulseLoader,
    'Modal': Modal
  },
  data(){
    return {
      contacts: [],
      loading: true,
      isEdit: false,
      tempContact: {}
    }
  },
  methods:{
    async getAllEntries(){
      let response = await fetch('/api/entry/getall');
      if(response.ok){
        let data = await response.json();
        this.contacts = data
        this.contacts.forEach((item) => {
          item.birthday = new Date(item.birthday)
        })
        this.loading = false
      }
    },
    async removeEntry(id){
      await fetch(`/api/entry/${id}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json'
        }
      })
      await this.getAllEntries()
    },
    async getUser(id) {
      let response = await fetch(`/api/entry/${id}`);
      if (response.ok) {
        let data = await response.json();
        this.tempContact = data
        this.isEdit = true
      }
    }
  },
  mounted() {
    this.getAllEntries()
  }
}
</script>

<style scoped>
  .table-btn{
    flex-direction: column;
  }
  .edit-img{
    margin-top: 3px;
  }
  
  .loading-center{
    position: absolute;
    top: 50%;
    left: 50%;
    margin-right: -50%;
  }
  
  .information-container{
    padding: 10px;
    display: flex;
    flex-direction: row;
    justify-content: start;
    align-items: start;
    text-align: start;
    border: 1px solid grey;
    border-radius: 10px;
    margin-bottom: 10px;
  }
  
  .main-info{
    margin-right: 20px;
  }
  .buttons{
    margin-left: 20px;
    padding-top: 20px;
    display: flex;
    flex-direction: column;
  }
</style>