Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel

Namespace Pogolo.Utilities

    Public Class PogoloSearch
        Private uSearchResults As ArrayList
        Private uIDList As ArrayList

        Public Enum SearchType
            Basic
            Advanced
            AnyField
        End Enum

        'Public Sub StartSearch(ByVal QueryString As String, ByVal startDate As String, ByVal endDate As String, ByVal ModuleId As Integer, ByVal sType As Integer)
        '    uSearchResults = New ArrayList
        '    If QueryString = "" And endDate = "" And startDate = "" Then Exit Sub
        '    Dim DocController As New RETEC_DocumentsController
        '    Dim FileCollection As ArrayList = DocController.GetByModules(ModuleId)
        '    Dim curDoc As RETEC_DocumentsInfo
        '    uIDList = New ArrayList
        '    For Each curDoc In FileCollection
        '        Select Case sType
        '            Case SearchType.AnyField
        '                If hasItemValue(curDoc, QueryString) And Not hasBeenFound(curDoc) Then
        '                    uSearchResults.Add(curDoc)
        '                End If
        '            Case SearchType.Basic, SearchType.Advanced
        '                Dim qs() As String
        '                Dim Fields As ArrayList = fieldPairs(QueryString)
        '                Dim hitcount As Integer = 0
        '                If Fields.Count = 0 And startDate <> "" And endDate <> "" Then  ' Range-only search
        '                    If isInDateRange(curDoc, startDate, endDate) And Not hasBeenFound(curDoc) Then
        '                        uSearchResults.Add(curDoc)
        '                        uIDList.Add(curDoc.itemID)
        '                    End If
        '                ElseIf Fields.Count <> 0 Then
        '                    For Each qs In Fields
        '                        Dim FieldName As String = qs(0).ToString
        '                        Dim FieldValue As String = qs(1).ToString
        '                        If isInDateRange(curDoc, startDate, endDate) And hasItemValue(curDoc, FieldName, FieldValue) And Not hasBeenFound(curDoc) Then
        '                            hitcount = hitcount + 1  ' keep track of hits
        '                        End If
        '                    Next
        '                    If hitcount = Fields.Count Then ' only add search result when ALL query items return true
        '                        uSearchResults.Add(curDoc)
        '                        uIDList.Add(curDoc.itemID)
        '                    End If
        '                End If
        '        End Select
        '    Next
        'End Sub

        'Private Function isInDateRange(ByVal doc As RETEC_DocumentsInfo, ByVal startDateStr As String, ByVal endDateStr As String) As Boolean
        '    If startDateStr = "" Or endDateStr = "" Then Return True
        '    Dim startDate As Date = CType(startDateStr, Date)
        '    Dim endDate As Date = CType(endDateStr, Date)
        '    If doc.DocDate.Date >= startDate.Date And doc.DocDate.Date <= endDate.Date Then
        '        Return True
        '    End If
        '    Return False
        'End Function

        'Private Function hasBeenFound(ByVal doc As RETEC_DocumentsInfo) As Boolean
        '    Dim itemID As Integer
        '    For Each itemID In uIDList
        '        If itemID = doc.itemID Then
        '            Return True
        '        End If
        '    Next
        '    Return False
        'End Function

        'Private Function hasItemValue(ByVal DocToSearch As RETEC_DocumentsInfo, ByVal FieldValue As String) As Boolean
        '    ' Full-text/Google searching
        '    Dim propertyCollection As PropertyDescriptorCollection = TypeDescriptor.GetProperties(DocToSearch)
        '    Dim curProperty As PropertyDescriptor
        '    For Each curProperty In propertyCollection
        '        Dim val As Object = curProperty.GetValue(DocToSearch)
        '        If Not val Is Nothing Then
        '            Dim strVal As String = CType(val, String)
        '            If UCase(strVal).IndexOf(UCase(FieldValue)) > -1 Then
        '                Return True
        '            End If
        '        End If
        '    Next
        '    Return False
        'End Function

        'Private Function hasItemValue(ByVal DocToSearch As RETEC_DocumentsInfo, ByVal FieldName As String, ByVal FieldValue As String) As Boolean
        '    ' Basic and Advanced searching
        '    Dim propertyCollection As PropertyDescriptorCollection = TypeDescriptor.GetProperties(DocToSearch)
        '    Dim curProperty As PropertyDescriptor
        '    For Each curProperty In propertyCollection
        '        If UCase(curProperty.Name) = UCase(FieldName) Then
        '            Exit For
        '        End If
        '    Next
        '    If Not curProperty Is Nothing Then
        '        Dim val As Object = curProperty.GetValue(DocToSearch)
        '        If Not val Is Nothing Then
        '            Dim strVal As String = CType(val, String)
        '            If UCase(strVal).IndexOf(UCase(FieldValue)) > -1 Then
        '                Return True
        '            End If
        '        Else
        '            Return False
        '        End If
        '    End If
        'End Function

        Private Function fieldPairs(ByVal qs As String) As ArrayList
            Dim tmpArr() As String = qs.Split(CType("^", Char))
            Dim val As String
            Dim tmpList As New ArrayList
            For Each val In tmpArr
                If val.Trim <> "" Then tmpList.Add(val.Split(CType("=", Char)))
            Next
            Return tmpList
        End Function

        Public Property SearchResults() As ArrayList
            Get
                Return uSearchResults
            End Get
            Set(ByVal Value As ArrayList)
                uSearchResults = Value
            End Set
        End Property
    End Class

End Namespace
