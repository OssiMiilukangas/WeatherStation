#include "mbed.h"
#include "L3G4200D.h"
#include "math.h"

Serial pc(USBTX, USBRX);
AnalogIn input(A0);

float sensorValue;
float y;

int main()
{
  while (true)
  {
    //Tallennetaan anturin antama arvo muuttujaan ja pyoristetaan alas,
    //silla AD-tulosta ei saa pyoristaa ylospain.
    sensorValue = floor(input * 1000);
    pc.printf("Sensoriarvo = %1.f ", sensorValue);

    y = (1.47178118 * pow(10, -12) * pow(sensorValue, 5))
      - (3.40845175 * pow(10, -9) * pow(sensorValue, 4))
      + (3.11760990 * pow(10, -6) * pow(sensorValue, 3))
      - (1.41542918 * pow(10, -3) * pow(sensorValue, 2))
      + (4.23115934 * pow(10, -1) * pow(sensorValue, 1))
      - (6.04378793 * pow(10, 1));

    pc.printf("Temperature = %2.f \n", y);

  }
}
