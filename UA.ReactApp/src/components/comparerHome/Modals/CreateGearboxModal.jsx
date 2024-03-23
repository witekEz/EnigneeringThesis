import { useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import axios from 'axios';

export default function CreateBodyColourModal({onGearboxCreate}) {
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

    const handleCreateGearbox=async ()=>{
        try{
            await axios.post(`${BASE_URL}/gearbox`, form)
            setShow(false);
            onGearboxCreate(!trigger)
        }
        catch(err){
            setErrors(err.message);
            console.log(err.message);
            console.log(err);
        }
    }

    return (
        <> <Button id='addButton' onClick={handleShow}>Dodaj skrzynię biegów</Button>
        <Modal
            show={show}
            onHide={handleClose}
            backdrop="static"
            keyboard={false}
        >
            <Modal.Header closeButton>
                <Modal.Title>Utwórz nową skrzynię biegów</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group>
                        <Form.Label>Nazwa skrzyni biegów</Form.Label>
                        <Form.Control 
                            onChange={(e) => setField('name', e.target.value)} 
                            placeholder='Przykład: ZF...'
                        />
                        <Form.Control.Feedback type="invalid">
                            ERR
                        </Form.Control.Feedback>

                        <Form.Label>Liczba biegów</Form.Label>
                        <Form.Control 
                            onChange={(e) => setField('numberOfGears', e.target.value)} 
                            placeholder='Np. 5...'
                            type='number'
                        />
                        <Form.Control.Feedback type="invalid">
                            ERR
                        </Form.Control.Feedback>

                        <Form.Check
                            name='type'
                            type="radio"
                            label="Manualna"
                            value="Manual"
                            onChange={e=>setField("typeOfGearbox", e.target.value)}
                        />
                        <Form.Check
                            name='type'
                            type="radio"
                            value="Automatic"
                            label="Automatyczna"
                            onChange={e=>setField("typeOfGearbox", e.target.value)}
                        />
                    </Form.Group>
                </Form>

            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Anuluj
                </Button>
                <Button variant="primary" onClick={handleCreateGearbox}>Utwórz</Button>
            </Modal.Footer>
        </Modal>
        </>
    )
}