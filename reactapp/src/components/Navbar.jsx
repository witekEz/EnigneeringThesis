import React from "react"

export default function Navbar() {
    return (
        <>
            <nav class="navbar bg-body-tertiary">
                <div class="container-fluid justify-content-center">
                    <form class="d-flex" role="search">
                        <input class="form-control me-2" type="search" placeholder="Wprowadź dane" aria-label="Search" />
                        <button class="btn btn-outline-success" type="submit">Szukaj</button>
                    </form>
                </div>
            </nav>
        </>
    )
}