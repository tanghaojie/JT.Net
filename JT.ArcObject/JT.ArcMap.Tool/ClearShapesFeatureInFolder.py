import os
import sys
import arcpy
folder = arcpy.GetParameterAsText(0)
def Clear(folder):
    for l in os.listdir(folder):
        if(l.endswith('.shp')):
            fullname = folder + '\\' + l
            arcpy.AddMessage(fullname)
            arcpy.DeleteFeatures_management(folder+'\\'+l)
Clear(folder)