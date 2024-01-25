import React from "react"
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Navbar from 'react-bootstrap/Navbar';

export default function NavigationBar() {
    return (
        <>
            <Navbar expand="lg" className="bg-body-tertiary">
                <Container fluid className="justify-content-center">
                        <Form className="d-flex">
                            <Form.Control
                                type="search"
                                placeholder="Wprowadź dane"
                                className="me-2"
                                aria-label="Search"
                            />
                            <Button variant="outline-success">Wyszukaj</Button>
                        </Form>
                </Container>
            </Navbar >
        </>
    )
}