PImage img;
JSONObject json;
int y = 101;

void setup(){
  // Debug
  // size(414, 896);
  // Original
  size(828, 1792);   
  stroke(255);
  img = loadImage("./src/CardArea.png");    
}

void draw(){
  background(0);
  image(img, 0, 0);

  y = y - 1;
  if (y < 0) { 
    y = height; 
  } 

  line(0, y, width, y);  
}

void keyPressed() {
  if (key == 's') {
    println("Save");

    // Create a new JSON bubble object
    // JSONArray allImages = new JSONArray();
    // JSONArray allCardsInImage = new JSONArray();

    // JSONObject newImage = new JSONObject();

    // JSONObject newCardInImage = new JSONObject();
    // newCardInImage.setInt("x", 100);
    // newCardInImage.setInt("y", 200);
    // newCardInImage.setInt("w", 300);
    // newCardInImage.setInt("h", 400);

    // allImages.append(newImage);
    // json.setJSONArray("Images", allImages);

    // json.append(newImage);

    // saveJSONObject(json,"data/data.json");
  }

  if (key == 'g') {
    println("Generate");
  }
}
