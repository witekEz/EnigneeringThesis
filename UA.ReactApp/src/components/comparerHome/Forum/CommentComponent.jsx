import { useState } from "react";
import { Button, Stack } from "react-bootstrap";
import { useSelector } from "react-redux";
import axios from "axios";
import ReplyComponent from "./ReplyComponent";
import Form from 'react-bootstrap/Form';
import React from "react";


export default function CommentComponent({ comment, generationId, onSelectTrigger, onChangeReply, onChangeComment }) {
    const BASE_URL = 'https://localhost:7092/api';

    const [error, setError] = useState({})

    const [reply, setReply] = useState({})
    const [update, setUpdate] = useState({})

    const nickName = useSelector(state => state.authenticate.name)
    const { isLoggedIn } = useSelector(state => state.authenticate)

    const [isActiveReply, setIsActiveReply] = useState(false);
    const [isActiveUpdate, setIsActiveUpdate] = useState(false);

    const handleDeleteComment = async (commentId) => {
        if (window.confirm("Czy na pewno chcesz usunąć?")) {
            try {
                await axios.delete(`${BASE_URL}/generation/${generationId}/comment/${commentId}`);
                onSelectTrigger()
            }
            catch (error) {
                setError(error);
                console.log(error);
            }
        }
    }

    const handleAddReply = (e) => {
        e.preventDefault();
        onChangeReply(reply, comment.id)
        setReply({});
        setIsActiveReply(false);
    }
    const handleUpdateComment = (e) => {
        e.preventDefault();
        onChangeComment(update, comment.id)
        setUpdate({});
        setIsActiveUpdate(false);
    }

    const generateKey = (pre1, pre2) => {
        return `${pre1}_${pre2}_${new Date().getTime()}`;
    }

    return (
        <>
            <div className="detailsBorder-comments">
                <div className="detailsBorder-comment">
                    <Stack direction="horizontal" gap={1}>
                        <div className="detailsBorder-comments-nickname p-2">{comment.author.nickName}</div>
                        <div className="detailsBorder-comments-date p-2">{comment.createdOn}</div>
                    </Stack>
                    {
                        isActiveUpdate ?
                            <Form>
                                <Form.Group className="mb-3">
                                    <Form.Control as="textarea" onChange={(e) => setUpdate(e.target.value)} defaultValue={comment.content} rows={2} />
                                </Form.Group>
                                <Button type="submit" id="addCommentButton" onClick={e => handleUpdateComment(e)}>Odpowiedz</Button>
                            </Form> : <div className="detailsBorder-comments-content">{comment.content}</div>
                    }
                    <div className="detailsBorder-comments-isModified">{comment.isModified ? "Edytowany" : ""}</div>
                    {
                        isActiveReply ?
                            <Form>
                                <Form.Group className="mb-3">
                                    <Form.Control as="textarea" onChange={(e) => setReply(e.target.value)} placeholder="Odpowiedz" rows={2} />
                                </Form.Group>
                                <Button type="submit" id="addCommentButton" onClick={e => handleAddReply(e)}>Odpowiedz</Button>
                            </Form> : <Stack direction="horizontal" gap={2}>
                                {comment.author.nickName == nickName && isLoggedIn ? <Button size="sm" variant="light" className="p-2 ms-auto" onClick={() => setIsActiveUpdate(true)}>Edytuj</Button> : null}
                                {isLoggedIn ? <Button size="sm" variant="light" className="p-2" onClick={() => setIsActiveReply(true)}>Odpowiedz</Button> : null}
                                {comment.author.nickName == nickName && isLoggedIn ? <Button size="sm" variant="outline-danger" className="p-2" onClick={() => handleDeleteComment(comment.id)}>Usuń</Button> : null}
                            </Stack>
                    }


                </div>
                {comment.replies.length > 0 ? comment.replies.map(reply => (
                    <ReplyComponent
                        key={generateKey(reply.id, reply.content)}
                        reply={reply}
                        commentId={comment.id}
                        onSelectTrigger={onSelectTrigger} />
                )) : null}
            </div>
        </>
    )
}