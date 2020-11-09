import React from "react"
import "../components/trailer.css"

export default function Footer() {
  return (
    <section className="play" id="play">
      <iframe
        title="The Butterfly in the Room - Trailer"
        src="https://player.vimeo.com/video/448994532?dnt=1"
        width="640"
        height="360"
        frameBorder="0"
        allow="autoplay; fullscreen"
        allowFullScreen
      ></iframe>
    </section>
  )
}
