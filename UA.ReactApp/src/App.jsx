import React, { Component } from 'react';
import Header from './components/Header';
import Navigation from './components/Navigation';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import FetchGenerationsComponent from "./components/comparerHome/FetchGenerationsComponent";
import FetchAuctionsHome from './components/FetchAuctionsHome'
import FetchGenerationComponent from './components/comparerHome/FetchGenerationComponent';
import { Container } from 'react-bootstrap';
export default function App() {
    return (
        <Router>
            <Container fluid id='mainContainer'>
                <Header />
                <Navigation />
                <Routes>
                    <Route exact path="/comparerHome" element={<FetchGenerationsComponent />}></Route>
                    <Route exact path="/comparerDetails/:id" element={<FetchGenerationComponent />}></Route>
                    <Route path="/auctionsHome" element={<FetchAuctionsHome />}></Route>
                </Routes>
            </Container>

        </Router>

    )
}

