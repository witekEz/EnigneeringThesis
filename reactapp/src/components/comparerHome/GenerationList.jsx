import { Container, Row, Col, Card, Button } from 'react-bootstrap';
import ImageComponent from './ImageComponent';
const GenerationList = ({ generations, title}) => {

    return (
        <Container fluid>
            <p>{title}</p>
           <Row>
                {generations.items.map(generation => (
                    <Col key={generation.id} id="col-cards" xs={12} md={6} lg={6} xl={4} xxl={3}>
                        <Card style={{ width: '16rem' }} key={generation.id}>
                            <ImageComponent generation={generation} />
                            <Card.Body>
                                <Card.Title>Marka: {generation.model.brand.name}</Card.Title>
                                <Card.Text>
                                    Model: {generation.model.name} <br></br>
                                    Generacja: {generation.name} <br></br>
                                    Kategoria: {generation.category.name} <br></br>
                                    Minimalna cena: {generation.minPrice} <br></br>
                                    Ocena: {generation.rate} <br></br>
                                </Card.Text>
                                <Button variant="primary">Szczegóły</Button>
                            </Card.Body>
                        </Card>
                    </Col>
                ))
                }
            </Row>
        </Container>
    )
}

export default GenerationList;
//if (brands.lenght > 0) {
//    filteredItems = filter(filteredItems,brands)
//}
//if (bodyTypes.lenght > 0) {
//    filteredItems = filteredItems.filter((item) => item.rate >= rate);
//}
//if (categories.lenght > 0) {
//    filteredItems = filteredItems.filter((item) => item.rate >= rate);
//}


//const filterFunc = (arg1, arg2) => {
//    arg1 = arg1.filter((item) => {
//        console.log(item)
//        for (let i = 0; i < arg2.length; i++) {
//            item.model.brand.name  == arg2[i];
//        }
//    })
//    console.log(arg1)
//    return arg1;
    
//}
//const applyFilters = () => {
//    let filteredItems = generations.items;
//
//    if (minPrice) {
//        filteredItems = filteredItems.filter((item) => item.minPrice >= minPrice);
//   }

//    if (maxPrice) {
//        filteredItems = filteredItems.filter((item) => item.maxPrice <= maxPrice);
//    }

//    if (rate) {
//        filteredItems = filteredItems.filter((item) => item.rate >= rate);
//    }
//    if (brands.length > 0) {
//        filteredItems = filterFunc(filteredItems, brands)
//    }
//    if (bodyTypes.length > 0) {
//        filteredItems = filteredItems.filter((item) => item.rate >= rate);
//    }
//    if (categories.length > 0) {
//        filteredItems = filteredItems.filter((item) => item.rate >= rate);
//    }
//    console.log(filteredItems)
//    return filteredItems;
//};

//const [filteredGenerations, setFilteredGenerations] = useState(applyFilters());

//useEffect(() => {
//    setFilteredGenerations(applyFilters());
//}, [minPrice, maxPrice, rate, generations.items]);




/* const [minPrice, setMinPrice] = useState(filters.minPrice);
const [maxPrice, setMaxPrice] = useState(filters.maxPrice);
const [rate, setRate] = useState(filters.rate);

const [brands, setBrands] = useState(filters.brands);
const [bodyTypes, setBodyTypes] = useState(filters.bodyTypes);
const [categories, setCategroies] = useState(filters.categories);

const [filteredGenerations, setFilteredGenerations] = useState(generations.items);
const [error, setError]=useState()

useEffect(() => {
    setMinPrice(filters.minPrice);
    setMaxPrice(filters.maxPrice);
    setRate(filters.rate);

    setBrands(filters.brands)
    setBodyTypes(filters.bodyTypes)
    setCategroies(filters.categories)

}, [filters.minPrice, filters.maxPrice, filters.rate, filters.brands, filters.bodyTypes, filters.categories])


useEffect(()=>{
    const fetchFilteredGenerations = async () => {
    try {
        const response = await fetch(`https://localhost:7092/api/home?pageSize=${pageSize}&pageNumber=${pageNumber}`+
        `${minPrice?`&minPrice=${minPrice}`:''}`+ 
        `${maxPrice?`&maxPrice=${maxPrice}`:''}`+ 
        `${rate?`&rate=${rate}`:''}`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const result = await response.json();
        onGenerationsChange(result);
    } catch (error) {
        setError(error.message);
    }
}
    fetchFilteredGenerations();
},[minPrice, maxPrice, rate, brands, bodyTypes, categories])

useEffect(() => {
    console.log(filteredGenerations)
}, [filteredGenerations]) */