import { Link } from "react-router-dom";
import { Button, Col, Row } from "react-bootstrap";
import ImageComponent from './ImageComponent';
import StarRatingComponent from "./StarRatingComponent";

export default function Generation({ generation }) {
    const avgPrice = generation.maxPrice / generation.minPrice;
    return (
        <>
            <Row>
                <Col id="imageCol">
                    <ImageComponent generation={generation} />
                </Col>
                <Col>
                    <Row>
                        Marka: {generation.model.brand.name}<br></br>
                        Model: {generation.model.name} <br></br>
                        Generacja: {generation.name} <br></br>
                    </Row>
                    <Row>
                        <StarRatingComponent
                            name="app4"
                            editing={false}
                            starCount={5}
                            value={generation.rate} />
                    </Row>

                    Kategoria: {generation.category.name} <br></br>
                    Średnia cena: {avgPrice} <br></br>
                    Ocena: {generation.rate} <br></br>
                    <Link to={'/comparerHome'}>Cofnij</Link>
                    <Button>Edytuj</Button>
                </Col>
            </Row>
            <Row>

            </Row>
        </>
    )
}