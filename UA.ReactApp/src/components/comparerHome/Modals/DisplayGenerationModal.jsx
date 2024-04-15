import Form from 'react-bootstrap/Form'
import Accordion from 'react-bootstrap/Accordion'
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table';
import ImageComponent from '../ImageComponent';
import "./modal.css"
import Image from 'react-bootstrap/Image';

export default function DisplayGenerationModal({ generations }) {

    const generateKey = (pre1, pre2) => {
        return `${pre1}_${pre2}_${new Date().getTime()}`;
    }
    const errorURL = "https://placehold.co/600x400";
    return (
        <>
            {generations.length>0?<div>
            <Row>
                <Col xs={3}><Row></Row></Col>
                {generations.map(generation => (
                    <Col className='images' key={generateKey(generation.id, generation.minPrice)}>
                        {generation.images.length>0
                        ?<Row><Image className='sizeOfImage' fluid rounded src={`data:image/jpeg;base64,${generation.images[0].image}`} /></Row>
                        :<Row><Image className='sizeOfImage' fluid rounded  src={errorURL} /></Row>}
                    </Col>
                ))}
            </Row>
            <Row>
                <Col className='thead' xs={3}>
                    <Row id='dark'><p>Marka</p></Row>
                    <Row><p>Model</p></Row>
                    <Row id='dark'><p>Generacja</p></Row>
                    <Row><p>Średnia ocena</p></Row>
                    <Row id='dark'><p>Liczba ocen użytkowników</p></Row>
                    <Row><p>Cena minimalna</p></Row>
                    <Row id='dark'><p>Cena maksymalna</p></Row>
                    <Row><p>Liczba dostępnych silników</p></Row>
                    <Row id='dark'><p>Liczba dostępnych skrzyni biegów</p></Row>
                </Col>
                {generations.map(generation => (
                    <Col key={generateKey(generation.id, generation.name)} className='tbody'>

                        <Row id='dark'><p>{generation.model.brand.name}</p></Row>
                        <Row><p>{generation.model.name}</p></Row>
                        <Row id='dark'><p>{generation.name}</p></Row>
                        <Row><p>{generation.rate != null ? generation.rate.value : "TBA"}</p></Row>
                        <Row id='dark'><p>{generation.rate != null ? generation.rate.numberOfRates : "TBA"}</p></Row>
                        <Row><p>{generation.minPrice != null ? generation.minPrice : "TBA"}</p></Row>
                        <Row id='dark'><p>{generation.maxPrice != null ? generation.maxPrice : "TBA"}</p></Row>
                        <Row><p>{generation.engines.length}</p></Row>
                        <Row id='dark'><p>{generation.gearboxes.length}</p></Row>
                        <Row><p></p></Row>
                        <Row >
                            {generation.detailedInfo!=null?
                            <Accordion>
                                <Accordion.Item eventKey={0}>
                                    <Accordion.Header >SZCZEGÓŁY</Accordion.Header>
                                    <Accordion.Body>
                                        <p className="detailsBorder-details">Data rozpoczęcia produkcji: {generation.detailedInfo.productionStartDate}</p>
                                        <p className="detailsBorder-details">Data zakończenia produkcji: {generation.detailedInfo.productionEndDate}</p>
                                        <p className="detailsBorder-details">Zawieszenia: {generation.detailedInfo.suspensions.map(suspension => (
                                            <li key={generateKey(suspension.id, generation.name)}>{suspension.type} </li>
                                        ))}</p>
                                        <Accordion >
                                            <Accordion.Header>Dostępne kolory nadwozia</Accordion.Header>
                                            <Accordion.Body>
                                                <div>{generation.detailedInfo.bodyColours.map(bodyColour => (
                                                    <div className="detailsBorder" key={generateKey(bodyColour.id, bodyColour.colourCode)}>
                                                        <p> {bodyColour.colour} </p><br></br>
                                                        <p> {bodyColour.colourCode} </p>
                                                    </div>
                                                ))}</div>
                                            </Accordion.Body>
                                        </Accordion>
                                        <p>Hamulce: {generation.detailedInfo.brakes.map(brake => (
                                            <li key={generateKey(brake.id, brake.type)}> {brake.type} </li>
                                        ))}</p>
                                        <p>Posiadane wyposażenie</p>
                                        <ol>
                                            {generation.optionalEquipment.rearAxleSteering ? <li>Tylna oś skrętna</li> : null}
                                            {generation.optionalEquipment.standardTailPipes ? <li>Standardowe końcówki wydechu</li> : null}
                                            {generation.optionalEquipment.rooftop ? <li>Szyberdach</li> : null}
                                            {generation.optionalEquipment.abs ? <li>ABS</li> : null}
                                            {generation.optionalEquipment.esp ? <li>ESP</li> : null}
                                            {generation.optionalEquipment.asr ? <li>ASR</li> : null}
                                        </ol>
                                    </Accordion.Body>
                                </Accordion.Item>
                            </Accordion>:<p>Brak danych</p>}
                        </Row>
                        <Col>
                            <p id='drivetrains'>Napędy</p>
                            <Form>
                                {generation.drivetrains.map(drivetrain => (
                                    <Form.Check
                                        type="radio"
                                        label={drivetrain.type}
                                        checked={true}
                                        readOnly={true}
                                        key={generateKey(drivetrain.id, drivetrain.type)}
                                    />
                                ))}
                            </Form>
                        </Col>
                        <Col md={9}>
                            <p id='bodyTypes'>Dostępne nadwozia</p>
                            {generation.bodies.length>0?
                            <Accordion>
                                {generation.bodies.map(body => (
                                    <Accordion.Item eventKey={body.id} key={generateKey(body.id, body.name)}>
                                        <Accordion.Header>{body.bodyType != null ? body.bodyType.name : "Brak kategorii"}</Accordion.Header>
                                        <Accordion.Body>
                                            Segment: {body.segment}<br></br>
                                            Liczba drzwi: {body.numberOfDoors}<br></br>
                                            Liczba miejsc siedzących: {body.numberOfSeats}<br></br>
                                            Pojemność bagażnika w litrach: {body.trunkCapacity}<br></br>
                                        </Accordion.Body>
                                    </Accordion.Item>
                                )
                                )}
                            </Accordion>:<p>Brak danych</p>}
                        </Col>
                    </Col>))}

            </Row></div>:null}
        </>
    )
}