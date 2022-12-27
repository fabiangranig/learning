Attribute VB_Name = "Modul1"
Sub Image_Adder()
    Dim pre As presentation
    Dim image As Shape
    Dim i As Integer
    Dim u As Integer
    Dim used As Integer
    
    '#Reference to file
    'Set pre = ActivePresentation
    Set pre = Presentations.Add
    'Set pre = Presentations.Open("<directory>", msoFalse)
    
    used = 1
    For i = 1 To 4
        Set sld = ActivePresentation.Slides.Add(i, ppLayoutBlank)
        For u = 1 To 2
            Set image = sld.Shapes.AddPicture("<Path>" + CStr(used) + ".png", msoCTrue, msoCTrue, (u - 1) * 200 + 100, (u - 1) * 200 + 100)
            used = used + 1
        Next u
    Next i
    
    Set pre = Nothing
End Sub

Function db(msg As String)
    Debug.Print msg
End Function
