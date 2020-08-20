import React from "react"
import Image from "../components/image"
import "../components/footer.css"

export default function Footer() {
  return (
    <footer>
      <div class="footerWrapper">
        <Image name="imd" type="svg" alt="We love Interactive Media Design" />
        <nav>
          <a
            href="https://aiiot.space/privacy"
            target="_blank"
            rel="noreferrer"
          >
            Privacy
          </a>
          <a
            href="https://aiiot.space/impressum"
            target="_blank"
            rel="noreferrer"
          >
            Impressum
          </a>
        </nav>
      </div>
    </footer>
  )
}
