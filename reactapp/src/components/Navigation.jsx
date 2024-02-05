import React, { useState } from "react";
import AuctionsHome from './AuctionsHome'
import Nav from 'react-bootstrap/Nav';
import FetchGenerationsComponent from "./comparerHome/FetchGenerationsComponent";


export default function Navigation() {
    
    const [activeNavItem, setActiveNavItem] = useState('link-comparer');
    const changeComponent=(selectedKey)=> {
        setActiveNavItem(selectedKey)
    }
    const renderComponent = () => {
        switch (activeNavItem) {
          case 'link-comparer':
            return <FetchGenerationsComponent />;
          case 'link-auctions':
            return <AuctionsHome />;
          default:
            return <FetchGenerationsComponent />;
        }
    };
    return (
        <>
            <Nav variant="underline justify-content-center" defaultActiveKey="link-comparer" onSelect={changeComponent}>
                <Nav.Item>
                    <Nav.Link eventKey="link-comparer">Porównywarka</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                    <Nav.Link eventKey="link-auctions">Aukcje</Nav.Link>
                </Nav.Item>
            </Nav>
            {renderComponent()}
        </>
    )
}