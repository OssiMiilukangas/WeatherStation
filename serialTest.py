import serial
import time

port = "/dev/ttyACM0"
baud = 9600
sample = 20

serialPort = serial.Serial(port, baud, timeout = 1)

valueSum = 0.0
count = 0

while True:
    if count == sample:
        valueAvg = valueSum / sample
        #print("%.6f"%valueAvg)
        count = 0
        valueSum = 0.0
    
    ser = str(serialPort.readline())
    realValue = ser.replace("b", "").replace("'", "").replace(r"\r\n", "").replace("0.0.", "0.")
    #valueSum += float(realValue)
    
    print(realValue)
    #time.sleep(.1)
    count += 1

serial.close()