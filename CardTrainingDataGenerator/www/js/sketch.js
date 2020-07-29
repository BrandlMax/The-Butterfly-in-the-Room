//  /\_/\
// ( o.o )
//  > ^ <

// CONFIG
let canvasHeight = 1624;
let canvasWidth = 750;
const xhr = new XMLHttpRequest();
const serverPostUrl = "http://localhost:3000/imageData";
const isdevMode = false;
let checkFrameCount = 0;
let darkMode = false;

let currentAnnotations = [];
let Trainingsdata = 0;

const Cardnames = [
  "Ads",
  "Aluminium",
  "Bamboo",
  "Character",
  "Cloud",
  "Game",
  "Homeplaced",
  "Inclusive",
  "Katze",
  "onDevice",
  "Plastic",
  "Smarthome",
  "Social",
  "Speech",
  "Touch",
  "VC",
  "Wearable",
];

// LoadImages
const imagePath = `../img/${isDarkMode(darkMode)}`;

let bg;
let AdsImage;
let AluminiumImage;
let BambooImage;
let CharacterImage;
let CloudImage;
let GameImage;
let HomeplacedImage;
let InclusiveImage;
let KatzeImage;
let onDeviceImage;
let PlasticImage;
let SmarthomeImage;
let SocialImage;
let SpeechImage;
let TouchImage;
let VCImage;
let WearableImage;

function preload() {
  bg = loadImage(`${imagePath}/bg.png`);
  AdsImage = loadImage(`${imagePath}/Card_Ads.png`);
  AluminiumImage = loadImage(`${imagePath}/Card_Aluminium.png`);
  BambooImage = loadImage(`${imagePath}/Card_Bamboo.png`);
  CharacterImage = loadImage(`${imagePath}/Card_Character.png`);
  CloudImage = loadImage(`${imagePath}/Card_Cloud.png`);
  GameImage = loadImage(`${imagePath}/Card_Game.png`);
  HomeplacedImage = loadImage(`${imagePath}/Card_Homeplaced.png`);
  InclusiveImage = loadImage(`${imagePath}/Card_Inclusive.png`);
  KatzeImage = loadImage(`${imagePath}/Card_Katze.png`);
  onDeviceImage = loadImage(`${imagePath}/Card_onDevice.png`);
  PlasticImage = loadImage(`${imagePath}/Card_Plastic.png`);
  SmarthomeImage = loadImage(`${imagePath}/Card_Smarthome.png`);
  SocialImage = loadImage(`${imagePath}/Card_Social.png`);
  SpeechImage = loadImage(`${imagePath}/Card_Speech.png`);
  TouchImage = loadImage(`${imagePath}/Card_Touch.png`);
  VCImage = loadImage(`${imagePath}/Card_VC.png`);
  WearableImage = loadImage(`${imagePath}/Card_Wearable.png`);
}

// Create Card Objects
let allCards = [];

let Ads;
let Aluminiums;
let Bamboo;
let Characters;
let Cloud;
let Game;
let Homeplaced;
let Inclusive;
let Katze;
let onDevice;
let Plastic;
let Smarthome;
let Social;
let Speech;
let Touch;
let VC;
let Wearable;

class Card {
  constructor(image, label) {
    this.image = image;
    this.label = label;
    this.coordinates = {
      x: null,
      y: null,
      width: this.image.width,
      height: this.image.height,
    };
    this.amount = 0;
  }
  display() {
    image(this.image, this.coordinates.x, this.coordinates.y);
  }
}

// Render
function setup() {
  createCanvas(canvasWidth, canvasHeight);
  frameRate(25);
  // noLoop();

  Ads = new Card(AdsImage, Cardnames[0]);
  Aluminium = new Card(AluminiumImage, Cardnames[1]);
  Bamboo = new Card(BambooImage, Cardnames[2]);
  Character = new Card(CharacterImage, Cardnames[3]);
  Cloud = new Card(CloudImage, Cardnames[4]);
  Game = new Card(GameImage, Cardnames[5]);
  Homeplaced = new Card(HomeplacedImage, Cardnames[6]);
  Inclusive = new Card(InclusiveImage, Cardnames[7]);
  Katze = new Card(KatzeImage, Cardnames[8]);
  onDevice = new Card(onDeviceImage, Cardnames[9]);
  Plastic = new Card(PlasticImage, Cardnames[10]);
  Smarthome = new Card(SmarthomeImage, Cardnames[11]);
  Social = new Card(SocialImage, Cardnames[12]);
  Speech = new Card(SpeechImage, Cardnames[13]);
  Touch = new Card(TouchImage, Cardnames[14]);
  VC = new Card(VCImage, Cardnames[15]);
  Wearable = new Card(WearableImage, Cardnames[16]);

  allCards = [
    Ads,
    Aluminium,
    Bamboo,
    Character,
    Cloud,
    Game,
    Homeplaced,
    Inclusive,
    Katze,
    onDevice,
    Plastic,
    Smarthome,
    Social,
    Speech,
    Touch,
    VC,
    Wearable,
  ];
}

function draw() {
  image(bg, 0, 0);

  placeCards();

  devMode(isdevMode);
}

// Pull the trigger
function mouseClicked() {
  saveFrames("cards", "png", 1, 1, (data) => {
    print(data);
    data.forEach((singleFrame) => {
      sendToServer({
        image: singleFrame,
        checkFrameCount,
        annotations: currentAnnotations,
      });
    });
    Trainingsdata = Trainingsdata + 1;
    console.log(Trainingsdata);
  });
}

// Helpers
function sendToServer(data) {
  xhr.open("POST", serverPostUrl);
  xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
  xhr.send(JSON.stringify(data));
}

function isDarkMode(darkMode) {
  if (darkMode) {
    return "darkmode";
  } else {
    return "lightmode";
  }
}

function devMode(isdevMode) {
  if (isdevMode) {
    checkFrameCount = checkFrameCount + 1;
    textSize(32);
    text(checkFrameCount, 10, 30);
    fill(247, 0, 197);
  }
}

function placeCards() {
  const alreadyPlaces = [];
  currentAnnotations = [];
  allCards.forEach((singleCard) => {
    createRandomCoords(singleCard);

    while (checkCollision(singleCard, alreadyPlaces)) {
      createRandomCoords(singleCard);
    }

    alreadyPlaces.push(singleCard);

    singleCard.display();

    // Push to Anotation
    currentAnnotations.push({
      label: singleCard.label,
      coordinates: {
        x: singleCard.coordinates.x,
        y: singleCard.coordinates.y,
        width: singleCard.coordinates.width,
        height: singleCard.coordinates.height,
      },
    });
  });
}

function createRandomCoords(singleCard) {
  singleCard.coordinates.x = Math.round(
    random(0, canvasWidth - singleCard.coordinates.width)
  );
  singleCard.coordinates.y = Math.round(
    random(0, canvasHeight - singleCard.coordinates.height)
  );
}

function checkCollision(singleCard, alreadyPlaces) {
  let isCollision = alreadyPlaces.some((otherCard) => {
    return collideRectRect(
      otherCard.coordinates.x,
      otherCard.coordinates.y,
      otherCard.coordinates.width,
      otherCard.coordinates.height,
      singleCard.coordinates.x,
      singleCard.coordinates.y,
      singleCard.coordinates.width,
      singleCard.coordinates.height
    );
  });

  return isCollision;
}
