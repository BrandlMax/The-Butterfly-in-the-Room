const WebSocket = require("ws");
const PORT = 1337;
const server = new WebSocket.Server({ port: PORT });

server.on("connection", function connection(socket) {
  console.log("New Conncection");
  socket.on("message", function incoming(data) {
    console.log("New Message: " + data);
    server.clients.forEach(function each(client) {
      if (client !== socket && client.readyState === WebSocket.OPEN) {
        client.send(data);
      }
    });
  });
});

console.log("Server started: ws://localhost:" + PORT);
