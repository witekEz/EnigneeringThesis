import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import ComparerDetails from "./ComparerDetails";
import { Spinner } from "react-bootstrap";
import axios from 'axios';
import React from "react";

export default function FetchGenerationComponent() {
    const BASE_URL = 'https://localhost:7092/api';

    const { id } = useParams();
    const [generation, setGeneration] = useState(null)
    const [error, setError] = useState(null)
    const [isPending, setIsPending] = useState(true)
    useEffect(() => {
        const fetchGeneration = async () => {
            try{
                const response = await axios.get(`${BASE_URL}/home/${id}`);
                setGeneration(response.data);
                setIsPending(false);
            }catch(error){
                setError(error.message);
            }
        };
        fetchGeneration();
    }, [])

    return (
        <>
            {error && <p>Error: {error}</p>}
            {isPending &&  <Spinner className="spinnerLoading" animation="grow" />}
            {generation && <ComparerDetails generation={generation}/>}
        </>
    )
}