import { Link } from "react-router-dom";
import { Button, Col, Row, Table, Accordion, Alert, AlertHeading, Stack, Image } from "react-bootstrap";
import Form from 'react-bootstrap/Form';
import ImageComponent from './ImageComponent';
import { Rating } from '@smastrom/react-rating';
import { useState } from "react";
import { useSelector } from "react-redux";
import axios from "axios";
import Comments from "./Forum/CommentsComponent";
import { toast } from 'react-toastify';
import React from "react";

const BASE_URL = 'https://localhost:7092/api';

export default function Generation({ generation }) {

    const generateKey = (pre1, pre2) => {
        return `${pre1}_${pre2}_${new Date().getTime()}`;
    }

    const id = generation.id;
    const { isLoggedIn } = useSelector(state => state.authenticate)

    const [engineId, setEngineId] = useState(0);
    const [gearboxId, setGearboxId] = useState(0);
    const [rating, setRating] = useState({})
    const [engineRating, setEngineRating] = useState({})
    const [gearboxRating, setGearboxRating] = useState({})
    const [error, setError] = useState({});
    let engineTypes = [];
    engineTypes = generation.engines.map(engine => (
        engine.type
    ))
    const uniqueTypes = Array.from(new Set(engineTypes));

    const handleRate = async (rate) => {
        try {
            await axios.post(`${BASE_URL}/generation/${id}/rate`, { value: rate });
            setRating(rate);
            toast.info("Oceniłeś generację")
        } catch (error) {
            setError(error.message);
            toast.error("Już oceniłeś tą generację!")
        }
    };
    const handleEngineRate = async (rate, engineId) => {
        try {
            await axios.post(`${BASE_URL}/engine/${engineId}/rate`, { value: rate });
            toast.info("Oceniłeś silnik")
        } catch (error) {
            setError(error.message);
            toast.error("Już oceniłeś ten silnik!")
        }
    };
    const handleGearboxRate = async (rate, gearboxId) => {
        try {
            await axios.post(`${BASE_URL}/gearbox/${gearboxId}/rate`, { value: rate });
            toast.info("Oceniłeś skrzynię biegów")
        } catch (error) {
            setError(error.message);
            toast.error("Już oceniłeś tą skrzynię biegów!")
        }
    };
    return (
        <>
            <Row className="container-fluid mainRow">
                <Col xxl={6} xl={6} lg={6} md={6} xs={12} id="imageCol">
                    <ImageComponent generation={generation} />
                </Col>
                <Col xxl={6} xl={6} lg={6} md={6} xs={0} className="detailsCol">
                    <Row>
                        <Col xs={4} id="brandName">{generation.model.brand.name}</Col>
                        <Col xs={4} id="modelName">{generation.model.name}</Col>
                        <Col xs={4} id="generationName">{generation.name}</Col>
                    </Row>
                    <Row id="rating-details">
                        <Col id="rating-details-col1" xs={6} md={6}>
                            <p>Wystaw ocenę:</p>
                        </Col>
                        <Col id="rating-details-col2" xs={6} md={6}>
                            {isLoggedIn ? <Rating
                                style={{ maxWidth: 250 }}
                                value={rating}
                                onChange={handleRate}

                            /> : <Rating
                                style={{ maxWidth: 250 }}
                                value={rating}
                                onChange={handleRate}
                                isDisabled={true}
                            />}
                        </Col>
                    </Row>
                    <Row>
                        <p id="averageRate">Średnia ocena: {generation.rate != null ? generation.rate.value : "TBA"}</p>
                        <p id="numberOfRates">Liczba ocen użytkowników: {generation.rate != null ? generation.rate.numberOfRates : "TBA"}</p>
                        <Row className="nazwakurwaten">
                            <Col xs={6} md={6}>
                                <Alert variant="danger" className="alert1">
                                    <p className="price">Cena min:{generation.minPrice != null ? generation.minPrice : "TBA"}</p>
                                </Alert>
                            </Col>
                            <Col xs={6} md={6}>
                                <Alert variant="success" className="alert2">
                                    <p className="price">Cena max:{generation.maxPrice != null ? generation.maxPrice : "TBA"}</p>
                                </Alert>
                            </Col>
                        </Row>

                    </Row>

                </Col>
            </Row>
            <Col className="details-technicalData container-fluid" >
                <p className="details-head">DANE TECHNICZNE</p>
                <Row className="details-engines">
                    <p className="details-p">SILNIKI</p>
                    {uniqueTypes.map(type => (
                        <div className="details-type" key={generateKey(type, "uniqueTypes")}>
                            <p className="details-type-p">{type}</p>
                            <Table responsive className="details-table">
                                <thead>
                                    <tr>
                                        <td>Wersja</td>
                                        <td>Pojemność</td>
                                        <td>Moc</td>
                                        <td>Moment obrotowy</td>
                                        <td>Paliwo</td>
                                        <td>Spalanie w mieście</td>
                                        <td>Spalanie poza miastem</td>
                                        <td>Ocena</td>
                                        <td>Wystaw ocenę</td>
                                    </tr>
                                </thead>
                                <tbody>
                                    {generation.engines.map(engine => (
                                        engine.type == type ?
                                            <tr key={generateKey(engine.id, engine.name)}>
                                                <td>{engine.version}</td>
                                                <td>{engine.capacity}</td>
                                                <td>{engine.horsePower}</td>
                                                <td>{engine.torque}</td>
                                                <td>{engine.type}</td>
                                                <td>{engine.fuelConsumptionCity}</td>
                                                <td>{engine.fuelConsumptionSuburban}</td>
                                                <td>{engine.rate ? engine.rate.value : "TBA"}</td>
                                                <td>
                                                    <div className="row-container">
                                                        {isLoggedIn ? <Rating
                                                            style={{ maxWidth: 120 }}
                                                            value={engineRating}
                                                            onChange={(e) => handleEngineRate(e, engine.id)}

                                                        /> : <Rating
                                                            style={{ maxWidth: 120 }}
                                                            value={engineRating}
                                                            isDisabled={true}
                                                        />}
                                                    </div>
                                                </td>
                                            </tr> : null
                                    ))}
                                </tbody>
                            </Table>
                        </div>
                    ))}
                </Row>
                <Row className="details-gearboxes">
                    <p className="details-p">SKRZYNIE BIEGÓW</p>
                    <div className="details-type">
                        <p className="details-type-p">MANUALNA</p>
                        <Table responsive className="details-table">
                            <thead>
                                <tr>
                                    <td>Nazwa</td>
                                    <td>Liczba biegów</td>
                                    <td>Typ</td>
                                    <td>Ocena</td>
                                    <td>Wystaw ocenę</td>
                                </tr>
                            </thead>
                            <tbody>
                                {generation.gearboxes.map(gearbox => (
                                    gearbox.typeOfGearbox == "Manual" ?
                                        <tr key={generateKey(gearbox.id, gearbox.name)}>
                                            <td>{gearbox.name}</td>
                                            <td>{gearbox.numberOfGears}</td>
                                            <td>Manualna</td>
                                            <td>{gearbox.rate ? gearbox.rate.value : "TBA"}</td>
                                            <td><div className="row-container">{isLoggedIn ? <Rating
                                                style={{ maxWidth: 120 }}
                                                value={gearboxRating}
                                                onChange={(e) => handleGearboxRate(e, gearbox.id)}
                                            /> : <Rating
                                                style={{ maxWidth: 120 }}
                                                value={gearboxRating}
                                                isDisabled={true}
                                            />}
                                            </div>
                                            </td>
                                        </tr> : null
                                ))}
                            </tbody>
                        </Table>
                    </div>
                    <div className="details-type">
                        <p className="details-type-p">AUTOMATYCZNA</p>
                        <Table responsive className="details-table">
                            <thead>
                                <tr>
                                    <td>Nazwa</td>
                                    <td>Liczba biegów</td>
                                    <td>Typ</td>
                                    <td>Ocena</td>
                                    <td>Wystaw ocenę</td>
                                </tr>
                            </thead>
                            <tbody>
                                {generation.gearboxes.map(gearbox => (
                                    gearbox.typeOfGearbox == "Automatic" ?
                                        <tr key={generateKey(gearbox.id, gearbox.name)}>
                                            <td>{gearbox.name}</td>
                                            <td>{gearbox.numberOfGears}</td>
                                            <td>Autmatyczna</td>
                                            <td>{gearbox.rate ? gearbox.rate.value : "TBA"}</td>
                                            <td>
                                                <div className="row-container">{isLoggedIn ? <Rating
                                                    style={{ maxWidth: 120 }}
                                                    value={gearboxRating}
                                                    onChange={(e) => handleGearboxRate(e, gearbox.id)}


                                                /> : <Rating
                                                    style={{ maxWidth: 120 }}
                                                    value={gearboxRating}
                                                    isDisabled={true}
                                                />}
                                                </div>
                                            </td>
                                        </tr> : null
                                ))}
                            </tbody>
                        </Table>
                    </div>
                </Row>
                <Row className="">
                    <Col className="detailsBorder-drivetrains" >
                        <p>NAPĘD</p>
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
                    <Col className="detailsBorder-bodyTypes" md={9}>
                        <p>NADWOZIE</p>
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
                        </Accordion>
                    </Col>
                </Row>
                <Row >
                    <Accordion className="detailsBorder-details">
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
                    </Accordion>

                </Row>
            </Col>
            <Row>
                <Col className="buttonBackEdit">
                    <Button className="" variant="primary" size="lg" as={Link} to={'/comparer/home'}>Cofnij</Button>
                </Col>
            </Row>
            <Row className="">
                <p id="forumLabel">Forum</p>
                <Comments generationId={id} />
            </Row>



        </>
    )
}
