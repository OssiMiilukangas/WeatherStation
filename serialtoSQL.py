import MySQLdb
import serial
import time
import datetime

db = MySQLdb.connect(host="mysli.oamk.fi", user="t8mios00",
                     passwd="FPeRsNjALZXT22Xa", db="opisk_t8mios00")

cur = db.cursor()

port = "/dev/ttyACM0"
baud = 9600
sample = 20

serialPort = serial.Serial(port, baud, timeout = 1)

#time.sleep(1)

valueSum = 0.0
count = 0

while True:
    ser = str(serialPort.readline())
    realValue = ser.replace("b", "").replace("'", "").replace(r"\r\n", "").replace("0.0.", "0.")
    valueSum += float(realValue)
    #time.sleep(.1)
    count += 1
    
    if count == sample:
        cur.execute("SELECT MAX(idweather) FROM weather")
        currentID = str(cur.fetchall())
        currentID = int(currentID.replace("(", "").replace(",", "").replace(")", ""))
        
        valueAvg = valueSum / sample
        print("%.6f"%valueAvg)
        
        time = datetime.datetime.now().time()
        date = datetime.datetime.now().date()
        
        if valueAvg < 1:
            sql = ("INSERT INTO weather VALUES(%s, '%s', '%s', %.4f, %s)" % \
                   (currentID + 1, date, time, valueAvg, 20))
            try:
                cur.execute(sql)
                db.commit()
                print("jes")
            except:
                db.rollback()
                print("es")
            
        count = 0
        valueSum = 0.0

serialPort.close()
db.close()

