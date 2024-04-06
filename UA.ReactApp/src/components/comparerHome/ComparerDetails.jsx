import { Row,Col } from "react-bootstrap";
import Generation from "./Generation";
import AuthenticateComponent from "./Autenticate/AuthenticateComponent"
import { useDispatch, useSelector } from 'react-redux'
import LoggedComponent from "./Autenticate/LoggedComponent";

export default function ComparerDetails({ generation }) {
    const {isLoggedIn}=useSelector(state=>state.authenticate);
    return (
        <Row id="comparer-details-main">
            <Col  xxl={2} xl={2} lg={0} md={0} xs={0} className="bg-body-tertiary comparer-details-col-left">
                
            </Col>
            <Col xxl={8} xl={8} lg={12} md={12} xs={12} className="comparer-details-col-main">
                <Generation generation={generation}></Generation>
            </Col>
            <Col xxl={2} xl={2} lg={0} md={0} xs={0} className="bg-body-tertiary comparer-details-col-right" >
                <AuthenticateComponent generation={generation}/>
            </Col>
        
        </Row>
           

        
    )
}