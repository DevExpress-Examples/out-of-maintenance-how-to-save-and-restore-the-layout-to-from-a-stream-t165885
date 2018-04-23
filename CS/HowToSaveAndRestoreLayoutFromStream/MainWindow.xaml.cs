using System.Windows;

namespace HowToSaveAndRestoreLayoutFromStream {
    public partial class MainWindow : Window {
        // Create a MemoryStream instance.
        System.IO.Stream LayoutStream = new System.IO.MemoryStream();
        public MainWindow() {
            InitializeComponent();
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e) {
            // Save the layout to a stream.
            pivotGridControl1.SaveLayoutToStream(LayoutStream);
        }
        private void buttonLoad_Click(object sender, RoutedEventArgs e) {
            LayoutStream.Position = 0;
            // Load the layout from the stream.
            pivotGridControl1.RestoreLayoutFromStream(LayoutStream);
        }
    }
}