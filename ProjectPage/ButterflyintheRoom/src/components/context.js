import React from "react"
import Image from "../components/image"
import "../components/context.css"

export default function Context({ title, text }) {
  return (
    <section className="textMedia context">
      <div className="content">
        <h2>{title}</h2>
        <p dangerouslySetInnerHTML={{ __html: text }}></p>
      </div>
      <div className="media">
        <Image
          name="IMDArtikel_h_da"
          type="png"
          alt="Hochschule Darmstadt Logo"
        />
      </div>
    </section>
  )
}
