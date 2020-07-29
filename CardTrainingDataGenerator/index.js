// Server Config
const express = require("express");
const path = require("path");
const bodyParser = require("body-parser");
const FileSystem = require("fs");
const server = express();
const port = 3000;

const wwwPath = path.join(__dirname, "/www");
const annotationFilePath = path.join(__dirname, "/export/annotations.json");
const imagesFilePath = path.join(__dirname, "/export");

server.use(express.static(wwwPath));
server.use(bodyParser.json({ limit: "50mb" }));

server.listen(port, function () {
  console.log(`listening on http://localhost:${port}`);
});

// Save Images to Server
// Reset
let amountImages = 0;
const startData = [];
FileSystem.writeFileSync(
  annotationFilePath,
  JSON.stringify(startData, null, 4)
);

server.post("/imageData", function (req, res) {
  const fileName = `${req.body.image.filename.replace(
    /[0-9]/g,
    ""
  )}-${amountImages}.${req.body.image.ext}`;
  const annotations = req.body.annotations;
  const imageData = req.body.image.imageData.replace(
    /^data:image\/octet-stream;base64,/,
    ""
  );

  // Save File
  FileSystem.writeFile(
    `${imagesFilePath}/${fileName}`,
    imageData,
    "base64",
    (err) => {}
  );

  amountImages = amountImages + 1;
  console.log(`Image ${fileName} Saved on Server`);

  // Update JSON
  let data = JSON.parse(FileSystem.readFileSync(annotationFilePath));
  data.push({
    image: fileName,
    annotations,
  });
  FileSystem.writeFileSync(annotationFilePath, JSON.stringify(data, null, 4));

  // Some useless Response from Server
  res.send(`Image ${amountImages} Saved on Server`);
});

function updateJSON() {}
