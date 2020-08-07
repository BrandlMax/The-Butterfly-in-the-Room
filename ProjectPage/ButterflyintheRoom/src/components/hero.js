import React from "react"
import Image from "../components/image"
import "../components/hero.css"

const video = require("../images/LandingpageHeader.mp4")

const scrollToDownload = function () {
  document.querySelector("#downloads").scrollIntoView({
    behavior: "smooth",
  })
}

export default function Hero() {
  return (
    <section className="heroImage">
      <div className="heroContent">
        <video muted playsInline autoPlay loop>
          <source
            src={video}
            type='video/mp4; codecs="avc1.42E01E, mp4a.40.2"'
          />
        </video>
        <nav>
          {/* <a href="#play">
            <Image name="play" type="svg" alt="" />
            Play Trailer
          </a>
          <a href="#about">
            <Image name="about" type="svg" alt="" />
            About the Installation
          </a> */}
          <a className="quickDownload" onClick={scrollToDownload}>
            <Image name="down" type="svg" alt="" />
            Download interactive prototype
          </a>
        </nav>
      </div>
    </section>
  )
}
