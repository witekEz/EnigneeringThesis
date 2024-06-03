import { useEffect, useState } from "react";
import axios from "axios";
import { Button, Stack } from "react-bootstrap";
import { useSelector } from "react-redux";
import Form from 'react-bootstrap/Form';
import CommentComponent from "./CommentComponent";
import React from "react";

export default function Comments({ generationId }) {
    const BASE_URL = 'https://localhost:7092/api';

    const [comments, setComments] = useState([])
    const [error, setError] = useState({})

    const [form, setForm] = useState({})
    const [trigger, setTrigger] = useState(true)
    

    useEffect(() => {
        const fetchComments = async () => {
            try {
                const response = await axios.get(`${BASE_URL}/generation/${generationId}/comment`);
                setComments(response.data);
                console.log(response.data)
            } catch (error) {
                setError(error.message);
                console.log(error.message)
            }
        };
        fetchComments();
    }, [trigger])


    const handleAddComment = async (e) => {
        e.preventDefault();
        if (form != null && form != "" && form != undefined) {
            try {
                const response = await axios.post(`${BASE_URL}/generation/${generationId}/comment`, {
                    content: form
                });
                console.log(response);
                const data = await response.data;
                setTrigger(!trigger)
            }
            catch (error) {
                setError(error);
                console.log(error);
            }
        }
    }
    const handleAddReply = async (value, commentId) => {
        if (value != null && value != "" && value != undefined) {
            try {
                await axios.post(`${BASE_URL}/comment/${commentId}/reply`, {
                    content: value
                });
                setTrigger(!trigger)
            }
            catch (error) {
                setError(error);
                console.log(error);
            }
        }
    }
    const handleUpdateComment = async (value, commentId) => {
        if (value != null && value != "" && value != undefined) {
            try {
                await axios.put(`${BASE_URL}/generation/${generationId}/comment/${commentId}`, {
                    content: value
                });
                setTrigger(!trigger)
            }
            catch (error) {
                setError(error);
                console.log(error);
            }
        }
    }

    const handleTrigger = () =>{
        setTrigger(!trigger)
    }

    const generateKey = (pre1, pre2) => {
        return `${pre1}_${pre2}_${new Date().getTime()}`;
    }

    return (
        <>
            <Form>
                <Form.Group className="mb-3">
                    <Form.Control as="textarea" onChange={(e) => setForm(e.target.value)} placeholder="Dodaj komentarz" rows={2} />
                </Form.Group>
                <Button type="submit" id="addCommentButton" onClick={e => handleAddComment(e)}>Dodaj komentarz</Button>
            </Form>
            {comments.length > 0 ? comments.map(comment => (
                <CommentComponent 
                    key={generateKey(comment.id, comment.content)} 
                    comment={comment} 
                    generationId={generationId} 
                    onSelectTrigger={handleTrigger}
                    onChangeReply={handleAddReply}
                    onChangeComment={handleUpdateComment}
                    />
            )) : null}
        </>
    )
}