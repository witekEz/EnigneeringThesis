import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import { useState } from 'react';
export default function RegisterComponent({ onRegisterChange }) {

    const [registerForm, setRegisterForm] = useState({})
    const [errors, setErrors] = useState({})
    const setField = (field, value) => {
        setRegisterForm({
            ...registerForm,
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

        if (!registerForm.nickname) {
            error.nickname = 'Nazwa użytkownika jest wymagana';
        }

        if (!registerForm.email || !/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/.test(registerForm.email)||registerForm.email.length<12) {
            error.email = 'Niepoprawny adres email';
        }
        if (!registerForm.password || registerForm.password.length < 8) {
            error.password = 'Hasło musi posiadać długość minimum 8 znaków';
        }
        if (!registerForm.confirmPassword || registerForm.confirmPassword !== registerForm.password ) {
            error.confirmPassword = 'Oba hasła muszą być takie same';
        }

        return error;
    };
    const handleRegister = () => {
        const errors = validate();
        setErrors(errors);
        onRegisterChange(registerForm);
    }
    return (
        <>
            <p id='authenticateLabel'>Rejestracja</p>
            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextEmail">
                <Col sm="10">
                    <Form.Control required placeholder='Email' isInvalid={!!errors.email} onChange={(e) => setField('email', e.target.value)} />
                    <Form.Control.Feedback type="invalid">
                        {errors.email}
                    </Form.Control.Feedback>
                </Col>
            </Form.Group>
            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextNickname">
                <Col sm="10">
                    <Form.Control required placeholder='Nazwa użytkownika' isInvalid={!!errors.nickname} onChange={(e) => setField('nickname', e.target.value)} />
                    <Form.Control.Feedback type="invalid">
                        {errors.nickname}
                    </Form.Control.Feedback>
                </Col>
            </Form.Group>
            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextName">
                <Col sm="10">
                    <Form.Control placeholder='Imię' onChange={(e) => setField('firstName', e.target.value)} />
                </Col>
            </Form.Group>
            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextLastName">
                <Col sm="10">
                    <Form.Control placeholder='Nazwisko' onChange={(e) => setField('lastName', e.target.value)} />
                </Col>
            </Form.Group>
            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextPassword">
                <Col sm="10">
                    <Form.Control required type="password" placeholder="Hasło" isInvalid={!!errors.password} onChange={(e) => setField('password', e.target.value)} />
                    <Form.Control.Feedback type="invalid">
                        {errors.password}
                    </Form.Control.Feedback>
                </Col>
            </Form.Group>
            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextConfirmPassword">
                <Col sm="10">
                    <Form.Control required type="password" placeholder="Potwierdź hasło" isInvalid={!!errors.confirmPassword} onChange={(e) => setField('confirmPassword', e.target.value)} />
                    <Form.Control.Feedback type="invalid">
                        {errors.confirmPassword}
                    </Form.Control.Feedback>
                </Col>
            </Form.Group>
            <Form.Group as={Row} className="mb-3 registerLoginInput" controlId="formPlaintextDateOfBirth">
                <Col sm="10">
                    <Form.Control type="date" onChange={(e) => setField('dateOfBirth', e.target.value)} />
                </Col>
            </Form.Group>
            <Row>
                <Button variant='primary' className='loginRegisterLogoutButtons' onClick={handleRegister}>
                    Zarejestruj
                </Button>
            </Row>
        </>
    )
}