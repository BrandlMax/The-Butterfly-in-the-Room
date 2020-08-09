import React from "react"
import Image from "../components/image"
import "../components/footer.css"

export default function Footer() {
  return (
    <footer>
      <div class="footerWrapper">
        <Image name="imd" type="svg" alt="We love Interactive Media Design" />
        <nav>
          <a href="https://aiiot.space/privacy" target="_blank">
            Privacy
          </a>
          <a href="https://aiiot.space/impressum" target="_blank">
            Impressum
          </a>
        </nav>
      </div>
    </footer>
  )
}
