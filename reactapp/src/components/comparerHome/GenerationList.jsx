import Button from 'react-bootstrap/Button';
import Card from 'react-bootstrap/Card';

import Images from "./Images";
import { Row, Col, Container } from 'react-bootstrap';
const GenerationList = ({ generations, title }) => {

    return (
        <Container>
            <h2>{title}</h2>
            <Row >
                {generations.items.map(generation => (
                    <Col key={generation.id}>
                        <Card style={{ width: '16rem'}} key={generation.id}>
                            <Images  generation={generation} />
                            <Card.Body>
                                <Card.Title>Marka: {generation.model.brand.name}</Card.Title>
                                <Card.Text>
                                    Model: {generation.model.name} <br></br>
                                    Generacja: {generation.name} <br></br>
                                    Kategoria: {generation.category.name} <br></br>
                                    Minimalna cena: {generation.minPrice} <br></br>
                                    Ocena: {generation.rate} <br></br>
                                </Card.Text>
                                <Button variant="primary">Szczegóły</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                ))}
            </Row>
            


        </Container>
    )
}

export default GenerationList;