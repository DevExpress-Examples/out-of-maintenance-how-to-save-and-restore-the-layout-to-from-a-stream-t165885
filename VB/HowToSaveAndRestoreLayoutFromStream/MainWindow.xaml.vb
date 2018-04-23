Imports System.Windows

Namespace HowToSaveAndRestoreLayoutFromStream
    Partial Public Class MainWindow
        Inherits Window

        ' Create a MemoryStream instance.
        Private LayoutStream As System.IO.Stream = New System.IO.MemoryStream()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub buttonSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Save the layout to a stream.
            pivotGridControl1.SaveLayoutToStream(LayoutStream)
        End Sub

        Private Sub buttonLoad_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            LayoutStream.Position = 0
            ' Load the layout from the stream.
            pivotGridControl1.RestoreLayoutFromStream(LayoutStream)
        End Sub
    End Class
End Namespace
