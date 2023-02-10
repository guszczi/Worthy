import React from "react"
import { Link } from "react-router-dom"
import { Filter } from "../Filter/Filter"

export const Navbar = () => {
  return (
    <div>
      <nav className="navbar navbar-dark navbar-expand-sm bg-dark">
        <div className="container-fluid">
          <Link className="navbar-brand px-2" to="/">Worthy</Link>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link className="nav-link active" to="/">Strona główna</Link>
              </li>
              <li className="nav-item d-flex align-items-center">
                <Filter />
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  )
}