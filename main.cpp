#include "mbed.h"
#include "L3G4200D.h"

Serial pc(USBTX, USBRX);
AnalogIn input(A0);
float sensorValue;
int main()
{
  while (true)
  {
    //Tallennetaan anturin antama arvo muuttujaan ja pyoristetaan alas,
    //silla AD-tulosta ei saa pyoristaa ylospain.
    sensorValue = floor(input * 1000);
    pc.printf("Sensor = %1.f \n", sensorValue);
  }
}
