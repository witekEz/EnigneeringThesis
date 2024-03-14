import { Button, Row } from "react-bootstrap"
import { useSelector } from "react-redux"
export default function LoggedComponent({ generation }) {

    const nickName = useSelector(state => state.authenticate.name)
    const role = useSelector(state => state.authenticate.role)
    const { isLoggedIn } = useSelector(state => state.authenticate)

    return (
        <>
            <p id='authenticateLabel'>Profil</p>
            <Row>
                <Button variant="primary" className="loggedButtons">
                    Dodaj samochód
                </Button>
            </Row>
            <Row>
                {generation!=null?<Button variant="primary" className="loggedButtons">
                    Zaktualizauj obecny samochód
                </Button>:<Button variant="primary" disabled className="loggedButtons">
                    Zaktualizauj obecny samochód
                </Button>
            }
            </Row>
            <Row>
            {generation!=null && role=="Admin"?<Button variant="primary" className="loggedButtons">
                    Usuń samochód
                </Button>:<Button variant="primary" disabled className="loggedButtons">
                    Usuń samochód
                </Button>
            }
            </Row>
            <Row>
            {role=="Admin"?<Button variant="primary" className="loggedButtons">
                    Ustawienia
                </Button>:<Button variant="primary" disabled className="loggedButtons">
                    Ustawienia
                </Button>
            }
            </Row>



        </>
    )
}