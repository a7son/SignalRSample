<template>
  <div class="space-y-2">
    <div
      class="
        p-6
        max-w-sm
        mx-auto
        bg-blue
        rounded-xl
        shadow-md
        flex-row
        items-center
        space-y-4        
      "
    >
      <div>
        <div class="text-xl font-medium text-black">Signal Chat App</div>
      </div>
      <div class="flex-row space-y-2">
        <div class="flex items-center justify-between">
          <div class="text-lg font-medium text-black">User</div>
          <!-- <span class="inline-block align-middle ...">User</span> -->
          <input
            type="text"
            class="
              mt-1
              block
              rounded-md
              border-gray-300
              shadow-sm
              focus:border-indigo-300
              focus:ring focus:ring-indigo-200 focus:ring-opacity-50
            "
            v-model="user"
            placeholder="user"
          />
        </div>
        <div class="flex items-center justify-between">
          <div class="text-lg font-medium text-black">Message</div>
          <input
            type="text"
            class="
              mt-1
              block
              rounded-md
              border-gray-300
              shadow-sm
              focus:border-indigo-300
              focus:ring focus:ring-indigo-200 focus:ring-opacity-50
            "
            v-model="message"
            placeholder="message"
          />
        </div>
        <div class="flex pt-8 justify-center space-x-4">
          <button
            class="
              bg-blue-500
              hover:bg-blue-700
              text-white
              font-bold
              py-2
              px-4
              rounded
            "
            type="button"
            v-on:click="SignalR()"
          >
            Submit Chat
          </button>
          <button
            class="
              bg-blue-500
              hover:bg-blue-700
              text-white
              font-bold
              py-2
              px-4
              rounded
            "
            type="button"
            v-on:click="Clear()"
          >
            Clear Chat
          </button>
        </div>
      </div>
    </div>
    <div
      class="
        p-6
        max-w-sm
        mx-auto
        bg-blue
        rounded-xl
        shadow-md
        flex-row
        items-center
        bg-blue-200
      "
    >
      <!-- <div class="flex ml-0" v-for="(k, index) in items" :key="index">
        <p>{{ k.name }} : {{ k.message }}</p>
      </div> -->
      <!-- <div class="flex-row ml-0 ">  
        <message name='Asep' pesan='Halo Apa Kabar'></message>
        <message name='Samsudin' pesan='Tes Kesabaran'></message>
      </div>  -->
      <chat-window/>
    </div>
  </div>
</template>

<script setup>
import ChatWindow from './ChatWindow/ChatWindow.vue';
// import Message from './ChatWindow/Message/Message.vue'
// export default {    
//   data() {
//     return {
//       items: [
//         { name2: "Asep", message2: "Foo" },
//         { name2: "Samsudin", message2: "Bar" },
//         { name2: "Samsudin", message2: "Halo Apa Kabar" },
//       ],
//     };
//   },
// };
</script>