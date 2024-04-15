import { Row, Col, Card, Button, ToggleButton } from 'react-bootstrap';
import ImageComponent from './ImageComponent';
import { Link } from 'react-router-dom';
import ComapreGenerationsModal from './Modals/CompareGenerationsModal'
import { Rating, ThinStar } from "@smastrom/react-rating";
import { useEffect, useState } from 'react';

const GenerationList = ({ generations }) => {

    //const [initialCheckedState, setinitialCheckedState] = useState(new Array(generations.items.length).fill(false))
    //useEffect(() => {
    //    setinitialCheckedState(new Array(generations.items.length).fill(false))
    //}, [generations])

    //const initialCheckedState = new Array(initial.items.length).fill(false);
    const [checked, setChecked] = useState(
        Array.from({ length: 15 }, () => ({
            genId: 0,
            isChecked: false
        }))
    );

    useEffect(() => {
        setChecked(
            Array.from({ length: 15 }, () => ({
                genId: 0,
                isChecked: false
            }))
        );
    }, [generations])


    const [marked, setMarked] = useState([])
    const [show, setShow] = useState(0)
    const handleOnChange = (position, genId) => {
        const updatedCheckedState = checked.map((value, index) => ({
            genId: index === position ? genId : value.genId,
            isChecked: index === position ? !value.isChecked : value.isChecked,
        }));
        let temp_marked = [];
        for (let i = 0; i < updatedCheckedState.length; i++) {
            if (updatedCheckedState[i].isChecked == true) {
                temp_marked.push(updatedCheckedState[i].genId)
            }
            else {
                temp_marked = temp_marked.filter((generationId) => generationId !== updatedCheckedState[i].genId)
            }
        }
        setMarked(temp_marked);
        setChecked(updatedCheckedState);
        if (updatedCheckedState[position].isChecked == true) {
            setShow(show + 1)
        }

    };
    const checksmth = () => {
        console.log(checked);
    }
    return (
        <>
            <Row>
                {generations.items.map((generation, index) => (
                    <Col key={generation.id} className="col-cards" xs={12} md={6} lg={6} xl={4} xxl={3}>
                        <Card style={{ width: '16rem' }} key={generation.id}>
                            <ImageComponent generation={generation} />
                            <Card.Body>
                                <Card.Title>Marka: {generation.model.brand.name}</Card.Title>
                                <Card.Text>
                                    Model: {generation.model.name} <br></br>
                                    Generacja: {generation.name} <br></br>
                                    Kategoria: {generation.category.name} <br></br>
                                    Minimalna cena: {generation.minPrice} <br></br>
                                    Ocena: {generation.rate != null ? generation.rate.value : "TBA"}
                                </Card.Text>
                                <div className='rating-card'>
                                    {generation.rate != null ? <Rating
                                        style={{ maxWidth: 180 }}
                                        value={generation.rate.value}
                                        readOnly
                                    /> : <Rating
                                        style={{ maxWidth: 180 }}
                                        value={0}
                                        onChange={0}
                                        isDisabled
                                    />}
                                </div>
                                <Row>
                                    {checked && <Col><ToggleButton variant="outline-secondary" id={`custom-checkbox-${index}`} name="same" value={generation.id} type="checkbox" checked={checked[index].isChecked} onChange={() => handleOnChange(index, generation.id)}>Porównaj</ToggleButton></Col>}
                                    <Col><Button variant="primary" as={Link} to={'/comparer/details/' + generation.id} >Szczegóły</Button></Col>
                                </Row>
                            </Card.Body>
                        </Card>
                    </Col>
                ))
                }
                <ComapreGenerationsModal onShowChange={show} generationsToCompare={marked} />
            </Row>

        </>
    )
}

export default GenerationList;

//{ <Col><ToggleButton variant="outline-secondary" id={`custom-checkbox-${index}`} name="same" value={generation.id} type="checkbox" checked={checked[index].isChecked} onChange={() => handleOnChange(index, generation.id)}>Porównaj</ToggleButton></Col>}