import React from "react"
import Image from "../components/image"
import "../components/hero.css"

export default function Hero() {
  return (
    <section className="heroImage">
      <div className="heroContent">
        <Image
          className="logo"
          name="Logo"
          type="png"
          alt="Butterfly in the Room"
        />
        <nav>
          <a href="#play">
            <Image name="play" type="svg" alt="" />
            Play Trailer
          </a>
          <a href="#about">
            <Image name="about" type="svg" alt="" />
            About the Installation
          </a>
          <a href="#downloads">
            <Image name="down" type="svg" alt="" />
            Download online version
          </a>
        </nav>
      </div>
      <div className="heroMask">
        <Image name="BubbleMask" type="svg" alt="" />
      </div>
    </section>
  )
}
