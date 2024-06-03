import { useEffect, useState } from 'react';
import { Form } from 'react-bootstrap';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import axios from 'axios';
import React from "react";

export default function CreateEngineModal({onEngineCreate}) {
    const BASE_URL = 'https://localhost:7092/api';

    const [show, setShow] = useState(false);
    const [form, setForm]= useState({});
    const [errors, setErrors]= useState({});

    const [trigger, setTrigger]= useState(true)

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const setField = (field, value) => {
        setForm({
            ...form,
            [field]: value
        })
        if (!!errors[field])
            setErrors({
                ...errors,
                [field]: null
            })
    }

    const handleCreateEngine=async ()=>{
        try{
            await axios.post(`${BASE_URL}/engine`, form)
            setShow(false);
            onEngineCreate(!trigger)
        }
        catch(err){
            setErrors(err.message);
            console.log(err.message);
            console.log(err);
        }
    }

    return (
        <>
            <Button id='addButton' onClick={handleShow}>Dodaj silnik</Button>
            <Modal
                show={show}
                onHide={handleClose}
                backdrop="static"
                keyboard={false}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Utwórz nowy silnik</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group>
                            <Form.Label>Wersja</Form.Label>
                            <Form.Control 
                                onChange={(e) => setField('version', e.target.value)} 
                                placeholder='Przykład: 2.5TDI...'
                            />
                            <Form.Control.Feedback type="invalid">
                                ERR
                            </Form.Control.Feedback>

                            <Form.Label>Pojemność</Form.Label>
                            <Form.Control 
                                onChange={(e) => setField('capacity', e.target.value)} 
                                placeholder='Np. 3.0...'
                                type='number'
                            />
                            <Form.Control.Feedback type="invalid">
                                ERR
                            </Form.Control.Feedback>

                            <Form.Label>Moc</Form.Label>
                            <Form.Control 
                                onChange={(e) => setField('horsePower', e.target.value)}  
                                placeholder='Np. 300...'
                                type='number'
                            />
                            <Form.Control.Feedback type="invalid">
                                ERR
                            </Form.Control.Feedback>

                            <Form.Label>Moment obrotowy</Form.Label>
                            <Form.Control 
                                onChange={(e) => setField('torque', e.target.value)} 
                                placeholder='Np. 450...'
                                type='number'
                            />
                            <Form.Control.Feedback type="invalid">
                                ERR
                            </Form.Control.Feedback>
                            <Form.Check
                                name='type'
                                type="radio"
                                label="Diesel"
                                value="Diesel"
                                onChange={e=>setField("type", e.target.value)}
                            />
                            <Form.Check
                                name='type'
                                type="radio"
                                value="LPG"
                                label="LPG"
                                onChange={e=>setField("type", e.target.value)}
                            />
                            <Form.Check
                                name='type'
                                type="radio"
                                value="Petrol"
                                label="Benzyna"
                                onChange={e=>setField("type", e.target.value)}
                            />
                            <Form.Check
                                name='type'
                                type="radio"
                                value="PetrolAndLPG"
                                label="Benzyna + LPG"
                                onChange={e=>setField("type", e.target.value)}
                            />
                            <Form.Check
                                name='type'
                                type="radio"
                                value="Electric"
                                label="Elektryk"
                                onChange={e=>setField("type", e.target.value)}
                            />
                            <Form.Check
                                name='type'
                                type="radio"
                                value="Hybrid"
                                label="Hybryda"
                                onChange={e=>setField("type", e.target.value)}
                            />
                            <Form.Label>Spalanie w mieście</Form.Label>
                            <Form.Control 
                                onChange={(e) => setField('fuelConsumptionCity', e.target.value)}  
                                placeholder='Np.7.0...'
                                type='number'
                            />
                            <Form.Control.Feedback type="invalid">
                                ERR
                            </Form.Control.Feedback>

                            <Form.Label>Spalanie poza miastem</Form.Label>
                            <Form.Control 
                                onChange={(e) => setField('fuelConsumptionSuburban', e.target.value)} 
                                placeholder='Np.7.0...'
                                type='number'    
                            />
                            <Form.Control.Feedback type="invalid">
                                ERR
                            </Form.Control.Feedback>
                        </Form.Group>
                    </Form>

                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Anuluj
                    </Button>
                    <Button variant="primary" onClick={handleCreateEngine}>Utwórz</Button>
                </Modal.Footer>
            </Modal>
        </>
    )
}