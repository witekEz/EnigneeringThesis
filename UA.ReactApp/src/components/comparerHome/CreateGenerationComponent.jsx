import Form from "react-bootstrap/Form"
import axios from "axios"
import { useEffect, useState } from "react";
import { Button, FormCheck, Table } from "react-bootstrap";
import CreateEngineModal from "./Modals/CreateEngineModal";
import CreateGearboxModal from "./Modals/CreateGearboxModal";
import CreateBodyColourModal from "./Modals/CreateBodyColourModal";
import CreateBrakeModal from "./Modals/CreateBrakeModal";
import CreateSuspensionModal from "./Modals/CreateSuspensionModal";
import { Accordion, Row, Col } from "react-bootstrap";
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router-dom';
import React from "react";



export default function CreateGenerationComponent() {
    const BASE_URL = 'https://localhost:7092/api';

    const generateKey = (pre1, pre2) => {
        return `${pre1}_${pre2}}`;
    }

    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();
    today = yyyy + '-' + mm + '-' + dd;

    const [errors, setErrors] = useState({});
    const [error, setError] = useState({});
    const [brands, setBrands] = useState([]);
    const [models, setModels] = useState([]);
    const [categories, setCategories] = useState([]);
    const [drivetrains, setDrivetrains] = useState(null);
    const [engines, setEngines] = useState(null);
    const [gearboxes, setGearboxes] = useState(null);
    const [productionDate, setProductionDate] = useState(null);
    const [bodyColours, setBodyColours] = useState(null);
    const [brakes, setBrakes] = useState(null)
    const [suspensions, setSuspensions] = useState(null);
    const [bodyTypes, setBodyTypes] = useState(null);

    const navigate = useNavigate();

    const [created, setCreated] = useState()

    const [selectedBrand, setSelectedBrand] = useState({});
    const [selectedModel, setSelectedModel] = useState({});
    const [selectedCategory, setSelectedCategory] = useState(0);
    const [checkedDrivetrains, setCheckedDrivetrains] = useState([]);
    const [checkedEngines, setCheckedEngines] = useState([]);
    const [checkedGearboxes, setCheckedGearboxes] = useState([]);
    const [checkedBodyColours, setCheckedBodyColours] = useState([]);
    const [checkedBrakes, setCheckedBrakes] = useState([]);
    const [checkedSuspensions, setCheckedSuspensions] = useState([]);
    const [checkedBodyType, setCheckedBodyType] = useState({});
    const [bodyForm, setBodyForm] = useState({
        "segment": "",
        "numberOfDoors": "",
        "numberOfSeats": "",
        "trunkCapacity": "",
    })
    const [optionalEquipmentForm, setOptionalEquipmentForm] = useState({
        "rearAxleSteering": false,
        "standardTailPipes": false,
        "rooftop": false,
        "abs": false,
        "esp": false,
        "asr": false,
    })
    const [form, setForm] = useState({
        "name": "",
        "minPrice": "",
        "maxPrice": ""
    })
    const [detailedInfoForm, setDetailedInfoForm] = useState({})
    const [image, setImage] = useState(null)

    useEffect(() => {
        const fetchBrands = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/brand`);
                const data = result.data;
                setBrands(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        fetchBrands();
    }, [])
    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/category`);
                const data = result.data;
                setCategories(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        fetchCategories();
    }, [])
    useEffect(() => {
        const fetchDrivetrains = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/drivetrain`);
                const data = result.data;
                setDrivetrains(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        fetchDrivetrains();
    }, [])
    useEffect(() => {
        const fetchEngines = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/engine`);
                const data = result.data;
                setEngines(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        fetchEngines();
    }, [created])
    useEffect(() => {
        const fetchGearboxes = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/gearbox`);
                const data = result.data;
                setGearboxes(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        fetchGearboxes();
    }, [created])
    useEffect(() => {
        const fetchBodyTypes = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/bodytype`);
                const data = result.data;
                setBodyTypes(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        fetchBodyTypes();
    }, [created])
    useEffect(() => {
        const fetchBodyColours = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/bodycolour`);
                const data = result.data;
                setBodyColours(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        const fetchBrakes = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/brake`);
                const data = result.data;
                setBrakes(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        const fetchSuspensions = async () => {
            try {
                const result = await axios.get(`${BASE_URL}/suspension`);
                const data = result.data;
                setSuspensions(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
        fetchBodyColours();
        fetchBrakes();
        fetchSuspensions();
    }, [created])

    const handleBrandChange = async (event) => {
        setSelectedBrand(event.target.value);
        if (event.target.value != 0) {
            try {
                const result = await axios.get(`${BASE_URL}/brand/${event.target.value}/model`);
                const data = result.data;
                setModels(data)
            }
            catch (e) {
                setErrors(e);
            }
        }
    }

    const setOptionalEquipmentField = (event) => {
        const { value, checked } = event.target;
        setOptionalEquipmentForm({
            ...optionalEquipmentForm,
            [value]: checked
        })
    }
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
    const setBodyField = (field, value) => {
        setBodyForm({
            ...bodyForm,
            [field]: value
        })
        if (!!errors[field])
            setErrors({
                ...errors,
                [field]: null
            })
    }
    const setDetailedInfoField = (field, value) => {
        setDetailedInfoForm({
            ...detailedInfoForm,
            [field]: value
        })
        if (!!errors[field])
            setErrors({
                ...errors,
                [field]: null
            })
    }

    const validate = () => {
        let error = {};

        if (!form.name) {
            error.name = 'Nazwa generacji jest wymagana do jej utworzenia';
        }
        if (selectedCategory == 0) {
            error.selectedCategory = 'Wybierz odpowiednią kategorię';
        }
        if (!bodyForm.numberOfDoors) {
            error.numberOfDoors = 'Wypełnij to pole';
        }
        if (!bodyForm.numberOfSeats) {
            error.numberOfSeats = 'Wypełnij to pole';
        }
        if (!checkedDrivetrains || checkedDrivetrains.length <= 0) {
            error.checkedDrivetrains = 'Dodaj minimum jeden napęd';
        }
        if (!checkedEngines || checkedEngines.length <= 0) {
            error.checkedEngines = 'Dodaj minimum jeden silnik';
        }
        if (!checkedGearboxes || checkedGearboxes.length <= 0) {
            error.checkedGearboxes = 'Dodaj minimum jedną skrzynię';
        }

        return error;
    };

    const handleModelChange = (event) => {
        setSelectedModel(event.target.value);
    }
    const handleCategoryChange = (event) => {
        setSelectedCategory(event.target.value);
    }
    const handleDrivetrainsChange = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedDrivetrains(pre => [...pre, value]);
        }
        else {
            setCheckedDrivetrains(pre => {
                return [...pre.filter(drivetrain => drivetrain !== value)]
            })
        }
    }
    const handleEnginesChange = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedEngines(pre => [...pre, value])
        }
        else {
            setCheckedEngines(pre => {
                return [...pre.filter(engine => engine !== value)]
            })
        }

    }
    const handleGearboxesChange = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedGearboxes(pre => [...pre, value])
        }
        else {
            setCheckedGearboxes(pre => {
                return [...pre.filter(gearbox => gearbox !== value)]
            })
        }
    }
    const handleBodyColourChange = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedBodyColours(pre => [...pre, value])
        }
        else {
            setCheckedBodyColours(pre => {
                return [...pre.filter(colour => colour !== value)]
            })
        }
    }
    const handleBrakeChange = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedBrakes(pre => [...pre, value])
        }
        else {
            setCheckedBrakes(pre => {
                return [...pre.filter(brake => brake !== value)]
            })
        }
    }
    const handleSuspensionChange = (event) => {
        const { value, checked } = event.target;
        if (checked) {
            setCheckedSuspensions(pre => [...pre, value])
        }
        else {
            setCheckedSuspensions(pre => {
                return [...pre.filter(suspension => suspension !== value)]
            })
        }
    }
    const handleBodyTypeChange = (event) => {
        const { value } = event.target;
        setCheckedBodyType(value)
    }
    const handleGenerationCreate = async () => {
        const errors = validate();
        setErrors(errors);
        const detailedInfoFormLocal = {
            ...detailedInfoForm,
            'bodyColours': checkedBodyColours,
            'suspensions': checkedSuspensions,
            'brakes': checkedBrakes
        }
        let tempBodyForm = {
            ...bodyForm
        }
        if (checkedBodyType.length > 0) {
            tempBodyForm = {
                ...bodyForm,
                "bodyTypeId": checkedBodyType
            }
        }
        const generationForm = {
            ...form,
            'categoryId': selectedCategory,
            'body': tempBodyForm,
            'drivetrains': checkedDrivetrains,
            'engines': checkedEngines,
            'gearboxes': checkedGearboxes,
            'detailedInfo': detailedInfoFormLocal,
            'optionalEquipment': optionalEquipmentForm
        }
        try {
            const generationId = await axios.post(`${BASE_URL}/model/${selectedModel}/generation`, generationForm)
            if (image != null) {
                const fi = new FormData();
                fi.append('image', image)
                await axios.post(`${BASE_URL}/image/${generationId.data}`, fi);
            }
            navigate('/comparer/home');
            toast.success("Utworzono nowe auto!")
        }
        catch (err) {
            setError(err);
            toast.error("Błędy w formularzu!")
        }
    }


    return (
        <div className="createGeneration-main">
            <div>
                <Form.Select value={selectedBrand} onChange={handleBrandChange} className="createGeneration-select" aria-label="Default select example">
                    <option value={0}>Wybierz markę</option>
                    {brands.length > 0 ? brands.map(brand => (
                        <option key={generateKey(brand.id, brand.name)} value={brand.id}>{brand.name}</option>
                    )) : null}
                </Form.Select>
                <Form.Select value={selectedModel} onChange={handleModelChange} className="createGeneration-select" aria-label="Default select example">
                    <option value={0}>Wybierz model</option>
                    {models.length > 0 ? models.map(model => (
                        <option key={generateKey(model.id, model.name)} value={model.id}>{model.name}</option>
                    )) : null}
                </Form.Select>
                <Form.Control
                    id="generationName"
                    value={form.name}
                    required={true}
                    placeholder='Generacja'
                    onChange={(e) => setField('name', e.target.value)}
                    isInvalid={!!errors.name}
                />
                <Form.Control.Feedback type="invalid">
                    {errors.name}
                </Form.Control.Feedback>
                <Row>
                    <Col id='col1'>
                        <Form.Group size="sm" className="mb-3" controlId='minPrice'>
                            <Form.Control
                                type='number'
                                value={form.minPrice}
                                placeholder='Minimalna cena'
                                onChange={(e) => setField('minPrice', e.target.value)}

                            />
                        </Form.Group>
                    </Col>
                    <Col id='col2'>
                        <Form.Group size="sm" className="mb-3" controlId='maxPrice'>
                            <Form.Control
                                type='number'
                                value={form.maxPrice}
                                placeholder='Maksymalna cena'
                                onChange={(e) => setField('maxPrice', e.target.value)}

                            />
                        </Form.Group>
                    </Col>
                </Row>
                <Form.Select isInvalid={!!errors.selectedCategory} value={selectedCategory} onChange={handleCategoryChange} className="createGeneration-select" aria-label="Default select example">
                    <option value={0}>Wybierz kateogrię</option>
                    {categories.length > 0 ? categories.map(category => (
                        <option key={generateKey(category.id, category.name)} value={category.id}>{category.name}</option>
                    )) : null}
                </Form.Select>
                <Form.Control.Feedback type="invalid">
                    {errors.selectedCategory}
                </Form.Control.Feedback>
                <Form.Group controlId="formFile" className="mb-3">
                    <p id="image">Wyślij zdjęcie</p>
                    <Form.Control type="file" onChange={(e) => setImage(e.target.files[0])} />
                </Form.Group>
                <Form.Group className="createGeneration-bodyType">
                    <p id="bodyType">Nadwozie</p>
                    <Form.Control
                        id="generationName"
                        value={bodyForm.segment}
                        placeholder='Segment'
                        onChange={(e) => setBodyField('segment', e.target.value)}
                    />
                    <Form.Control
                        id="generationName"
                        type='number'
                        value={bodyForm.numberOfDoors}
                        placeholder='Liczba drzwi'
                        onChange={(e) => setBodyField('numberOfDoors', e.target.value)}
                        isInvalid={!!errors.numberOfDoors}
                    />
                    <Form.Control.Feedback type="invalid">
                        {errors.numberOfDoors}
                    </Form.Control.Feedback>
                    <Form.Control
                        id="generationName"
                        type='number'
                        value={bodyForm.numberOfSeats}
                        placeholder='Liczba miejsc'
                        onChange={(e) => setBodyField('numberOfSeats', e.target.value)}
                        isInvalid={!!errors.numberOfSeats}
                    />
                    <Form.Control.Feedback type="invalid">
                        {errors.numberOfSeats}
                    </Form.Control.Feedback>
                    <Form.Control
                        id="generationName"
                        type='number'
                        value={bodyForm.trunkCapacity}
                        placeholder='Pojemność bagażnika w litrach'
                        onChange={(e) => setBodyField('trunkCapacity', e.target.value)}
                    />
                    <Accordion>
                        <Accordion.Item eventKey="0">
                            <Accordion.Header>Wybierz rodzaj nadwozia</Accordion.Header>
                            <Accordion.Body>
                                <Table responsive className="detailsBorder-bodyTypes-table">
                                    <thead>
                                        <tr>
                                            <td>Wybierz</td>
                                            <td>Nazwa</td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {bodyTypes != null ? bodyTypes.map(bodyType => (
                                            <tr key={generateKey(bodyType.id, bodyType.name)}>
                                                <td>
                                                    <FormCheck type="radio"
                                                        id={bodyType.id}
                                                        name="jakas"
                                                        value={bodyType.id}
                                                        onChange={handleBodyTypeChange}
                                                    />
                                                </td>
                                                <td>{bodyType.name}</td>
                                            </tr>
                                        )) : null}
                                    </tbody>
                                </Table>
                            </Accordion.Body>
                        </Accordion.Item>
                    </Accordion>
                </Form.Group>
                <Form.Group className="createGeneration-drivetrain" >
                    <p id="drivetrain">Wybierz napęd</p>
                    {drivetrains != null && drivetrains.map((drivetrain) => (
                        <Form.Check
                            type="checkbox"
                            key={drivetrain.id}
                            id={drivetrain.id}
                            label={drivetrain.type}
                            value={drivetrain.id}
                            onChange={handleDrivetrainsChange}
                        />

                    ))}

                </Form.Group>
                <Form.Control.Feedback type="invalid">
                    {errors.checkedDrivetrains}
                </Form.Control.Feedback>
                <div className="createGeneration-engines">
                    <Row>
                        <Col xs={10}>
                            <Accordion>
                                <Accordion.Item eventKey="0">
                                    <Accordion.Header>Wybierz silniki</Accordion.Header>
                                    <Accordion.Body>
                                        <Table responsive className="detailsBorder-engines-table">
                                            <thead>
                                                <tr>
                                                    <td>Wybierz</td>
                                                    <td>Wersja</td>
                                                    <td>Pojemność</td>
                                                    <td>Moc</td>
                                                    <td>Moment obrotowy</td>
                                                    <td>Paliwo</td>
                                                    <td>Spalanie w mieście</td>
                                                    <td>Spalanie poza miastem</td>
                                                    <td>Ocena</td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {engines != null ? engines.map(engine => (
                                                    <tr key={generateKey(engine.id, engine.name)}>
                                                        <td>
                                                            <FormCheck type="checkbox"
                                                                id={engine.id}
                                                                value={engine.id}
                                                                onChange={handleEnginesChange}
                                                            />
                                                        </td>
                                                        <td>{engine.version}</td>
                                                        <td>{engine.capacity}</td>
                                                        <td>{engine.horsePower}</td>
                                                        <td>{engine.torque}</td>
                                                        <td>{engine.type}</td>
                                                        <td>{engine.fuelConsumptionCity}</td>
                                                        <td>{engine.fuelConsumptionSuburban}</td>
                                                        <td>{engine.rate ? engine.rate.value : "TBA"}</td>
                                                    </tr>
                                                )) : null}
                                            </tbody>
                                        </Table>
                                    </Accordion.Body>
                                </Accordion.Item>
                            </Accordion>
                        </Col>
                        <Col xs={2}>
                            <CreateEngineModal onEngineCreate={setCreated} />
                        </Col>

                    </Row>

                </div>
                <Form.Control.Feedback type="invalid">
                    {errors.checkedEngines}
                </Form.Control.Feedback>
                <div className="createGeneration-gearboxes">
                    <Row>
                        <Col xs={10}>
                            <Accordion>
                                <Accordion.Item eventKey="0">
                                    <Accordion.Header>Wybierz skrzynie biegów</Accordion.Header>
                                    <Accordion.Body>
                                        <Table responsive className="">
                                            <thead>
                                                <tr>
                                                    <td>Wybierz</td>
                                                    <td>Nazwa</td>
                                                    <td>Liczba biegów</td>
                                                    <td>Typ</td>
                                                    <td>Ocena</td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {gearboxes != null ? gearboxes.map(gearbox => (
                                                    <tr key={generateKey(gearbox.id, gearbox.name)}>
                                                        <td>
                                                            <FormCheck type="checkbox"
                                                                id={gearbox.id}
                                                                value={gearbox.id}
                                                                onChange={handleGearboxesChange}></FormCheck>
                                                        </td>
                                                        <td>{gearbox.name}</td>
                                                        <td>{gearbox.numberOfGears}</td>
                                                        <td>{gearbox.typeOfGearbox}</td>
                                                        <td>{gearbox.rate ? gearbox.rate.value : "TBA"}</td>
                                                    </tr>
                                                )) : null}
                                            </tbody>
                                        </Table>
                                    </Accordion.Body>
                                </Accordion.Item>
                            </Accordion>
                        </Col>
                        <Col xs={2}>
                            <CreateGearboxModal onGearboxCreate={setCreated} />
                        </Col>
                    </Row>
                </div>
                <Form.Control.Feedback type="invalid">
                    {errors.checkedGearboxes}
                </Form.Control.Feedback>
                <Form.Group className="createGeneration-detailedInfo">
                    <p id="detailedInfo">Szczegółowe informacje</p>
                    <Row>
                        <Col>
                            <p id="productionDate">Rozpoczęcie produkcji</p>
                            <Form.Control value={detailedInfoForm.productionStartDate} className="createGeneration-productionDate" type="date" onChange={(e) => setDetailedInfoField('productionStartDate', e.target.value)} />
                        </Col>
                        <Col>
                            <p id="productionDate">Zakończenie produkcji</p>
                            <Form.Control value={detailedInfoForm.productionEndDate} className="createGeneration-productionDate" type="date" onChange={(e) => setDetailedInfoField('productionEndDate', e.target.value)} />
                        </Col>
                    </Row>
                    <Row>
                        <Col xs={10}>
                            <Accordion>
                                <Accordion.Item eventKey="0">
                                    <Accordion.Header>Wybierz odpowiednie kolory</Accordion.Header>
                                    <Accordion.Body>
                                        <Table responsive >
                                            <thead>
                                                <tr>
                                                    <td>Wybierz</td>
                                                    <td>Nazwa</td>
                                                    <td>Kod lakieru</td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                {bodyColours != null ? bodyColours.map(bodyColour => (
                                                    <tr key={generateKey(bodyColour.id, bodyColour.colour)}>
                                                        <td>
                                                            <FormCheck type="checkbox"
                                                                id={bodyColour.id}
                                                                value={bodyColour.id}
                                                                onChange={handleBodyColourChange}></FormCheck>
                                                        </td>
                                                        <td>{bodyColour.colour}</td>
                                                        <td>{bodyColour.colourCode}</td>
                                                    </tr>
                                                )) : null}
                                            </tbody>
                                        </Table>
                                    </Accordion.Body>
                                </Accordion.Item>
                            </Accordion>
                        </Col>
                        <Col xs={2}>
                            <CreateBodyColourModal onBodyColourCreate={setCreated} />
                        </Col>
                    </Row>
                    <div className="brakes">
                        <p id="brakes">Wybierz hamulce</p>
                        {brakes != null && brakes.map((brake) => (

                            <Form.Check
                                type="checkbox"
                                key={brake.id}
                                id={brake.id}
                                label={brake.type}
                                value={brake.id}
                                onChange={handleBrakeChange}
                            />

                        ))}
                        <CreateBrakeModal onBrakesCreate={setCreated} />
                    </div>
                    <div className="suspension">
                        <p id="suspension">Wybierz zawieszenie</p>
                        {suspensions != null && suspensions.map((suspension) => (
                            <Form.Check
                                type="checkbox"
                                key={suspension.id}
                                id={suspension.id}
                                label={suspension.type}
                                value={suspension.id}
                                onChange={handleSuspensionChange}
                            />
                        ))}
                        <CreateSuspensionModal onSuspensionCreate={setCreated} />
                    </div>

                </Form.Group>
                <Form.Group className="createGeneration-optionalEquipment">
                    <p id="optionalEquipment">Opcjonalne wyposażenie</p>
                    <Form.Check // prettier-ignore
                        type="switch"
                        id="custom-switch1"
                        label="Tylna oś skrętna"
                        value={"rearAxleSteering"}
                        onChange={setOptionalEquipmentField}

                    />
                    <Form.Check // prettier-ignore
                        type="switch"
                        id="custom-switch2"
                        label="Standardowe końcówki wydechu"
                        value={"standardTailPipes"}
                        onChange={setOptionalEquipmentField}
                    />
                    <Form.Check // prettier-ignore
                        type="switch"
                        id="custom-switch3"
                        label="Szyberdach"
                        value={"rooftop"}
                        onChange={setOptionalEquipmentField}
                    />
                    <Form.Check // prettier-ignore
                        type="switch"
                        id="custom-switch4"
                        label="ABS"
                        value={"abs"}
                        onChange={setOptionalEquipmentField}
                    />
                    <Form.Check // prettier-ignore
                        type="switch"
                        id="custom-switch5"
                        label="ESP"
                        value={"esp"}
                        onChange={setOptionalEquipmentField}
                    />
                    <Form.Check // prettier-ignore
                        type="switch"
                        id="custom-switch6"
                        label="ASR"
                        value={"asr"}
                        onChange={setOptionalEquipmentField}
                    />
                </Form.Group>
            </div>
            <Button variant="primary" id="addGeneration" onClick={handleGenerationCreate}>Utwórz nowy pojazd</Button>
        </div>
    )
}