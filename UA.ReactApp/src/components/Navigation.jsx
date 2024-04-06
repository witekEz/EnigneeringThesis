import React, { useState } from "react";

import Nav from 'react-bootstrap/Nav';


import { Link } from "react-router-dom";


export default function Navigation() {
    
    const [activeNavItem, setActiveNavItem] = useState('link-comparer');
    const changeComponent=(selectedKey)=> {

        setActiveNavItem(selectedKey)
    }
    
    return (
        <>
            <Nav variant="underline justify-content-center" defaultActiveKey="link-comparer" onSelect={changeComponent}>
                <Nav.Item>
                    <Nav.Link as={Link} to="/comparer/home" eventKey="link-comparer">Porównywarka</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link disabled as={Link} to="/auctions/home" eventKey="link-auctions">Aukcje</Nav.Link>
                </Nav.Item>
            </Nav>
        </>
    )
}