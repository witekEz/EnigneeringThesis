import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import ComparerDetails from "./ComparerDetails";
import { Spinner } from "react-bootstrap";

export default function FetchGenerationComponent() {
    const BASE_URL = 'https://localhost:7092/api';

    const { id } = useParams();
    const [generation, setGeneration] = useState(null)
    const [error, setError] = useState(null)
    const [isPending, setIsPending] = useState(true)
    useEffect(() => {
        const fetchGeneration = async () => {
            try {
                const response = await fetch(`${BASE_URL}/home/${id}`);
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const result = await response.json();
                setGeneration(result);
                setIsPending(false);
            } catch (error) {
                setError(error.message);
            }
        };
        fetchGeneration();
    }, [])
    return (
        <>
            {error && <p>Error: {error}</p>}
            {isPending &&  <Spinner className="spinnerLoading" animation="grow" />}
            {generation && <ComparerDetails generation={generation} />}

            <div>

                {generation && (
                    <div>
                        <h1>Data from API:</h1>
                        <pre>{JSON.stringify(generation, null, 2)}</pre>
                    </div>
                )}
            </div>
        </>
    )
}