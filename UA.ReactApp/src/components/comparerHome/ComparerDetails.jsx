import { Row,Col } from "react-bootstrap";
import Generation from "./Generation";
export default function ComparerDetails({ generation }) {
    return (
        <Row>
            <Col>
                <p>TEKST1</p>
            </Col>
            <Col xs={6}>
                <Generation generation={generation}></Generation>
            </Col>
            <Col>
                <p>TEKST2</p>
            </Col>
        
        </Row>
           

        
    )
}