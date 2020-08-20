import React from "react"
import Image from "../components/image"
import "../components/downloads.css"

export default function Downloads({ title, text }) {
  return (
    <section className="downloads" id="downloads">
      <div className="downloadWrapper">
        <h2>{title}</h2>
        <p dangerouslySetInnerHTML={{ __html: text }}></p>
        <div className="platforms">
          <a
            href="https://butterfly.brandlmax.com/_downloads/ButterflyInTheRoom_MacOS.zip"
            target="_blank"
          >
            <Image name="Mac" type="svg" alt="Download for Windows" />
          </a>
          <a
            href="https://butterfly.brandlmax.com/_downloads/ButterflyInTheRoom_Windows.zip"
            target="_blank"
          >
            <Image name="Windows" type="svg" alt="Download for Windows" />
          </a>
          {/* <a href="#">
            <Image name="Linux" type="svg" alt="Download for Windows" />
          </a> */}
        </div>
      </div>
    </section>
  )
}
