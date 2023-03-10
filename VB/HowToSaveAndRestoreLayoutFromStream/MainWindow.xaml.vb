Imports DevExpress.Xpf.PivotGrid
Imports System.IO
Imports System.Windows

Namespace HowToSaveAndRestoreLayoutFromStream

    Public Partial Class MainWindow
        Inherits Window

        ' Create a MemoryStream instance.
        Private LayoutStream As Stream = New MemoryStream()

        Public Sub New()
            Me.InitializeComponent()
            Dim group As PivotGridGroup = Me.pivotGridControlNew.Groups.Add(Me.fieldYear, Me.fieldMonth)
        End Sub

        Private Sub buttonSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Save the layout to a stream.
            Me.pivotGridControlOld.SaveLayoutToStream(LayoutStream)
        End Sub

        Private Sub buttonLoad_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            LayoutStream.Position = 0
            LayoutStream.Seek(0, SeekOrigin.Begin)
            ' Load the layout from the stream.
            Me.pivotGridControlNew.RestoreLayoutFromStream(LayoutStream)
        End Sub

        Private Sub pivotGridControlNew_LayoutUpgrade(ByVal sender As Object, ByVal e As PivotLayoutUpgradeEventArgs)
            If Equals(e.PreviousVersion, "1.0") Then
                Dim newField = New PivotGridField() With {.DataBinding = New DataSourceColumnBinding("Quantity"), .Caption = "Quantity", .Name = "fieldQuantity", .Area = FieldArea.DataArea}
                Me.pivotGridControlNew.Fields.Add(newField)
            End If
        End Sub
    End Class
End Namespace
