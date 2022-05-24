Imports System.Windows

Namespace HowToSaveAndRestoreLayoutFromStream

    Public Partial Class MainWindow
        Inherits Window

        ' Create a MemoryStream instance.
        Private LayoutStream As System.IO.Stream = New System.IO.MemoryStream()

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub buttonSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Save the layout to a stream.
            Me.pivotGridControl1.SaveLayoutToStream(LayoutStream)
        End Sub

        Private Sub buttonLoad_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            LayoutStream.Position = 0
            ' Load the layout from the stream.
            Me.pivotGridControl1.RestoreLayoutFromStream(LayoutStream)
        End Sub
    End Class
End Namespace
