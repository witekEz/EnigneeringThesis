import { useState, useEffect, useCallback } from "react";
import ComparerHome from "./ComparerHome";

export default function FetchGenerationsComponent() {
    const BASE_URL = 'https://localhost:7092/api';

    const [cars, setCars] = useState(null)
    const [error, setError] = useState(null)
    const [pagination, setPagination] = useState({})
    const [page, setPage] = useState(1)
    const [pageSize, setPageSize] = useState(5)
    const [filters, setFilters] = useState({
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

    useEffect(() => {
        setMinPrice(filters.minPrice);
        setMaxPrice(filters.maxPrice);
        setRate(filters.rate);

        setBrands(filters.brands)
        setBodyTypes(filters.bodyTypes)
        setCategroies(filters.categories)

    }, [filters])

    useEffect(() => {
        const fetchCars = async () => {
            try {
                const response = await fetch(`https://localhost:7092/api/home?pageSize=${pageSize}&pageNumber=${page}` +
                    `${minPrice ? `&minPrice=${minPrice}` : ''}` +
                    `${maxPrice ? `&maxPrice=${maxPrice}` : ''}` +
                    `${rate ? `&rate=${rate}` : ''}`);

                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                const result = await response.json();
                setCars(result);
                setPagination({ totalPages: result.totalPages, itemFrom: result.itemFrom, itemTo: result.itemTo, totalItemsCount: result.totalItemsCount, page: page })
            } catch (error) {
                setError(error.message);
            }
        };
        fetchCars();
        
    }, [page, pageSize, minPrice, maxPrice, rate, brands, bodyTypes, categories])

    const handleFiltersChange = useCallback((filters) => {
        setFilters(filters);
    }, [])
    const handlePageChange = useCallback((page) => {
        setPage(page);
    }, [])
    const handlePageSizeChange = useCallback((pageSize) => {
        setPageSize(pageSize);
    }, [])

    return(
        <>
            {cars && <ComparerHome fetchedCars={cars}  errorWhileFetch={error} onChangeFilters={handleFiltersChange} paginationFetched={pagination} onChangePage={handlePageChange} onChangePageSize={handlePageSizeChange} />}
        </>
    )

}