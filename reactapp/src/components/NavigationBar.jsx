import React, { useState } from "react"
import Button from 'react-bootstrap/Button';
import Container from 'react-bootstrap/Container';
import Form from 'react-bootstrap/Form';
import Navbar from 'react-bootstrap/Navbar';

export default function NavigationBar({onChangeSearch}) {

    const [searchPhase, setSearchPhase]=useState('');
    
    const handleSubmit=()=>{
        onChangeSearch(searchPhase);
    }

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
                                value={searchPhase}
                                onChange={(e)=>setSearchPhase(e.target.value)}
                            />
                            <Button variant="outline-success" onClick={handleSubmit}>Wyszukaj</Button>
                        </Form>
                </Container>
            </Navbar >
        </>
    )
}