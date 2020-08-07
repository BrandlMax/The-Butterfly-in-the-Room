import React from "react"
import Hero from "../components/hero"
import Trailer from "../components/trailer"
import TextMedia from "../components/textmedia"
import Downloads from "../components/downloads"
import Context from "../components/context"
import Footer from "../components/footer"
import { Helmet } from "react-helmet"

import "../pages/index.css"

export default function Home() {
  return (
    <div>
      <Helmet>
        <meta charSet="utf-8" />
        <title>The Butterfly in the Room</title>
      </Helmet>
      <Hero />

      <Trailer />

      <div id="about"></div>
      <TextMedia
        title="About the installation"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
      />

      <TextMedia
        title="The Room"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="IMDArtikel_Room"
        type="png"
      />

      <TextMedia
        title="The Table"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="IMDArtikel_Table"
        type="png"
      />

      <TextMedia
        title="The Cards"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="Cards"
        type="png"
      />

      <TextMedia
        title="The Actor-Network"
        text={`
          Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.
        `}
        media="ActorNetwork"
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
          Supervised by Prof. Andrea Krajewski, Garrit Schaap, Andreas Schindler and Prof. Tsunemitsu Tanaka,
          `}
      />

      <Footer />
    </div>
  )
}
