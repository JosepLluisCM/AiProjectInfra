import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    host: true, // Bind to 0.0.0.0 to make it accessible outside the container
    port: 5173,
    watch: {
      usePolling: true,
    },
  },
});
