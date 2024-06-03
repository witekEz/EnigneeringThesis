import { configureStore } from "@reduxjs/toolkit";
import  authReducer  from "./authentication";
import React from "react";

export const store= configureStore({
    reducer:{
        authenticate: authReducer,
    }
});