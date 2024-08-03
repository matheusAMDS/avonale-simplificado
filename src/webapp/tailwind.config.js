/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js,ts,vue}"],
  theme: {
    extend: {
      colors: {
        primary: '#FE64A3',
        secondary: '#64FEBA',
        background: '#121212',
        muted: '#1E1E1E',
        text: '#ffffff',
        subtext: '#b3b3b3'
      },
    },
  },
  plugins: [],
}

