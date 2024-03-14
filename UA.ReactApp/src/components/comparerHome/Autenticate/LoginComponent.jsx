import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import { useState } from 'react';
export default function LoginComponent({ onLoginChange }) {
    const BASE_URL = 'https://localhost:7092/api';

    const [loginForm, setLoginForm] = useState({});
    const [errors, setErrors] = useState({});

    const [error, setError] = useState({});

    const setField = (field, value) => {
        setLoginForm({
            ...loginForm,
            [field]: value
        })
        if (!!errors[field])
            setErrors({
                ...errors,
                [field]: null
            })
    }
    const validate = () => {
        let error = {};
        if (!loginForm.email || !/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/.test(loginForm.email) || loginForm.email.length < 12) {
            error.email = 'Niepoprawny adres email';
        }
        if (!loginForm.password || loginForm.password.length < 8) {
            error.password = 'Hasło musi posiadać długość minimum 8 znaków';
        }

        return error;
    };
    const handleLogin = () => {
        const errors = validate();
        setErrors(errors);
        onLoginChange(loginForm);
    }
    return (
        <>
            <p id='authenticateLabel'>Logowanie</p>
            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextEmail">
                <Col sm="10">
                    <Form.Control placeholder='Email' isInvalid={!!errors.email} onChange={(e) => setField('email', e.target.value)} />
                    <Form.Control.Feedback type="invalid">
                        {errors.email}
                    </Form.Control.Feedback>
                </Col>
            </Form.Group>


            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextPassword">
                <Col sm="10">
                    <Form.Control type="password" isInvalid={!!errors.password} placeholder="Password" onChange={(e) => setField('password', e.target.value)} />
                    <Form.Control.Feedback type="invalid">
                        {errors.password}
                    </Form.Control.Feedback>
                </Col>
            </Form.Group>
            <Row>
                <Button variant='primary' className='loginRegisterLogoutButtons' onClick={handleLogin}>
                    Zaloguj
                </Button>
            </Row>
        </>
    )
}