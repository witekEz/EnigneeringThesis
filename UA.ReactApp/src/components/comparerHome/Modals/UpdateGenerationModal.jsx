import { useEffect, useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import axios from 'axios';
import { toast } from "react-toastify";

export default function UpdateGenerationModal({ generationId, modelId, onShowChange }) {
    const BASE_URL = 'https://localhost:7092/api';

    const [show, setShow] = useState(false);
    const [form, setForm] = useState({});
    const [errors, setErrors] = useState({});

    const [image, setImage] = useState(null)
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
    useEffect(() => {
        if (onShowChange) {
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
    const handleAddImage = () => {
        try {
            const fi = new FormData();
            fi.append('image', image)
            axios.post(`${BASE_URL}/image/${generationId}`, fi);
            toast.success("Dodano zdjęcie");
            handleClose();
        } catch (err) {
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
                    <Form className='imageFormUpdate'>
                        <Form.Group controlId="formFile" className="mb-3">
                            <p id="image">Dodaj zdjęcie</p>
                            <Form.Control type="file" onChange={(e) => setImage(e.target.files[0])} />
                            <div className="uploadImageButton"><Button onClick={handleAddImage}>Zapisz</Button></div>
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