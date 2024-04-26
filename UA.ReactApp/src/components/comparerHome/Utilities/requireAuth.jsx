import { Component } from "react";
import { useDispatch, useSelector } from 'react-redux'
import {useNavigate} from "react-router-dom"
import { render } from "react-dom";

export default function requireAuth(ComposedComponent){
    const {isLoggedIn}=useSelector(state=>state.authenticate);
    let navigate= useNavigate();
    if(!isLoggedIn){
        navigate('/comparer/home');
    }
    render(
        <ComposedComponent />
    )
    
}