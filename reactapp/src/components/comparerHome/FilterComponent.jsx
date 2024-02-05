import { useState, useEffect } from 'react';
import { Col, Row, FormLabel, Button } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';


function FilterComponent({ onChangeFilters }) {
    const [form, setForm] = useState({})
    const [errors, setErrors] = useState({})
    const [checkedCategories, setCheckedCategories] = useState([])
    const [checkedBrands, setCheckedBrands] = useState([])
    const [checkedBodyTypes, setCheckedBodyTypes] = useState([])

    const [categories, setCategories] = useState(null)
    const [brands, setBrands] = useState(null)
    const [bodyTypes, setBodyTypes] = useState(null)
    const [error, setError] = useState(null)

    useEffect(() => {
        const fetchFilters = async () => {
            try {
                const categoryResponse = await fetch(`https://localhost:7092/api/category`);
                const brandResponse = await fetch(`https://localhost:7092/api/brand`);
                const bodyTypeResponse = await fetch(`https://localhost:7092/api/bodytype`);
                if (!categoryResponse.ok || !brandResponse.ok || !bodyTypeResponse.ok) {
                    throw new Error('Network response was not ok');
                }
                const categoryResult = await categoryResponse.json();
                const brandResult = await brandResponse.json();
                const bodyTypeResult = await bodyTypeResponse.json();
                setCategories(categoryResult);
                setBrands(brandResult);
                setBodyTypes(bodyTypeResult);

            } catch (error) {
                setError(error.message);
            }
        };
        fetchFilters();
    }, [])

    const setField = (field, value) => {
        setForm({
            ...form,
            [field]: value
        })
        if (!!errors[field])
            setErrors({
                ...errors,
                [field]: null
            })
    }
    const handleChangeOnCategory = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedCategories(pre => [...pre, value])
        }
        else {
            setCheckedCategories(pre => {
                return [...pre.filter(category => category !== value)]
            })
        }
    }
    const handleChangeOnBrand = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedBrands(pre => [...pre, value])
        }
        else {
            setCheckedBrands(pre => {
                return [...pre.filter(brand => brand !== value)]
            })
        }
    }
    const handleChangeOnBodyType = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedBodyTypes(pre => [...pre, value])
        }
        else {
            setCheckedBodyTypes(pre => {
                return [...pre.filter(bodyType => bodyType !== value)]
            })
        }
    }
    useEffect(() => {
        setForm({
            ...form,
            categories: checkedCategories,
            brands: checkedBrands,
            bodyTypes: checkedBodyTypes,
        });
    }, [checkedCategories, checkedBrands, checkedBodyTypes]);
    function handleSubmit(e) {
        e.preventDefault();
        onChangeFilters(form);
    }
    

    return (
        <>
            <Form>
                <Row>
                    <p>Cena</p>
                    <Col>
                        <Form.Group size="sm" className="mb-3" controlId='minPrice'>
                            <FormLabel>Od</FormLabel>
                            <Form.Control
                                type='number'
                                value={form.minPrice}
                                onChange={(e) => setField('minPrice', e.target.value)}

                            />
                        </Form.Group>
                    </Col>
                    <Col>
                        <Form.Group size="sm" className="mb-3" controlId='maxPrice'>
                            <FormLabel>Do</FormLabel>
                            <Form.Control
                                type='number'
                                value={form.maxPrice}
                                onChange={(e) => setField('maxPrice', e.target.value)}

                            />
                        </Form.Group>
                    </Col>
                </Row>
                <Form.Group controlId='rate'>
                    <Form.Label>Minimalna ocena</Form.Label>
                    <Form.Range
                        min={0}
                        max={5}
                        step={0.1}
                        value={form.Rate}
                        onChange={(e) => setField('rate', e.target.value)}
                    />
                    {form.rate}
                </Form.Group>
                <Form.Group>
                    <p>Kategoria</p>
                    {categories != null && categories.map((category) => (
                        <Form.Check // prettier-ignore
                            type="checkbox"
                            key={category.id}
                            label={category.name}
                            value={category.name}
                            onChange={handleChangeOnCategory}
                        />
                    ))}
                </Form.Group>
                <Form.Group>
                    <p>Marka</p>
                    {brands != null && brands.map((brand) => (
                        <Form.Check // prettier-ignore
                            type="checkbox"
                            key={brand.id}
                            label={brand.name}
                            value={brand.name}
                            onChange={handleChangeOnBrand}
                        />
                    ))}
                </Form.Group>
                <Form.Group>
                    <p>Nadwozie</p>
                    {bodyTypes != null && bodyTypes.map((bodyType) => (
                        <Form.Check  //prettier-ignore
                            type="checkbox"
                            key={bodyType.id}
                            id={`checkbox-${bodyType.id}`}
                            label={bodyType.name}
                            value={bodyType.name}
                            onChange={handleChangeOnBodyType}
                        />
                    ))}
                </Form.Group>
                <Button variant="primary" type="submit" onClick={(e) => handleSubmit(e)}>
                    Zatwierdź zmiany
                </Button>
            </Form>

        </>
    )
}
export default FilterComponent;



