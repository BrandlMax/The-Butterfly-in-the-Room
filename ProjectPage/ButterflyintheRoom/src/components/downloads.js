import React from "react"
import Image from "../components/image"
import "../components/downloads.css"

export default function Downloads() {
  return (
    <section className="downloads" id="downloads">
      <h2>Downloads</h2>
      <p>Download and test our prototype of the showroom</p>
      <div className="platforms">
        <a href="#">
          <Image name="Mac" type="svg" alt="Download for Windows" />
        </a>
        <a href="#">
          <Image name="Windows" type="svg" alt="Download for Windows" />
        </a>
        <a href="#">
          <Image name="Linux" type="svg" alt="Download for Windows" />
        </a>
      </div>
    </section>
  )
}
