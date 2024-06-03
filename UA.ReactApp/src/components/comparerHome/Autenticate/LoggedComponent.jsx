import { Button, Row } from "react-bootstrap"
import { useSelector } from "react-redux"
import { Link } from 'react-router-dom';
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";
import { useState } from "react";
import UpdateGenerationModal from "../Modals/UpdateGenerationModal";
import React from "react";


export default function LoggedComponent({ generation }) {
    const BASE_URL = 'https://localhost:7092/api';
    const nickName = useSelector(state => state.authenticate.name)
    const role = useSelector(state => state.authenticate.role)
    const { isLoggedIn } = useSelector(state => state.authenticate)
    const navigate = useNavigate();
    const [error, setError]=useState({})
    const [show, setShow]= useState(0)

    const handleDelete = async () => {
        try {
            await axios.delete(`${BASE_URL}/model/${generation.model.id}/generation/${generation.id}`);
            toast.success("Usunięto");
            navigate('/comparer/home');
        }
        catch (err) {
            setError(err);
            toast.error("Błąd podczas usuwania samochodu!");
        }
    }
    const handleShowUpdateModal=()=>{
        setShow(show+1);
    }

    return (
        <>
            <p id='authenticateLabel'>Profil</p>
            <Row>
                <Button as={Link} variant="primary" to={'/comparer/create'} className="loggedButtons">
                    Dodaj pojazd
                </Button>
            </Row>
            <Row>
                {generation != null ? <Button variant="primary" onClick={handleShowUpdateModal} className="loggedButtons">
                    Zaktualizauj obecny pojazd
                </Button> : <Button variant="primary" disabled className="loggedButtons">
                    Zaktualizauj obecny pojazd
                </Button>
                }
            </Row>
            <Row>
                {generation != null && role == "Admin" ? <Button variant="primary" onClick={handleDelete} className="loggedButtons">
                    Usuń pojazd
                </Button> : <Button variant="primary" disabled className="loggedButtons">
                    Usuń pojazd
                </Button>
                }
            </Row>
            <Row>
                {role == "Admin" ? <Button as={Link} to={'/comparer/settings'} variant="primary" className="loggedButtons">
                    Ustawienia
                </Button> : <Button variant="primary" disabled className="loggedButtons">
                    Ustawienia
                </Button>
                }
            </Row>
            {generation!=null?<UpdateGenerationModal generationId={generation.id} modelId={generation.model.id} onShowChange={show}/>:null}


        </>
    )
}