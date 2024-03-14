import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { Button } from 'react-bootstrap';
import LoginComponent from './LoginComponent';
import { useCallback, useEffect, useRef, useState } from 'react';
import RegisterComponent from './RegisterComponent';
import { toast } from 'react-toastify';
import axios from 'axios';
import 'react-toastify/dist/ReactToastify.css';
import LoggedComponent from './LoggedComponent';
import setAuthenticationHeader from '../Utilities/DefaultAuthHeaderComponent';
import { useDispatch, useSelector } from 'react-redux'
import { changeState, changeRole, changeName } from '../Utilities/Redux/authentication';
import { jwtDecode } from "jwt-decode";

const BASE_URL = 'https://localhost:7092/api';

export default function AuthenticateComponent({generation}) {
    const [loginComponent, setComponent] = useState(true);

    const [registerForm, setRegisterForm] = useState({});
    const [loginForm, setLoginForm] = useState({});

    const [decodedToken, setDecodedToken]=useState({});

    const {isLoggedIn}=useSelector(state=>state.authenticate)
    const dispatch=useDispatch();

    const [error, setError] = useState({});

    useEffect(() => {
        loadComponent(loginComponent)
    }, [loginComponent, isLoggedIn])



    const handleRegister = useCallback((registerForm) => {
        setRegisterForm(registerForm);
        handleFetchRegister(registerForm);
    }, [])
    const handleLogin = useCallback((loginForm) => {
        setLoginForm(loginForm);
        handleFetchLogin(loginForm);
    }, [])
    const handleLogout=()=>{
        dispatch(changeState())
        dispatch(changeRole("User"))
        dispatch(changeName(""))
        sessionStorage.removeItem("token");
    }

    const handleFetchLogin = async (loginForm) => {
        if (loginForm != null) {
            try {
                const result = await axios.post(`${BASE_URL}/account/login`, loginForm)
                const data = await result.data;
                console.log(result);
                sessionStorage.setItem("token", data);

                const aboutUser=jwtDecode(data);
                const role=aboutUser["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                const nickname=aboutUser.NickName;
                setDecodedToken(aboutUser);
                toast.success("Zalogowano!")
                dispatch(changeState());
                dispatch(changeRole(role));
                dispatch(changeName(nickname));
                setAuthenticationHeader(data);
                
            } catch (error) {
                setError(error);
                toast.error("Nieudane logowanie!")
            }
        }
        else {
            toast.warning("Uzupełnij formularz");
        }
    }
    const handleFetchRegister = async (registerForm) => {
        if (registerForm != null) {
            try {
                const result = await axios.post(`${BASE_URL}/account/register`, registerForm)
                toast.success("Udana rejestracja!")
                setComponent(true);
            } catch (error) {
                toast.error("Nieudana rejestracja!")
                setError(error);
            }
        }
    }

    const loadComponent = (loginComponent) => {
        if (loginComponent) {
            if (isLoggedIn) {
                return <LoggedComponent generation={generation}/>
            }
            else {
                return <LoginComponent onLoginChange={handleLogin} />
            }

        }
        else {
            return <RegisterComponent onRegisterChange={handleRegister} />
        }

    }
    const loadButton = (loginComponent) => {
        if (loginComponent) {
            if (isLoggedIn) {
                return <Button variant='secondary' className='loginRegisterLogoutButtons' onClick={() => handleLogout()}>
                Wyloguj
            </Button>
            }
            else {
                return <Button variant='secondary' className='loginRegisterLogoutButtons' onClick={() => setComponent(false)}>
                    Zarejestruj
                </Button>
            }

        }
        else {
            return <Button variant='secondary' className='loginRegisterLogoutButtons' onClick={() => setComponent(true)}>
                Zaloguj
            </Button>
        }

    }

    return (
        <Form id='authenticateComponent'>
            {loadComponent(loginComponent)}
            <Row>
                {loadButton(loginComponent)}
            </Row>
        </Form>
    )
}