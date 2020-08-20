import React from "react"
import Hero from "../components/hero"
import Trailer from "../components/trailer"
import TextMedia from "../components/textmedia"
import Downloads from "../components/downloads"
import Feedback from "../components/feedback"
import Context from "../components/context"
import Footer from "../components/footer"
import { Helmet } from "react-helmet"

import "../pages/index.css"

export default function Home() {
  return (
    <div className="theWrapper">
      <Helmet>
        <meta charSet="utf-8" />
        <title>The Butterfly in the Room</title>
      </Helmet>
      <Hero />

      <Trailer />

      <div id="about">
        <TextMedia
          title="About the installation"
          text={`The Butterfly in the Room takes visitors on a journey through the hidden networks of actors that surround us all.  It was created with the intention to serve as an object for discourse on more-than-human design, to give designers the opportunity to explore the subject and related consequences of their own design.

The project deals with the question of how the invisible networks of actors are influenced by human design and how these consequences and the networks themselves can be made visible. Based on the previous research project, <a href="http://files.brandlmax.com/Entangled-Interface_Brandl_Kaltofen.pdf" target="_blank" rel="noreferrer">Entangled Interfaces</a>, a network of actors surrounding an unnamed Internet Of Things (IoT) device was explored and analyzed.
`}
        />
      </div>

      <TextMedia
        title="The Room"
        text={`
          The room serves as a spacial boundary and represents the working space of the designer. The design of the room is based on a further consideration of the development of designers into Life System Architects, from the previous research work. Thus, the working title of the room became "Gods-Room" to provocatively represent the designer as a "creator". In order to achieve this, an attempt was made to exaggerate the clichéd minimalist trend associated with design.
          `}
        media="IMDArtikel_Room"
        type="png"
      />

      <TextMedia
        title="The Table"
        text={`
          The table, which stands in the middle of the room, is representative of the human-centred design with which we are familiar today. It serves as a juxtaposition to the projection in front of it, which stands for the Post Human-Centered. The view beyond the edge of the table is thus a view beyond the edge of the plate, into a network of actors. The IoT product and a generic persona are projected onto the table in front of the visitors, between these two a relationship will be designed by them.
          `}
        media="IMDArtikel_Table"
        type="png"
      />

      <TextMedia
        title="The Cards"
        text={`
          The fictional method kit is to be understood as a parody of the currently increasing tools and methodologies of human-centered design. Each of the cards corresponds to an exemplary, specific design decision that visitors can make to shape a relationship. By simply placing the card on the table, the relationship and the network in front of them changes.
           `}
        media="Cards"
        type="png"
      />

      <TextMedia
        title="The Actor-Network"
        text={`
          The heart of the installation is the network of actors. The aim is to convey the extent to which the individual, often very different actors are connected. Here, a controller can be used to navigate through the network of actors and to discover the effects of the decisions previously made. Scan the QR Code with your smartphone to explore the room in VR.
          `}
        media="IMDArtikel_WallsAR"
        type="png"
      />

      <Downloads
        title="Interactive Preview (Sneak-Peek)"
        text={`
          Download and try our small interactive preview of the installation.
          `}
      />

      <Feedback
        title="Feedback and suggestions"
        text={`
          You have comments, thoughts or even suggestions for scenarios and actors for our installation? We would be happy if you share them with us. Especially the scenarios are a work in progress, so we would be very pleased to receive your suggestions.
          `}
      />

      <Context
        title="Context"
        text={`
          This project was developed by <a href="https://www.portfolio.philippkaltofen.com/" target="_blank" rel="noreferrer">Philipp Kaltofen</a> and <a href="https://brandlmax.com/" target="_blank" rel="noreferrer">Maximilian Brandl</a> as the bachelor project in Interactive Media Design at the Darmstadt University of Applied Sciences.
          <br/><br/>
          It is based on their research about <a href="http://files.brandlmax.com/Entangled-Interface_Brandl_Kaltofen.pdf" target="_blank" rel="noreferrer">Entangled Interfaces</a>.
          <br/><br/>
          Supervised by Prof. Andrea Krajewski, Garrit Schaap, Andreas Schindler and Prof. Tsunemitsu Tanaka,
          `}
      />

      <Footer />
    </div>
  )
}
