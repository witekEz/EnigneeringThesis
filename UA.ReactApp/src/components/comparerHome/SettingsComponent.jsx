import Form from "react-bootstrap/Form"
import axios from "axios"
import { useEffect, useState } from "react";
import { Button, FormCheck, Table } from "react-bootstrap";
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router-dom';
import React from "react";


export default function SettingsComponent() {
    const BASE_URL = 'https://localhost:7092/api';

    const generateKey = (pre1, pre2) => {
        return `${pre1}_${pre2}}`;
    }

    const [error, setError] = useState({});
    const [users, setUsers] = useState([]);
    const [checkedUser, setCheckedUser] = useState(0);
    const [isChecked, setIsChecked] = useState(false)
    const [form, setForm]=useState({});
    const navigate = useNavigate();

    const setField = (field, value) => {
        setForm({
            ...form,
            [field]: value
        })
        if (!!error[field])
            setError({
                ...error,
                [field]: null
            })
    }

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/user`);
                const data = result.data;
                setUsers(data)
            }
            catch (e) {
                setError(e);
            }
        }
        fetchUsers();
    }, [])
    const handleUserChange = (event) => {
        const { value } = event.target;
        setCheckedUser(value);
        setIsChecked(true);
    }
    const handleUpdateUser = async()=>{
        try{
            await axios.put(`${BASE_URL}/user/${checkedUser}`, form);
        }
        catch(err){
            setError(err);
            toast.success('Zaktualizowano!')
        }
    }
    return (
        <div className="settings-main">
            <div className="test">
                <Table className="settings-table">
                    <thead>
                        <tr>
                            <td>Wybierz</td>
                            <td>Email</td>
                            <td>Nazwa</td>
                            <td>Rola</td>
                            <td>Identyfikator roli</td>
                        </tr>
                    </thead>
                    <tbody>
                        {users != null ? users.map(user => (
                            <tr key={generateKey(user.id, user.nickName)}>
                                <td>
                                    <FormCheck
                                        type="radio"
                                        id={user.id}
                                        name="users"
                                        value={user.id}
                                        onChange={handleUserChange}
                                    />
                                </td>
                                <td>{user.email}</td>
                                <td>{user.nickName}</td>
                                <td>{user.role.name}</td>
                                <td>{user.roleId}</td>
                            </tr>
                        )) : null}
                    </tbody>
                </Table>
            </div>
            <Form className="settings-form">
                <Form.Group>
                    <Form.Label className="form-update">Email:</Form.Label>
                    <Form.Control
                        onChange={(e) => setField('email', e.target.value)}
                        placeholder={checkedUser ? users[checkedUser - 1].email : "Wybierz użytkownika"}
                    />
                    <Form.Control.Feedback type="invalid">
                        ERR
                    </Form.Control.Feedback>

                    <Form.Label className="form-update">Nazwa:</Form.Label>
                    <Form.Control
                        onChange={(e) => setField('nickName', e.target.value)}
                        placeholder={checkedUser ? users[checkedUser - 1].nickName : "Wybierz użytkownika"}
                        type='text'
                    />
                    <Form.Control.Feedback type="invalid">
                        ERR
                    </Form.Control.Feedback>
                    <Form.Label className="form-update">Rola:</Form.Label>
                    <Form.Control
                        onChange={(e) => setField('roleId', e.target.value)}
                        placeholder={checkedUser ? users[checkedUser - 1].roleId : "Wybierz użytkownika"}
                        type='number'
                    />
                </Form.Group>
                <Button disabled={!isChecked} onClick={handleUpdateUser}>Zaktualizuj</Button>
            </Form>

        </div>
    )
}