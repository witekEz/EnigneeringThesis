import React, { Component } from 'react';
import Header from './components/Header';
import Navigation from './components/Navigation';
import { BrowserRouter as Router, Route, Routes, Navigate } from "react-router-dom";
import FetchGenerationsComponent from "./components/comparerHome/FetchGenerationsComponent";
import FetchAuctionsHome from './components/FetchAuctionsHome'
import FetchGenerationComponent from './components/comparerHome/FetchGenerationComponent';
import { Container, Row } from 'react-bootstrap';
import { ToastContainer } from 'react-toastify';
import { useDispatch, useSelector } from 'react-redux'
import { changeName, changeRole, changeState } from './components/comparerHome/Utilities/Redux/authentication';
import { jwtDecode } from "jwt-decode";
import setAuthenticationHeader from './components/comparerHome/Utilities/DefaultAuthHeaderComponent';



export default function App() {
    
    const {isLoggedIn}=useSelector(state=>state.authenticate);
    const dispatch=useDispatch();
    if(sessionStorage.getItem("token")&&isLoggedIn==false){
        const aboutUser=jwtDecode(sessionStorage.getItem("token"));
        setAuthenticationHeader(sessionStorage.getItem("token"))
        const role=aboutUser["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        const nickname=aboutUser.NickName;
        dispatch(changeState());
        dispatch(changeRole(role));
        dispatch(changeName(nickname));
    }

    return (
        <Router>
            <Container fluid id='mainContainer'>
                <Row>
                    <Header />
                </Row>
                <Navigation />
                <Routes>
                    <Route exact path="/comparerHome" element={<FetchGenerationsComponent />}></Route>
                    <Route exact path="/comparerDetails/:id" element={<FetchGenerationComponent />}></Route>
                    <Route path="/auctionsHome" element={<FetchAuctionsHome />}></Route>
                </Routes>
                <ToastContainer />
            </Container>
        </Router>

    )
}

//<Route exact path="/comparerDetails/:id" element={isLoggedIn?<FetchGenerationComponent />:<Navigate to={"/comparerHome"}/>}></Route>

