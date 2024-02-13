import React, { useEffect, useState, useCallback } from "react"
import NavigationBar from '../NavigationBar';
import GenerationList from "./GenerationList";
import PaginationComponent from "./PaginationComponent"
import PageSizeComponent from "./PageSizeComponent"
import FilterComponent from "./FilterComponent"
import { Row, Col, Container } from "react-bootstrap";
export default function ComparerHome({ fetchedCars, errorWhileFetch, onChangeFilters, paginationFetched, onChangePage, onChangePageSize, onChangeSearch }) {

    const [cars, setCars] = useState(fetchedCars)
    const [error, setError] = useState(errorWhileFetch)
    const [pagination, setPagination] = useState(paginationFetched)

    useEffect(() => {
        setCars(fetchedCars);
        setError(errorWhileFetch);
        setPagination(paginationFetched);
    }, [fetchedCars, errorWhileFetch, paginationFetched])

    const handleChangePage = useCallback((page) => {
        onChangePage(page);
    }, [])
    const handleChangePageSize = useCallback((pageSize) => {
        onChangePageSize(pageSize);
    }, [])
    const handleChangeFilters = useCallback((filters) => {
        onChangeFilters(filters);
    }, [])
    const handleSearchChange = useCallback((searchPhase) => {
        onChangeSearch(searchPhase);
    })

    return (
        <>
            <NavigationBar onChangeSearch={handleSearchChange} />
            
                <Row className="home">
                    <Col xxl={2} xl={2} lg={3} md={3} xs={4} className="bg-body-tertiary">
                        <FilterComponent onChangeFilters={handleChangeFilters} />
                    </Col>
                    <Col xxl={8} xl={8} lg={6} md={8} xs={4} > 
                            <Row>     
                                {cars && <GenerationList generations={cars} title="All Generations!" />}
                            </Row>
                            <Row className="paginationItems" >
                                <Col>{pagination.totalItemsCount > 5 && <PageSizeComponent pageSize={pagination.pageSize} onChangePageSize={handleChangePageSize} />}</Col>
                                <Col>{pagination.totalPages > 1 && <PaginationComponent pagination={pagination} onChangePage={handleChangePage} />}</Col>
                            </Row>
                    </Col>
                    <Col xxl={2} xl={2} lg={3} md={0} xs={4} className="bg-body-tertiary">
                    </Col>
                </Row>
            

            <div>
                {errorWhileFetch && <p>Error: {error}</p>}
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