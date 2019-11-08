import MySQLdb
import serial

connected = False
port = "/dev/ttyACM0"
baud = 9600

serialPort = serial.Serial(port, baud, timeout = 1)

db = MySQLdb.connect(host="mysli.oamk.fi", user="t8mios00",
                     passwd="FPeRsNjALZXT22Xa", db="opisk_t8mios00")

cur = db.cursor()

#sql = ("INSERT INTO weather VALUES(4,12,20,50)")

try:
    cur.execute(sql)
    db.commit()
    print("jes")
except:
    db.rollback()
    print("es")
    
db.close()
