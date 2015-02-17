import thinkgear
import csv
from time import gmtime, strftime, localtime

s = strftime("%Y%m%d%H%M%S", localtime()); 
with open('%s.csv' % s, 'wb') as f:
    PORT = '/dev/tty.RNBT-E8C4-RNI-SPP'
    print 
    for packets in thinkgear.ThinkGearProtocol(PORT).get_packets():
        for p in packets:
            if isinstance(p, thinkgear.ThinkGearRawWaveData):
                continue
            t = strftime("%Y%m%d%H%M%S", localtime())
            print t
            print p
            csv.writer(f).writerow([t])
            csv.writer(f).writerow([p])
