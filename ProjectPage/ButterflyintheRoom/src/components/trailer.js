import React from "react"
import "../components/trailer.css"

export default function Footer() {
  return (
    <section className="play" id="play">
      <iframe
        src="https://player.vimeo.com/video/76813693"
        width="640"
        height="360"
        frameBorder="0"
        allow="autoplay; fullscreen"
        allowFullScreen
      ></iframe>
    </section>
  )
}
