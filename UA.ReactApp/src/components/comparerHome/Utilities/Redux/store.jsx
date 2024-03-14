import { configureStore } from "@reduxjs/toolkit";
import  authReducer  from "./authentication";


export const store= configureStore({
    reducer:{
        authenticate: authReducer,
    }
});