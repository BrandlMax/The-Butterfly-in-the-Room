import React from "react"
import Image from "../components/image"
import "../components/textmedia.css"

export default function TextMedia({ title, text, media, type, alt }) {
  function renderMedia(media, type, alt) {
    if (media != undefined) {
      if (type !== "video" && media !== undefined) {
        return (
          <div>
            <Image name={media} type={type} alt={alt} />
          </div>
        )
      } else if (type !== "video" && media !== undefined) {
        return <div>Video</div>
      }
    }
  }

  return (
    <section className="textMedia">
      <div className="content">
        <h2>{title}</h2>
        <p>{text}</p>
      </div>
      <div className="media">{renderMedia(media, type, alt)}</div>
    </section>
  )
}
