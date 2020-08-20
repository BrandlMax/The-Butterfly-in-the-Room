const WebSocket = require("ws");
const PORT = 1337;
const server = new WebSocket.Server({ port: PORT });

server.on("connection", function connection(socket) {
  console.log("New Connection");
  socket.on("message", function incoming(data) {
    console.log("New Message: " + data);

    if (data != "") {
      let JSONData = createCardDataObjectString(data);
      console.log(JSONData);
      server.clients.forEach(function each(client) {
        if (client !== socket && client.readyState === WebSocket.OPEN) {
          client.send('{"cards":' + JSONData + "}");
        }
      });
    } else {
      server.clients.forEach(function each(client) {
        if (client !== socket && client.readyState === WebSocket.OPEN) {
          client.send('empty');
        }
      });
    }
  });
});

const createCardDataObjectString = (cardDataString) => {
  let cardObjects = [];

  const cardsStringArray = cardDataString.split(";");
  cardsStringArray.forEach((cardInfo) => {
    cardInfo = cardInfo.replace("(", "");
    cardInfo = cardInfo.replace(")", "");
    cardInfo = cardInfo.replace(" ", "");
    cardInfoArray = cardInfo.split(":");
    cardInfoArray[1] = cardInfoArray[1].split(",");
    let cardObject = {
      name: cardInfoArray[0],
      x: cardInfoArray[1][0],
      y: cardInfoArray[1][1],
      width: cardInfoArray[1][2],
      height: cardInfoArray[1][3],
    };
    cardObjects.push(cardObject);
  });
  return JSON.stringify(cardObjects);
};

console.log("Server started: ws://localhost:" + PORT);
