import React from "react"
import "../components/image.css"

export default function Image({ name, type, alt }) {
  const img = require("../images/" + name + "." + type)
  if (type !== "svg") {
    const img2x = require("../images/" + name + "@2x." + type)
    return <img src={img} srcSet={img2x + " 2x"} alt={alt}></img>
  } else {
    return <img src={img} alt={alt}></img>
  }
}
