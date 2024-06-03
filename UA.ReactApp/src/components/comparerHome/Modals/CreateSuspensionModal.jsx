import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import axios from 'axios';
import React from "react";

export default function CreateSuspensionModal({onSuspensionCreate}) {
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

    const handleCreateSuspensions=async ()=>{
        try{
            await axios.post(`${BASE_URL}/suspension`, form)
            setShow(false);
            onSuspensionCreate(!trigger)
        }
        catch(err){
            setErrors(err.message);
            console.log(err.message);
            console.log(err);
        }
    }

    return (
        <> 
        <Button id='addButton' onClick={handleShow}>Dodaj nowe zawieszenie</Button>
        <Modal
            show={show}
            onHide={handleClose}
            backdrop="static"
            keyboard={false}
        >
            <Modal.Header closeButton>
                <Modal.Title>Dodaj nowe zawieszenie</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group>
                        <Form.Label>Rodzaj zawieszenia</Form.Label>
                        <Form.Control 
                            onChange={(e) => setField('type', e.target.value)} 
                            placeholder='Wielowahaczowe...'
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
                <Button variant="primary" onClick={handleCreateSuspensions}>Utwórz</Button>
            </Modal.Footer>
        </Modal>
        </>
    )
}