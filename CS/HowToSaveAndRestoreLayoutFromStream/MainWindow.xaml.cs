using DevExpress.Xpf.PivotGrid;
using System.IO;
using System.Windows;

namespace HowToSaveAndRestoreLayoutFromStream {
    public partial class MainWindow : Window {
        // Create a MemoryStream instance.
        System.IO.Stream LayoutStream = new System.IO.MemoryStream();
        public MainWindow() {
            InitializeComponent();
            PivotGridGroup group = pivotGridControlNew.Groups.Add(fieldYear, fieldMonth);         
        }
        private void buttonSave_Click(object sender, RoutedEventArgs e) {
            // Save the layout to a stream.
            pivotGridControlOld.SaveLayoutToStream(LayoutStream);
        }
        private void buttonLoad_Click(object sender, RoutedEventArgs e) {
            LayoutStream.Position = 0;
            LayoutStream.Seek(0, SeekOrigin.Begin);
            // Load the layout from the stream.
            pivotGridControlNew.RestoreLayoutFromStream(LayoutStream);
        }
        private void pivotGridControlNew_LayoutUpgrade(object sender, PivotLayoutUpgradeEventArgs e) {
            if (e.PreviousVersion == "1.0") {
                var newField = new PivotGridField() {
                    DataBinding = new DataSourceColumnBinding("Quantity"),
                    Caption = "Quantity",
                    Name = "fieldQuantity",
                    Area = FieldArea.DataArea
                };
                pivotGridControlNew.Fields.Add(newField);
            };
        }
    }
}
