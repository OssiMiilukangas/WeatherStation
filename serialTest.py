import serial
import time

connected = False
port = "/dev/ttyACM0"
baud = 9600

serialPort = serial.Serial(port, baud, timeout = 0)

while True:
    print(serialPort.readline())
    time.sleep(.500)