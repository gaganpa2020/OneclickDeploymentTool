
int InputPin = 13;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  analogReference(INTERNAL);
}

void loop() {
  // put your main code here, to run repeatedly:  
  int tempVal = digitalRead(InputPin);   

  if(tempVal == 0)
  {
    Serial.println("deploy");  
    delay(1000);
  }
}
