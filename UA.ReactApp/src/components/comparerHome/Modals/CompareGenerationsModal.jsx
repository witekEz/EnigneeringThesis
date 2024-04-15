import { useState, useEffect } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import axios from 'axios';
import "./modal.css"
import DisplayGenerationModal from './DisplayGenerationModal';


export default function CompareGenerationsModal({ onShowChange, generationsToCompare }) {
    const BASE_URL = 'https://localhost:7092/api';

    const [show, setShow] = useState(false);
    const [generations, setGenerations] = useState([]);
    const [errors, setErrors] = useState({});

    const handleClose = () => {
        setShow(false);
        setGenerations([])
    }

    useEffect(() => {
        if (onShowChange) {
            setShow(true);
        }
    }, [onShowChange])


    const handleFetchGenerations = async () => {
        if (generationsToCompare.length > 0) {
            for (let i = 0; i < generationsToCompare.length; i++) {
                try {
                    const response = await axios.get(`${BASE_URL}/home/${generationsToCompare[i]}`)
                    console.log(response.data);
                    setGenerations(pre => [...pre, response.data]);

                }
                catch (err) {
                    setErrors(err.message);
                    console.log(err.message);
                    console.log(err);
                }
            }
        }
    }

    return (
        <>
            <Modal
                show={show}
                onHide={handleClose}
                backdrop="static"
                keyboard={false}
                centered
                dialogClassName="modal-width"
            >
                <Modal.Header closeButton>
                    <Modal.Title>Porównywarka</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <p>Dodałeś ({generationsToCompare.length}) samochodów do porównania</p>
                    {generations && <DisplayGenerationModal generations={generations} />}
                </Modal.Body>
                <Modal.Footer>
                    <Button onClick={handleFetchGenerations}>Porównaj</Button>
                    <Button variant="secondary" onClick={handleClose}>Dodaj inne sammochody</Button>
                </Modal.Footer>
            </Modal>
        </>
    )
}