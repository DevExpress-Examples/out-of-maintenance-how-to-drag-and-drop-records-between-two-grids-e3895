using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraVerticalGrid;

namespace DXSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            InitializeData();
            InitializeDragDrop();
        }

        void InitializeDragDrop() {
            this.vGridControl1.OptionsBehavior.Editable = false;
            this.vGridControl2.OptionsBehavior.Editable = false;

            this.vGridControl1.MouseDown += vGridControl_MouseDown;
            this.vGridControl1.MouseMove += vGridControl_MouseMove;
            this.vGridControl1.DragOver += vGridControl_DragOver;
            this.vGridControl1.DragDrop += vGridControl_DragDrop;

            this.vGridControl2.MouseDown += vGridControl_MouseDown;
            this.vGridControl2.MouseMove += vGridControl_MouseMove;
            this.vGridControl2.DragOver += vGridControl_DragOver;
            this.vGridControl2.DragDrop += vGridControl_DragDrop;
        }
        void InitializeData() {
            List<DataItem> list1 = new List<DataItem>();
            list1.Add(new DataItem() { Id = 0, Name = "a" });
            list1.Add(new DataItem() { Id = 1, Name = "b" });
            list1.Add(new DataItem() { Id = 4, Name = "e" });
            list1.Add(new DataItem() { Id = 5, Name = "f" });
            list1.Add(new DataItem() { Id = 6, Name = "g" });
            list1.Add(new DataItem() { Id = 7, Name = "h" });
            list1.Add(new DataItem() { Id = 8, Name = "i" });
            list1.Add(new DataItem() { Id = 9, Name = "j" });
            this.vGridControl1.DataSource = list1;

            List<DataItem> list2 = new List<DataItem>();
            list2.Add(new DataItem() { Id = 2, Name = "c" });
            list2.Add(new DataItem() { Id = 3, Name = "d" });
            this.vGridControl2.DataSource = list2;
        }

        void vGridControl_MouseMove(object sender, MouseEventArgs e) {
            ProcessMouseMove(sender as VGridControl, e);
        }
        void vGridControl_MouseDown(object sender, MouseEventArgs e) {
            ProcessMouseDown(sender as VGridControl, e);
        }
        void vGridControl_DragDrop(object sender, DragEventArgs e) {
            ProcessDragDrop(sender as VGridControl, e);
        }
        void vGridControl_DragOver(object sender, DragEventArgs e) {
            ProcessDragOver(sender as VGridControl, e);
        }

        VGridHitInfo captureHitInfo = null;
        void ProcessMouseMove(VGridControl vGrid, MouseEventArgs e) {
            if (vGrid == null || captureHitInfo == null)
                return;
            if (e.Button != MouseButtons.Left)
                return;
            System.Diagnostics.Debug.WriteLine(e.Location);
            Rectangle dragRect = new Rectangle(new Point(
                captureHitInfo.PtMouse.X - SystemInformation.DragSize.Width / 2,
                captureHitInfo.PtMouse.Y - SystemInformation.DragSize.Height / 2), SystemInformation.DragSize);
            if (!dragRect.Contains(new Point(e.X, e.Y))) {
                if (captureHitInfo.HitInfoType == HitInfoTypeEnum.ValueCell) {
                    vGrid.DoDragDrop(
                        new DragInfo() {
                            Grid = vGrid,
                            Data = vGrid.GetRecordObject(captureHitInfo.RecordIndex)
                        },
                        DragDropEffects.Copy);
                }
            }
        }
        void ProcessMouseDown(VGridControl vGrid, MouseEventArgs e) {
            if (vGrid == null)
                return;
            captureHitInfo = vGrid.CalcHitInfo(new Point(e.X, e.Y));
        }
        void ProcessDragDrop(VGridControl target, DragEventArgs e) {
            DragInfo dragInfo = (DragInfo)e.Data.GetData(typeof(DragInfo));
            VGridControl source = dragInfo.Grid;
            DataItem item = (DataItem)dragInfo.Data;
            if (item == null || source == null || target == null)
                return;
            VGridHitInfo dropHitInfo = target.CalcHitInfo(target.PointToClient(new Point(e.X, e.Y)));
            int targetRecordIndex = GetRecordIndex(dropHitInfo);
            RemoveRecord(source, item);
            AddRecord(target, item, targetRecordIndex);
            source.RefreshDataSource();
            target.RefreshDataSource();
        }

        void AddRecord(VGridControl target, DataItem item, int targetRecordIndex) {
            ((List<DataItem>)target.DataSource).Insert(targetRecordIndex == -1 ? target.RecordCount : targetRecordIndex, item);
        }
        void RemoveRecord(VGridControl source, DataItem item) {
            ((List<DataItem>)source.DataSource).Remove(item);
        }
        void ProcessDragOver(VGridControl vGrid, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }
        int GetRecordIndex(VGridHitInfo dropHitInfo) {
            if (dropHitInfo.HitInfoType == HitInfoTypeEnum.ValueCell)
                return dropHitInfo.RecordIndex;
            return -1;
        }

        class DragInfo {
            public VGridControl Grid { get; set; }
            public object Data { get; set; }
        }
    }

    public class DataItem {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
