import re

def timeStringtotime(s):
    return int(s[0:2])*60+int(s[3:5])

def filterChar(s):
    return re.sub('[a-z0-9]','',s)

