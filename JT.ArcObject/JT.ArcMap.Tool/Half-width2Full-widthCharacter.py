import arcpy
def H2F(path,fname):
    fields = arcpy.ListFields(path)
    name = ''
    for field in fields:
        if(field.name==fname):
            arcpy.AddMessage(field.name)
            arcpy.CalculateField_management(path,field.name,'strB2Q(!'+field.name+'!)','PYTHON_9.3', 'def strB2Q(ustring):\n    rstring = ""\n    for uchar in ustring:\n        inside_code=ord(uchar)\n        if inside_code == 32:              \n            inside_code = 12288\n        elif inside_code >= 32 and inside_code <= 126:\n            inside_code += 65248\n        rstring += unichr(inside_code)\n    return rstring')
path = arcpy.GetParameterAsText(0)
fieldname = arcpy.GetParameterAsText(1)
H2F(path,fieldname)