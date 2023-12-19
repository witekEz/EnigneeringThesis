import React, { useEffect, useState } from "react"
import Navbar from './Navbar';
import Image from "../photosTest/test.png";

export default function ComparerHome() {

    const BASE_URL='https://localhost:7092/api'

    const [cars, setCars]=useState([])

    useEffect(()=>{
        const fetchCars=async()=>{
            const response= await fetch('https://localhost:7092/api/Generations')
            const cars=await response.json()
            setCars(cars)
        };
        fetchCars();
        //fetch(`generations`)
        //.then((results)=>{
        //    return results.json();
        //})
        //.then(data=>{
        //    setCars(data)
        //})
    },[])
    return (
        <>
            <Navbar />
            <ul>
                {cars.map((car)=>{
                    return <li key={car.Name}>{car.Model}</li>
                })}
            </ul>
            {
                //(cars.length > 0)?cars.map((car)=><h3>{car.Name}</h3>):<div>Loading...</div>
            }
            <ul>
                <div class="card" style={{ width: 18 + 'rem' }}>
                    <img src={Image} class="card-img-top" alt="Zdjecie testowe" />
                    <div class="card-body">
                        <h5 class="card-title">Card title</h5>
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                        <button href="#" class="btn btn-primary">Go somewhere</button>
                    </div>
                </div>
            </ul >

        </>
    )
}