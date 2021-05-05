<template>
  <div class="container" style="max-width: 512px">
    <h1>Создайте запись</h1>
    <div class="col">
      <div class="card blue-grey darken-1 center-align">
        <div class="card-content white-text">
          <small>* Обозначены обязательные поля</small>
          <form class="col s12">
            <div class="col">
              <div style="color: red" v-if="statusCode === 400">Данные введены некорректно</div>
              <div class="input-field col s6">
                <input
                    v-model="name"
                    id="first_name" 
                    type="text"
                    :class="{invalid: !$v.name.required}"
                >
                <small v-if="!$v.name.required" style="color: red">Имя не должно быть пустым</small>
                <label for="first_name">Имя*</label>
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
                    :class="{invalid: !$v.phoneNumber.required && !$v.phoneNumber.checkPhoneNumber}"
                >
                <small v-if="!$v.phoneNumber.checkPhoneNumber" style="color: red">Введите корректный номер телефона</small>
                <label for="phoneNumber">Номер телефона*</label>
              </div>
              <div class="input-field col s6">
                <input
                    v-model="email"
                    id="email" 
                    type="email"
                    :class="{invalid: !$v.email.required && !$v.email.email}"
                >
                <small v-if="!$v.email.required" style="color: red">Введите корректный адрес почты</small>
                <label for="email">Email*</label>
              </div>
              
            </div>
            <div class="personal-info">
              <div class="birthday-info">
                <input
                    v-model="birthday"
                    id="birthday" type="date">
                <label for="birthday">Дата рождения</label>
              </div>
              <div class="gender-info">
                <label>Выберите пол</label>
                <p>
                  <label>
                    <input
                        type="radio"
                        v-model="gender"
                        value="Мужской"
                    />
                    <span>Мужской</span>
                  </label>
                </p>
                <p>
                  <label>
                    <input
                        type="radio"
                        v-model="gender"
                        value="Женский"
                    />
                    <span>Женский</span>
                  </label>
                </p>
              </div>
            </div>
            <input v-if="$v.$invalid" type="btn" class="btn" disabled value="Создать запись">
            <input 
                v-else
                @click="sendNewEntry"
                class="btn" type="button" value="Создать запись" />
            <button class="btn red btn-return" @click="$router.push('/')">Вернуться</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {email, required, minLength} from 'vuelidate/lib/validators'

const checkPhoneNumber = phone => {
  let regex = /^((\+7|7|8)+([0-9]){10})$/
  return regex.test(phone)
}

export default {
  name: "CreateEntry",
  data(){
    return{
      name: '',
      secondName: '',
      phoneNumber: '',
      email: '',
      gender: '',
      birthday: '',
      statusCode: ''
    }
  },
  validations: {
    name: {required, minLength: minLength(2)},
    email: {email, required},
    phoneNumber: {required, checkPhoneNumber}
  },
  methods: {
    async sendNewEntry(){
      if(this.$v.$invalid){
        this.$v.$touch()
        return
      }
      let data = {
        name: this.name,
        secondName: this.secondName,
        phoneNumber: this.phoneNumber,
        email: this.email,
        gender: this.gender,
        birthday: this.birthday
      }
      await fetch("api/entry/create", {
        method: "POST",
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json'
        },
        body: JSON.stringify(data)
      }).then(response => {
        response.json()
        this.statusCode = response.status
        if(response.ok){
          this.$router.push('/')
        }
      })
    }
  }
}
</script>

<style scoped>
.btn-return{
  margin-left: 20px !important;
}

.personal-info{
  display: flex;
  flex-direction: row;
  justify-content: center;
  margin-bottom: 20px;
}

.gender-info{
  margin-left: 30px;
}

.birthday-info{
  max-width: 128px;
  margin-right: 30px;
}
</style>