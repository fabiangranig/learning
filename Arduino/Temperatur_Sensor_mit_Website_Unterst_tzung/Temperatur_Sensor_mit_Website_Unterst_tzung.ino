//Adding the libraries und options for the DHT Sensor
#include <DHT.h>
#include <DHT_U.h>
#include <dht11.h>
#define DHTPIN 8
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE);

//Adding the library of an another temp sensor
#include <TMP36.h>

//Library and settings for an second Serial Port
#include <SoftwareSerial.h>
#define RX 2
#define TX 3
SoftwareSerial esp8266(RX,TX); 

//Add variables for the wifi
//WLAN SSID
String AP = "HUAWEI-B535-A279";
//WLAN Password
String PASS = "B9JJ7FT48Q5";

//Varibles for the destination websites
String API = "0UNTF4U8TCJK3LZ4";
String HOST = "api.thingspeak.com";
String PORT = "80";

//Variables for an php site
String HOST2 = "fabiangranig.at";

//different public variables
int runs = 1;
int countTimeCommand; 
boolean found = false; 
int valSensor = 1;
int problem_try = 1;
bool problem1 = false;
bool problem11 = false;
bool problem2 = false;
bool problem22 = false;

void setup() {
  //Begin the normal and the software serial
  Serial.begin(9600);
  esp8266.begin(115200);

  //Setting up instructions
  Serial.println("Setting up WLAN Module:");

  //Begin the temp sensor
  dht.begin();

  //Starting commands for the WLAN Module
  sendCommand("AT",5,"OK");
  sendCommand("AT+CWMODE=1",5,"OK");
  sendCommand("AT+CWJAP=\""+ AP +"\",\""+ PASS +"\"",20,"OK");

  //empty Line
  Serial.println("");
}

void loop() {
 //Tell the user which runthrough it is
 Serial.print("Run: ");
 Serial.println(runs);
 
 //Get the data which is send to the website
 String getData = "GET /update?api_key="+ API +"&field1="+getTemperatureValue();

 //Send it to the thingspeak server
 problem_try = 1;
 while(problem1 == false)
 {
    problem11 = false;
    Serial.print(problem_try);
    Serial.println(".Try: Thinspeak Website");
    sendCommand("AT+CIPMUX=1",5,"OK");
    sendCommand("AT+CIPSTART=0,\"TCP\",\""+ HOST +"\","+ PORT,15,"OK");
    sendCommand("AT+CIPSEND=0," + String(getData.length()+4),10,">");
    esp8266.println(getData);
    delay(1500);
    sendCommand("AT+CIPCLOSE=0",5,"OK");

    if(problem11 == false)
    {
      problem1 = true;
    }

    problem_try++;

    if(problem_try > 20)
    {
      problem1 = true;  
    }
 }
 

 //empty Line
 Serial.println("");

 //empty Line
 Serial.println("");

 //Tell the user the wait time
 Serial.print("Wait time: ");
 Serial.print("8");
 Serial.print(" ");
 Serial.println("minutes");
 
 //Delay it
 delay(480000);

 //empty Line
 Serial.println("");

 //Reset all values
 problem1 = false;
 problem2 = false;
 problem11 = false;
 problem22 = false;

 //Higher the runs count by one
 runs++;
}

//Getting the searched values
String getTemperatureValue(){
  float t = dht.readTemperature();
  return String(t); 
}

//Funktion to easily send commands
void sendCommand(String command, int maxTime, char readReplay[]) {
  //Print an instruction
  Serial.print("Command => ");
  Serial.print(command);
  Serial.print(" ");

  //Checking if we got an an answer to our command
  while(countTimeCommand < (maxTime*1))
  {
    esp8266.println(command);
    if(esp8266.find(readReplay))
    {
      found = true;
      break;
    }
  
    countTimeCommand++;
  }

  //If the command was found print Sucess!
  if(found == true)
  {
    Serial.println("Sucess!");
    countTimeCommand = 0;
  }

  //If the command was not found print Failed!
  if(found == false)
  {
    Serial.println("Failed!");
    countTimeCommand = 0;
    problem11 = true;
    problem22 = true;
  }

  found = false;
}
