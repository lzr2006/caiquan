import os
import sys

s = [0,0,0,0,0,0,0,0,0,0]
local = sys.path[0]
f = open(local + "\\temp\\temp.txt")

i = -1
while 1:
    i = i + 1
    line = f.readline()
    print(line)
    s[i] = line
    if not line:
        break
    pass # do something


f = open(local + "\\MyGameResult.txt","w")
f.write("user_blood")
f.write(":")
f.write(s[0])
f.write("computer1_blood")
f.write(":")
f.write(s[1])
f.write("computer2_blood")
f.write(":")
f.write(s[2])
f.write("user_money")
f.write(":")
f.write(s[3])
f.write("computer1_money")
f.write(":")
f.write(s[4])
f.write("computer2_money")
f.write(":")
f.write(s[5])
f.write("user_count")
f.write(":")
f.write(s[6])
f.write("computer1_count")
f.write(":")
f.write(s[7])
f.write("computer2_blood")
f.write(":")
f.write(s[8])
f.write("\n----------End----------")
f.close()
