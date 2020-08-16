import React from "react"
import "../components/Feedback.css"

export default function Feedback({ title, text }) {
  return (
    <section className="feedback">
      <div className="feedbackWrapper">
        <h2>{title}</h2>
        <p dangerouslySetInnerHTML={{ __html: text }}></p>
      </div>
    </section>
  )
}
