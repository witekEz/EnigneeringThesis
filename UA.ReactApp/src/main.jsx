import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import './Header.css'
import 'bootstrap/dist/css/bootstrap.css'
import '@smastrom/react-rating/style.css'
import { store } from './components/comparerHome/Utilities/Redux/store.jsx'
import { Provider } from 'react-redux'

ReactDOM.createRoot(document.getElementById('root')).render(
  <Provider store={store}>
    <App />
  </Provider>

) 
