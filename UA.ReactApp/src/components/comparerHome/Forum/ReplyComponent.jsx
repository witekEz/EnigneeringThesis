import { useState } from "react";
import { Button, Stack } from "react-bootstrap";
import { useSelector } from "react-redux";
import Form from 'react-bootstrap/Form';
import axios from "axios";

export default function ReplyComponent({ reply, commentId, onSelectTrigger }) {


    const BASE_URL = 'https://localhost:7092/api';

    const [form, setForm] = useState({})
    const [error, setError] = useState({})

    const nickName = useSelector(state => state.authenticate.name)
    const { isLoggedIn } = useSelector(state => state.authenticate)

    const [update, setUpdate] = useState({})
    const [isActiveUpdate, setIsActiveUpdate] = useState(false);

    const handleDeleteReply = async (replyId) => {
        if (window.confirm("Czy na pewno chcesz usunąć?")) {
            try {
                await axios.delete(`${BASE_URL}/comment/${commentId}/reply/${replyId}`);
                onSelectTrigger()
            }
            catch (error) {
                setError(error);
                console.log(error);
            }
        }
    }
    const handleUpdateReply = async (e) => {
        e.preventDefault();
        if (update != null && update != "" && update != undefined) {
            try {
                await axios.put(`${BASE_URL}/comment/${commentId}/reply/${reply.id}`, {
                    content: update
                });
                onSelectTrigger();
                setIsActiveUpdate(false);
            }
            catch (error) {
                setError(error);
                console.log(error);
            }
        }
    }

    return (
        <>
            <div className="detailsBorder-replies" >
                <Stack direction="horizontal" gap={1}>
                    <div className="detailsBorder-comments-nickname p-2">{reply.author.nickName}</div>
                    <div className="detailsBorder-comments-date p-2">{reply.createdOn}</div>
                </Stack>
                {
                    isActiveUpdate ?
                        <Form>
                            <Form.Group className="mb-3">
                                <Form.Control as="textarea" onChange={(e) => setUpdate(e.target.value)} defaultValue={reply.content} rows={2} />
                            </Form.Group>
                            <Button type="submit" id="addCommentButton" onClick={e => handleUpdateReply(e)}>Aktualizuj</Button>
                        </Form> : <div className="detailsBorder-comments-content">{reply.content}</div>
                }

                <div>{reply.isModified ? "Edytowany" : ""}</div>
                <Stack direction="horizontal" gap={1}>
                    {reply.author.nickName == nickName && isLoggedIn ? <Button className="p-2 ms-auto" size="sm" variant="light" onClick={() => setIsActiveUpdate(true)}>Edytuj</Button> : null}
                    {reply.author.nickName == nickName && isLoggedIn ? <Button className="p-2" size="sm" variant="outline-danger" onClick={() => handleDeleteReply(reply.id)} >Usuń</Button> : null}
                </Stack>

            </div>
        </>
    )
}