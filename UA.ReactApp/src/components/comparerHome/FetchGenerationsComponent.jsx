import { useState, useEffect, useCallback } from "react";
import ComparerHome from "./ComparerHome";
import { Spinner } from "react-bootstrap";
import axios from "axios";

export default function FetchGenerationsComponent() {
    const BASE_URL = 'https://localhost:7092/api';

    const [cars, setCars] = useState(null)
    const [error, setError] = useState(null)
    const [pagination, setPagination] = useState({})
    const [page, setPage] = useState(1)
    const [pageSize, setPageSize] = useState(5)
    const [filters, setFilters] = useState({
        minPrice: '',
        maxPrice: '',
        rate: '',
        bodyTypes: [],
        brands: [],
        categories: []
    })

    const [minPrice, setMinPrice] = useState(filters.minPrice);
    const [maxPrice, setMaxPrice] = useState(filters.maxPrice);
    const [rate, setRate] = useState(filters.rate);

    const [brands, setBrands] = useState(filters.brands);
    const [bodyTypes, setBodyTypes] = useState(filters.bodyTypes);
    const [categories, setCategroies] = useState(filters.categories);

    const [brandsSendable, setBrandsSendable] = useState("");
    const [bodyTypesSendable, setBodyTypesSendable] = useState("");
    const [categoriesSendable, setCategroiesSendable] = useState("");
    const [isPending, setIsPending]=useState(true)

    const [searchPhase, setSearchPhase] = useState(undefined);

    useEffect(() => {
        setMinPrice(filters.minPrice);
        setMaxPrice(filters.maxPrice);
        setRate(filters.rate);

        setBrands(filters.brands)
        setBodyTypes(filters.bodyTypes)
        setCategroies(filters.categories)

    }, [filters])
    useEffect(() => {
        let brandString = "";
        if (brands.length > 0) {
            brandString = brands.reduce((result, item) => {
                return `${result}${item},`
            }, "")
            brandString = brandString.slice(0, -1);
        }
        setBrandsSendable(brandString);

    }, [brands])
    useEffect(() => {
        let categoryString = '';
        if (categories.length > 0) {
            categoryString = categories.reduce((result, item) => {
                return `${result}${item},`
            }, "")
            categoryString = categoryString.slice(0, -1);
        }
        setCategroiesSendable(categoryString);
    }, [categories])
    useEffect(() => {
        let bodyTypeString = '';
        if (brands.length > 0) {
            bodyTypeString = bodyTypes.reduce((result, item) => {
                return `${result}${item},`
            }, "")
            bodyTypeString = bodyTypeString.slice(0, -1);
        }
        setBodyTypesSendable(bodyTypeString);
    }, [bodyTypes])

    useEffect(() => {
        const fetchCars = async () => {
            try{
                const response = await axios.get(`${BASE_URL}/home?pageSize=${pageSize}&pageNumber=${page}` +
                `${minPrice ? `&minPrice=${minPrice}` : ''}` +
                `${maxPrice ? `&maxPrice=${maxPrice}` : ''}` +
                `${rate ? `&avgRate=${rate}` : ''}` +
                `${brandsSendable != "" ? `&filterBrands=${brandsSendable}` : ''}` +
                `${categoriesSendable != "" ? `&filterCategories=${categoriesSendable}` : ''}` +
                `${bodyTypesSendable != "" ? `&filterBodyTypes=${bodyTypesSendable}` : ''}` +
                `${searchPhase ? `&search=${searchPhase}` : ''}`);
                setCars(response.data);
                setPagination({ totalPages: response.data.totalPages, itemFrom: response.data.itemFrom, itemTo: response.data.itemTo, totalItemsCount: response.data.totalItemsCount, page: page })
                setIsPending(false)
            }catch (error) {
                setError(error.message);
            }
        };
        fetchCars();

    }, [page, pageSize, minPrice, maxPrice, rate, searchPhase, brandsSendable, bodyTypesSendable, categoriesSendable])

    const handleFiltersChange = useCallback((filters) => {
        setFilters(filters);
    }, [])
    const handlePageChange = useCallback((page) => {
        setPage(page);
    }, [])
    const handlePageSizeChange = useCallback((pageSize) => {
        setPageSize(pageSize);
    }, [])
    const handleSearchChange = useCallback((searchPhase) => {
        setSearchPhase(searchPhase);
    }, [])

    return (
        <>
            {isPending && <Spinner className="spinnerLoading" animation="grow" />}
            {cars && <ComparerHome fetchedCars={cars} errorWhileFetch={error} onChangeFilters={handleFiltersChange} paginationFetched={pagination} onChangePage={handlePageChange} onChangePageSize={handlePageSizeChange} onChangeSearch={handleSearchChange} />}
        </>
    )

}