import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
    base: '/dist/',
    server: {
        hmr: {
            protocol: 'ws'
        }
    },
    plugins: [vue()]
})
