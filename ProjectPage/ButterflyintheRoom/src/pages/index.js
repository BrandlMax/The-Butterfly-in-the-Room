import React from "react"
import Hero from "../components/hero"
import Trailer from "../components/trailer"
import TextMedia from "../components/textmedia"
import Downloads from "../components/downloads"
import Context from "../components/context"
import Footer from "../components/footer"

import "../pages/index.css"

export default function Home() {
  return (
    <div>
      <Hero />

      <Trailer />

      <div id="about"></div>
      <TextMedia
        title="About the installation"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="exampleImageMedia"
        type="png"
      />

      <TextMedia
        title="The Room"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="exampleImageMedia"
        type="png"
      />

      <TextMedia
        title="The Table"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="exampleImageMedia"
        type="png"
      />

      <TextMedia
        title="The Cards"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="exampleImageMedia"
        type="png"
      />

      <TextMedia
        title="The Actor-Network"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="exampleImageMedia"
        type="png"
      />

      <Downloads />

      <Context
        title="Context"
        text={`
          This project was developed by <a href="https://www.portfolio.philippkaltofen.com/" target="_blank">Philipp Kaltofen</a> and <a href="https://brandlmax.com/" target="_blank">Maximilian Brandl</a> as the bachelor project in Interactive Media Design at the Darmstadt University of Applied Sciences.
          <br/><br/>
          It bases on their Research about <a href="https://assets.ctfassets.net/63aiuaob1j2v/2dMlr9rcKqrbGYMVg9fviz/583012caab67b6bc16ecccb108982a0e/Entangled-Interface_Brandl_Kaltofen.pdf" target="_blank">Entangled Interfaces</a>.
          <br/><br/>
          A special thanks goes to Prof. Claudius Coenen, Prof. Andrea Krajewski, Prof. Garrit Schaap, Prof. Tsunemitsu Tanaka, Dieter Stasch, Dr. Stefan Voigt, Christoph Diederichs, Holger Bassarek and Michael Allinger, who always provided us with assistance and advice during the last semesters.
        `}
      />

      <Footer />
    </div>
  )
}
