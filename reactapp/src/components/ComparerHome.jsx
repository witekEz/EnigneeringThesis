import React, { useEffect, useState, useCallback } from "react"
import NavigationBar from './NavigationBar';
import GenerationList from "./comparerHome/GenerationList";
import PaginationComponent from "./comparerHome/PaginationComponent"
import PageSizeComponent from "./comparerHome/PageSizeComponent"
import FilterComponent from "./comparerHome/FilterComponent"
import { Row, Col } from "react-bootstrap";
export default function ComparerHome() {

    const BASE_URL = 'https://localhost:7092/api'

    const [cars, setCars] = useState(null)
    const [error, setError] = useState(null)
    const [pagination, setPagination] = useState({})
    const [page, setPage] = useState(1)
    const [pageSize, setPageSize] = useState(5)


    useEffect(() => {
        const fetchCars = async () => {
            try {
                const response = await fetch(`https://localhost:7092/api/home?pageSize=${pageSize}&pageNumber=${page}`);

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
    }, [page, pageSize])

    const handleChangePage = useCallback((page) => {
        setPage(page)
    }, [])
    const handleChangePageSize = useCallback((pageSize) => {
        setPageSize(pageSize)
    }, [])

    return (
        <>
            <NavigationBar />
            <div className="home">
                <Row>
                    <Col xxl={2} xl={2} lg={2} md={2} xs={2}>
                        <FilterComponent/>
                    </Col>
                    <Col xxl={8} xl={8} lg={8} md={8} xs={8}>
                        {cars && <GenerationList generations={cars} title="All Generations!" />}
                        <Row>
                            <Col>{pagination.totalItemsCount > 5 && <PageSizeComponent pageSize={pagination.pageSize} onChangePageSize={handleChangePageSize} />}</Col>
                            <Col>{pagination.totalPages > 1 && <PaginationComponent pagination={pagination} onChangePage={handleChangePage} />}</Col>
                        </Row>
                    </Col>
                    <Col xxl={2} xl={2} lg={2} md={2} xs={2}>
                        <FilterComponent/>
                    </Col>
                </Row>


            </div>

            <div>
                {error && <p>Error: {error}</p>}
                {cars && (
                    <div>
                        <h1>Data from API:</h1>
                        <pre>{JSON.stringify(cars, null, 2)}</pre>
                    </div>
                )}
            </div>


        </>
    )
}