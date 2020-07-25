import processing.core.*; 
import processing.data.*; 
import processing.event.*; 
import processing.opengl.*; 

import java.util.HashMap; 
import java.util.ArrayList; 
import java.io.File; 
import java.io.BufferedReader; 
import java.io.PrintWriter; 
import java.io.InputStream; 
import java.io.OutputStream; 
import java.io.IOException; 

public class CardTrainingDataGenerator extends PApplet {

PImage img;
JSONObject json;
int y = 101;

public void setup(){
  // Debug
  // size(414, 896);
  // Original
     
  stroke(255);
  img = loadImage("./src/CardArea.png");    
}

public void draw(){
  background(0);
  image(img, 0, 0);

  y = y - 1;
  if (y < 0) { 
    y = height; 
  } 

  line(0, y, width, y);  
}

public void keyPressed() {
  if (key == 's') {
    println("Save");

    // Create a new JSON bubble object
    JSONObject newImage = new JSONObject();

    JSONObject newCardInImage = new JSONObject();
    newCardInImage.setInt("x", 100);
    newCardInImage.setInt("y", 200);
    newCardInImage.setInt("w", 300);
    newCardInImage.setInt("h", 400);

    newImage.append(newCardInImage);

    json.append(newImage);

    saveJSONObject(json,"data/data.json");
  }

  if (key == 'g') {
    println("Generate");
  }
}
  public void settings() {  size(828, 1792); }
  static public void main(String[] passedArgs) {
    String[] appletArgs = new String[] { "CardTrainingDataGenerator" };
    if (passedArgs != null) {
      PApplet.main(concat(appletArgs, passedArgs));
    } else {
      PApplet.main(appletArgs);
    }
  }
}
