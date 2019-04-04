import os
import sys
import arcpy

def Append(toFolder, inFolders):
    for toFolderFile in os.listdir(toFolder):
        if(toFolderFile.endswith('.shp')):
            toFolderFileFull = toFolder+'\\'+toFolderFile
            arcpy.AddMessage(toFolderFileFull)
            arr = []
            for inFolder in inFolders:
                for inFolderFile in os.listdir(inFolder.value):
                    if(inFolderFile.endswith(toFolderFile)):
                        inFolderFileFull = inFolder.value+'\\'+inFolderFile
                        arr.append(inFolderFileFull)
            if(len(arr)):
                arcpy.AddMessage(arr)
                arcpy.Append_management(arr,toFolderFileFull,"No_TEST","","")
to = arcpy.GetParameterAsText(1)
ins = arcpy.GetParameter(0)

Append(to, ins)