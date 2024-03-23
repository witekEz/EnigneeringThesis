import { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import axios from 'axios';

export default function CreateGearboxModal({onBodyColourCreate}) {
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

    const handleCreateBodyColour=async ()=>{
        try{
            await axios.post(`${BASE_URL}/bodycolour`, form)
            setShow(false);
            onBodyColourCreate(!trigger)
        }
        catch(err){
            setErrors(err.message);
            console.log(err.message);
            console.log(err);
        }
    }

    return (
        <> 
        <Button id='addButton' onClick={handleShow}>Dodaj nowy lakier</Button>
        <Modal
            show={show}
            onHide={handleClose}
            backdrop="static"
            keyboard={false}
        >
            <Modal.Header closeButton>
                <Modal.Title>Dodaj nowy lakier</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Form.Group>
                        <Form.Label>Nazwa lakieru</Form.Label>
                        <Form.Control 
                            onChange={(e) => setField('colour', e.target.value)} 
                            placeholder='ALPAKA BEIGE MET...'
                        />
                        <Form.Control.Feedback type="invalid">
                            ERR
                        </Form.Control.Feedback>

                        <Form.Label>Kod lakieru</Form.Label>
                        <Form.Control 
                            onChange={(e) => setField('colourCode', e.target.value)} 
                            placeholder='LY1W...'
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
                <Button variant="primary" onClick={handleCreateBodyColour}>Utwórz</Button>
            </Modal.Footer>
        </Modal>
        </>
    )
}