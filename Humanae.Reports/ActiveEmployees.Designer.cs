//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Humanae.Reports {
    
    public partial class ActiveEmployees : DevExpress.XtraReports.UI.XtraReport {
        private void InitializeComponent() {
            DevExpress.XtraReports.ReportInitializer reportInitializer = new DevExpress.XtraReports.ReportInitializer(this, "Humanae.Reports.ActiveEmployees.vsrepx");

            // Controls
            this.TopMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.TopMarginBand>("TopMargin");
            this.BottomMargin = reportInitializer.GetControl<DevExpress.XtraReports.UI.BottomMarginBand>("BottomMargin");
            this.Detail = reportInitializer.GetControl<DevExpress.XtraReports.UI.DetailBand>("Detail");
            this.PageHeader = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageHeaderBand>("PageHeader");
            this.PageFooter = reportInitializer.GetControl<DevExpress.XtraReports.UI.PageFooterBand>("PageFooter");
            this.GroupHeader1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.GroupHeaderBand>("GroupHeader1");
            this.table2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTable>("table2");
            this.tableRow2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("tableRow2");
            this.tableCell8 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell8");
            this.tableCell9 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell9");
            this.tableCell10 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell10");
            this.tableCell11 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell11");
            this.tableCell12 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell12");
            this.tableCell13 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell13");
            this.tableCell14 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell14");
            this.barCode1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRBarCode>("barCode1");
            this.label3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("label3");
            this.label2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("label2");
            this.label1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("label1");
            this.pictureBox1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPictureBox>("pictureBox1");
            this.pageInfo1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRPageInfo>("pageInfo1");
            this.table1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTable>("table1");
            this.tableRow1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableRow>("tableRow1");
            this.tableCell1 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell1");
            this.tableCell2 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell2");
            this.tableCell3 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell3");
            this.tableCell4 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell4");
            this.tableCell5 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell5");
            this.tableCell6 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell6");
            this.tableCell7 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRTableCell>("tableCell7");
            this.label4 = reportInitializer.GetControl<DevExpress.XtraReports.UI.XRLabel>("label4");

            // Data Sources
            this.objectDataSource1 = reportInitializer.GetDataSource<DevExpress.DataAccess.ObjectBinding.ObjectDataSource>("objectDataSource1");
            this.objectDataSource1.DataSource = typeof(Humanae.Dto.EmployeeDto);
        }
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable table2;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell8;
        private DevExpress.XtraReports.UI.XRTableCell tableCell9;
        private DevExpress.XtraReports.UI.XRTableCell tableCell10;
        private DevExpress.XtraReports.UI.XRTableCell tableCell11;
        private DevExpress.XtraReports.UI.XRTableCell tableCell12;
        private DevExpress.XtraReports.UI.XRTableCell tableCell13;
        private DevExpress.XtraReports.UI.XRTableCell tableCell14;
        private DevExpress.XtraReports.UI.XRBarCode barCode1;
        private DevExpress.XtraReports.UI.XRLabel label3;
        private DevExpress.XtraReports.UI.XRLabel label2;
        private DevExpress.XtraReports.UI.XRLabel label1;
        private DevExpress.XtraReports.UI.XRPictureBox pictureBox1;
        private DevExpress.XtraReports.UI.XRPageInfo pageInfo1;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.XRTableCell tableCell5;
        private DevExpress.XtraReports.UI.XRTableCell tableCell6;
        private DevExpress.XtraReports.UI.XRTableCell tableCell7;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRLabel label4;
    }
}
