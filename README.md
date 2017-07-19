# JTServer
A GPS Server example for JT701 tracking and locking devices.

Following command authorizes three RFID card for lock/unlock 
(P41,1,1,3,0000379706,0000382011,0000379998)

Following command reset all authorized RFID card.
(P41,1,3)

Following command sets server connection information and APN information for SIM1 for TURKCELL
(P06,1,78.175.159.172,2000,internet,,)
in this example
REMOTE PORT:2000
remote ip: 78.175.159.172 (must be accessible from public internet)

SET vip number at index1 command 
(P11,1,1,905373400906)

After successfull P06 command you should be able to receive data from JT701 device.

(P1): GetFirmware
