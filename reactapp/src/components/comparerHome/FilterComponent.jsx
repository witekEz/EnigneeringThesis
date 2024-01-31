import { useState, useEffect } from 'react';
import { Col, Row, InputGroup, FormLabel } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';


function FilterComponent({ onChangePrice }) {
    const [form, setForm] = useState({})
    const [errors, setErrors] = useState({})

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
                    <Form.Label>Ocena</Form.Label>
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
                            id={`checkbox-${category.id}`}
                            label={category.name}
                        />
                    ))}
                </Form.Group>
                <Form.Group>
                    <p>Marka</p>
                    {brands != null && brands.map((brand) => (
                        <Form.Check // prettier-ignore
                            type="checkbox"
                            key={brand.id}
                            id={`checkbox-${brand.id}`}
                            label={brand.name}
                        />
                    ))}
                </Form.Group>
                <Form.Group>
                    <p>Nadwozie</p>
                    {bodyTypes != null && bodyTypes.map((bodyType) => (
                        <Form.Check // prettier-ignore
                            type="checkbox"
                            key={bodyType.id}
                            id={`checkbox-${bodyType.id}`}
                            label={bodyType.name}
                        />
                    ))}
                </Form.Group>



            </Form>

        </>
    )
}
export default FilterComponent;



