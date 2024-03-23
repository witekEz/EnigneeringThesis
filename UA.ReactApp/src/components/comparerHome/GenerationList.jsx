import { Row, Col, Card, Button } from 'react-bootstrap';
import ImageComponent from './ImageComponent';
import { Link } from 'react-router-dom';
import { Rating, ThinStar } from "@smastrom/react-rating";
import { useState } from 'react';

const GenerationList = ({ generations }) => {

    return (
        <>
            <Row>
                {generations.items.map(generation => (
                    <Col key={generation.id} id="col-cards" xs={12} md={6} lg={6} xl={4} xxl={3}>
                        <Card style={{ width: '16rem' }} key={generation.id}>
                            <ImageComponent generation={generation}/>
                            <Card.Body>
                                <Card.Title>Marka: {generation.model.brand.name}</Card.Title>
                                <Card.Text>
                                    Model: {generation.model.name} <br></br>
                                    Generacja: {generation.name} <br></br>
                                    Kategoria: {generation.category.name} <br></br>
                                    Minimalna cena: {generation.minPrice} <br></br>
                                    Ocena: {generation.rate != null ? generation.rate.value : "TBA"}
                                </Card.Text>
                                <div className='rating-card'>
                                    {generation.rate != null ? <Rating
                                        style={{ maxWidth: 180 }}
                                        value={generation.rate.value}
                                        readOnly
                                    /> : <Rating
                                        style={{ maxWidth: 180 }}
                                        value={0}
                                        onChange={0}
                                        isDisabled
                                    />}

                                </div>


                                <Button variant="primary" as={Link} to={'/comparer/details/' + generation.id} >Szczegóły</Button>
                            </Card.Body>



                        </Card>
                    </Col>
                ))
                }
            </Row>

        </>
    )
}

export default GenerationList;

//<Container fluid id='container-generationlist'></Container>
//{generation.rate!=null?generation.rate.value:"TBA"}