import arcpy
def Increase(path,fieldname,s,i):
    if(i==0):    i=1
    arcpy.CalculateField_management(path,fieldname,'autoIncrease('+str(s)+','+str(i)+')','PYTHON_9.3', 'isFirst=True\nstart=0\ndef autoIncrease(s,increase):\n    global start\n    global isFirst\n    if(isFirst):\n        start=s\n        isFirst = False\n        return start\n    start += increase\n    return start')

featureclass = arcpy.GetParameterAsText(0)
field = arcpy.GetParameter(1).value
start = arcpy.GetParameter(2)
increase = arcpy.GetParameter(3)

Increase(featureclass,field,start,increase)