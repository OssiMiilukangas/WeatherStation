#include "mbed.h"
#include "DHT.h"
#include "math.h"

Serial pc(USBTX, USBRX);
DigitalOut myled(LED1);
AnalogIn input(A0);
DHT sensor(PA_8, DHT11); // Use the SEN11301P sensor

float sensorValue;
float y;

int main() {
    //int err;
    printf("\r\nDHT Test program");
    printf("\r\n******************\r\n");
    wait(1); // wait 1 second for device stable status
    while (1) {
        myled = 1;
        sensor.readData();
        //if (err == 0) {
            pc.printf("%4.2f ",sensor.ReadTemperature(CELCIUS));
            //printf("Temperature is %4.2f F \r\n",sensor.ReadTemperature(FARENHEIT));
            //printf("Temperature is %4.2f K \r\n",sensor.ReadTemperature(KELVIN));
            pc.printf("%4.2f ",sensor.ReadHumidity());
            //printf("Dew point is %4.2f  \r\n",sensor.CalcdewPoint(sensor.ReadTemperature(CELCIUS), sensor.ReadHumidity()));
            //printf("Dew point (fast) is %4.2f  \r\n",sensor.CalcdewPointFast(sensor.ReadTemperature(CELCIUS), sensor.ReadHumidity()));
        //} else
          //  printf("\r\nErr %i \n",err);
          sensorValue = floor(input * 1000);
          //pc.printf("Sensoriarvo = %1.f ", sensorValue);

          y = (1.47178118 * pow(10, -12) * pow(sensorValue, 5))
            - (3.40845175 * pow(10, -9) * pow(sensorValue, 4))
            + (3.11760990 * pow(10, -6) * pow(sensorValue, 3))
            - (1.41542918 * pow(10, -3) * pow(sensorValue, 2))
            + (4.23115934 * pow(10, -1) * pow(sensorValue, 1))
            - (6.04378793 * pow(10, 1));

          pc.printf("%2.f\r\n", y);

        myled = 0;
        wait(1);
    }
}
