import { useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import axios from 'axios';
import { toast } from "react-toastify";

export default function UpdateGenerationModal({generationId, modelId, onShowChange}) {
    const BASE_URL = 'https://localhost:7092/api';

    const [show, setShow] = useState(false);
    const [form, setForm] = useState({});
    const [errors, setErrors] = useState({});

    const [trigger, setTrigger] = useState(true)

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
    useEffect(()=>{
        if(onShowChange){
            setShow(true)
        }
    }, [onShowChange])
    const handleUpdateGeneration = async () => {
        try {
            await axios.put(`${BASE_URL}/model/${modelId}/generation/${generationId}`, form)
            setShow(false);
            window.location.reload(true);
        }
        catch (err) {
            setErrors(err.message);
            toast.error("Brak uprawnień!");
        }
    }

    return (
        <>
            <Modal
                show={show}
                onHide={handleClose}
                backdrop="static"
                keyboard={false}
            >
                <Modal.Header closeButton>
                    <Modal.Title>Zauktualizuj dane samochodu</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group>
                            <Form.Label>Nazwa</Form.Label>
                            <Form.Control
                                onChange={(e) => setField('name', e.target.value)}
                                placeholder='B6,E39...'
                            />
                            <Form.Control.Feedback type="invalid">
                                ERR
                            </Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Minimalna cena</Form.Label>
                            <Form.Control
                                onChange={(e) => setField('minPrice', e.target.value)}
                                type='number'
                            />
                            <Form.Control.Feedback type="invalid">
                                ERR
                            </Form.Control.Feedback>
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Maksymalna cena</Form.Label>
                            <Form.Control
                                onChange={(e) => setField('maxPrice', e.target.value)}
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
                    <Button variant="primary" onClick={handleUpdateGeneration}>Zaktualizuj</Button>
                </Modal.Footer>
            </Modal>
        </>
        )
}