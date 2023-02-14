import React from "react"
import { Link } from "react-router-dom"

export const Navbar = () => {
  return (
    <div>
      <nav className="navbar navbar-dark navbar-expand-sm bg-dark">
        <div className="container-fluid d-flex align-items-center justify-content-center">
          <Link className="navbar-brand px-4" to="/">WORTHY</Link>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
        </div>
      </nav>
    </div>
  )
}