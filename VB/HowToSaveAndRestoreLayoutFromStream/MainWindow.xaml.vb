Imports System.IO
Imports System.Windows
Imports DevExpress.Xpf.PivotGrid

Namespace HowToSaveAndRestoreLayoutFromStream
    Partial Public Class MainWindow
        Inherits Window
        ' Create a MemoryStream instance.
        Private LayoutStream As System.IO.Stream = New System.IO.MemoryStream()
        Public Sub New()
            InitializeComponent()
            Dim group As PivotGridGroup = pivotGridControlNew.Groups.Add(fieldYear, fieldMonth)
        End Sub
        Private Sub buttonSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Save the layout to a stream.
            pivotGridControlOld.SaveLayoutToStream(LayoutStream)
        End Sub
        Private Sub buttonLoad_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            LayoutStream.Position = 0
            LayoutStream.Seek(0, SeekOrigin.Begin)
            ' Load the layout from the stream.
            pivotGridControlNew.RestoreLayoutFromStream(LayoutStream)
        End Sub
        Private Sub pivotGridControlNew_LayoutUpgrade(ByVal sender As Object, ByVal e As PivotLayoutUpgradeEventArgs)
            If e.PreviousVersion = "1.0" Then
                Dim newField = New PivotGridField() With {
                    .DataBinding = New DataSourceColumnBinding("Quantity"),
                    .Caption = "Quantity",
                    .Name = "fieldQuantity",
                    .Area = FieldArea.DataArea
                }
                pivotGridControlNew.Fields.Add(newField)
            End If
        End Sub
    End Class
End Namespace
