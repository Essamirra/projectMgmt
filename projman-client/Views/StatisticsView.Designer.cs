namespace projman_client.Views
{
    partial class StatisticsView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ganttChartView1 = new DlhSoft.ProjectDataControlLibrary.GanttChartView();
            this.ganttChartView1SplitContainer = new System.Windows.Forms.SplitContainer();
            this.ganttChartView1TasksTreeGrid = new DlhSoft.ProjectDataControlLibrary.TasksTreeGrid();
            this.ganttChartView1GanttChartPanel = new DlhSoft.ProjectDataControlLibrary.GanttChartPanel();
            this.ganttChartView1GanttChartHeader = new DlhSoft.ProjectDataControlLibrary.GanttChartHeader();
            this.ganttChartView1GanttChartArea = new DlhSoft.ProjectDataControlLibrary.GanttChartArea();
            this.ganttChartView1GanttChartVerticalScrollBar = new DlhSoft.ProjectDataControlLibrary.GanttChartVerticalScrollBar();
            this.ganttChartView1GanttChartCurrentDateScrollBar = new DlhSoft.ProjectDataControlLibrary.GanttChartCurrentDateScrollBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.ganttChartView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ganttChartView1SplitContainer)).BeginInit();
            this.ganttChartView1SplitContainer.Panel1.SuspendLayout();
            this.ganttChartView1SplitContainer.Panel2.SuspendLayout();
            this.ganttChartView1SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ganttChartView1TasksTreeGrid)).BeginInit();
            this.ganttChartView1GanttChartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ganttChartView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.50165F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.49835F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(503, 303);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Диаграмма Ганта";
            // 
            // ganttChartView1
            // 
            this.ganttChartView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.ganttChartView1, 2);
            this.ganttChartView1.Controls.Add(this.ganttChartView1SplitContainer);
            this.ganttChartView1.DefaultAssignmentsBrush = null;
            this.ganttChartView1.DefaultAssignmentsFont = null;
            this.ganttChartView1.DefaultBarTextsBrush = null;
            this.ganttChartView1.DefaultBarTextsFont = null;
            this.ganttChartView1.DefaultBottomTextsBrush = null;
            this.ganttChartView1.DefaultBottomTextsFont = null;
            this.ganttChartView1.DefaultCriticalRemainingsTextBrush = null;
            this.ganttChartView1.DefaultCriticalRemainingsTextFont = null;
            this.ganttChartView1.DefaultLeftTextsBrush = null;
            this.ganttChartView1.DefaultLeftTextsFont = null;
            this.ganttChartView1.DefaultTopTextsBrush = null;
            this.ganttChartView1.DefaultTopTextsFont = null;
            this.ganttChartView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganttChartView1.Location = new System.Drawing.Point(3, 52);
            this.ganttChartView1.Name = "ganttChartView1";
            this.ganttChartView1.Size = new System.Drawing.Size(497, 248);
            this.ganttChartView1.TabIndex = 1;
            // 
            // ganttChartView1SplitContainer
            // 
            this.ganttChartView1SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganttChartView1SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.ganttChartView1SplitContainer.Name = "ganttChartView1SplitContainer";
            // 
            // ganttChartView1SplitContainer.Panel1
            // 
            this.ganttChartView1SplitContainer.Panel1.Controls.Add(this.ganttChartView1TasksTreeGrid);
            // 
            // ganttChartView1SplitContainer.Panel2
            // 
            this.ganttChartView1SplitContainer.Panel2.Controls.Add(this.ganttChartView1GanttChartPanel);
            this.ganttChartView1SplitContainer.Panel2.Controls.Add(this.ganttChartView1GanttChartCurrentDateScrollBar);
            this.ganttChartView1SplitContainer.Size = new System.Drawing.Size(495, 246);
            this.ganttChartView1SplitContainer.SplitterDistance = 247;
            this.ganttChartView1SplitContainer.TabIndex = 0;
            // 
            // ganttChartView1TasksTreeGrid
            // 
            this.ganttChartView1TasksTreeGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ganttChartView1TasksTreeGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ganttChartView1TasksTreeGrid.ColumnHeadersHeight = 40;
            this.ganttChartView1TasksTreeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganttChartView1TasksTreeGrid.EnableHeadersVisualStyles = false;
            this.ganttChartView1TasksTreeGrid.Location = new System.Drawing.Point(0, 0);
            this.ganttChartView1TasksTreeGrid.Name = "ganttChartView1TasksTreeGrid";
            this.ganttChartView1TasksTreeGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ganttChartView1TasksTreeGrid.Size = new System.Drawing.Size(247, 246);
            this.ganttChartView1TasksTreeGrid.TabIndex = 0;
            this.ganttChartView1TasksTreeGrid.TreeMinusIcon = ((System.Drawing.Icon)(resources.GetObject("ganttChartView1TasksTreeGrid.TreeMinusIcon")));
            this.ganttChartView1TasksTreeGrid.TreePlusIcon = ((System.Drawing.Icon)(resources.GetObject("ganttChartView1TasksTreeGrid.TreePlusIcon")));
            // 
            // ganttChartView1GanttChartPanel
            // 
            this.ganttChartView1GanttChartPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ganttChartView1GanttChartPanel.BackColor = System.Drawing.SystemColors.Window;
            this.ganttChartView1GanttChartPanel.Controls.Add(this.ganttChartView1GanttChartHeader);
            this.ganttChartView1GanttChartPanel.Controls.Add(this.ganttChartView1GanttChartArea);
            this.ganttChartView1GanttChartPanel.Controls.Add(this.ganttChartView1GanttChartVerticalScrollBar);
            this.ganttChartView1GanttChartPanel.Location = new System.Drawing.Point(0, 0);
            this.ganttChartView1GanttChartPanel.Name = "ganttChartView1GanttChartPanel";
            this.ganttChartView1GanttChartPanel.Size = new System.Drawing.Size(244, 229);
            this.ganttChartView1GanttChartPanel.TabIndex = 0;
            // 
            // ganttChartView1GanttChartHeader
            // 
            this.ganttChartView1GanttChartHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ganttChartView1GanttChartHeader.BackColor = System.Drawing.SystemColors.Control;
            this.ganttChartView1GanttChartHeader.Location = new System.Drawing.Point(0, 0);
            this.ganttChartView1GanttChartHeader.Name = "ganttChartView1GanttChartHeader";
            this.ganttChartView1GanttChartHeader.Size = new System.Drawing.Size(244, 40);
            this.ganttChartView1GanttChartHeader.TabIndex = 0;
            // 
            // ganttChartView1GanttChartArea
            // 
            this.ganttChartView1GanttChartArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ganttChartView1GanttChartArea.DefaultAssignmentsBrush = null;
            this.ganttChartView1GanttChartArea.DefaultAssignmentsFont = null;
            this.ganttChartView1GanttChartArea.DefaultBarTextsBrush = null;
            this.ganttChartView1GanttChartArea.DefaultBarTextsFont = null;
            this.ganttChartView1GanttChartArea.DefaultBottomTextsBrush = null;
            this.ganttChartView1GanttChartArea.DefaultBottomTextsFont = null;
            this.ganttChartView1GanttChartArea.DefaultCriticalRemainingsTextBrush = null;
            this.ganttChartView1GanttChartArea.DefaultCriticalRemainingsTextFont = null;
            this.ganttChartView1GanttChartArea.DefaultLeftTextsBrush = null;
            this.ganttChartView1GanttChartArea.DefaultLeftTextsFont = null;
            this.ganttChartView1GanttChartArea.DefaultTopTextsBrush = null;
            this.ganttChartView1GanttChartArea.DefaultTopTextsFont = null;
            this.ganttChartView1GanttChartArea.Location = new System.Drawing.Point(0, 40);
            this.ganttChartView1GanttChartArea.Name = "ganttChartView1GanttChartArea";
            this.ganttChartView1GanttChartArea.Size = new System.Drawing.Size(244, 189);
            this.ganttChartView1GanttChartArea.TabIndex = 1;
            // 
            // ganttChartView1GanttChartVerticalScrollBar
            // 
            this.ganttChartView1GanttChartVerticalScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ganttChartView1GanttChartVerticalScrollBar.LargeChange = 0;
            this.ganttChartView1GanttChartVerticalScrollBar.Location = new System.Drawing.Point(244, 0);
            this.ganttChartView1GanttChartVerticalScrollBar.Maximum = 0;
            this.ganttChartView1GanttChartVerticalScrollBar.Name = "ganttChartView1GanttChartVerticalScrollBar";
            this.ganttChartView1GanttChartVerticalScrollBar.Size = new System.Drawing.Size(17, 229);
            this.ganttChartView1GanttChartVerticalScrollBar.SmallChange = 0;
            this.ganttChartView1GanttChartVerticalScrollBar.TabIndex = 2;
            // 
            // ganttChartView1GanttChartCurrentDateScrollBar
            // 
            this.ganttChartView1GanttChartCurrentDateScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ganttChartView1GanttChartCurrentDateScrollBar.LargeChange = 7;
            this.ganttChartView1GanttChartCurrentDateScrollBar.Location = new System.Drawing.Point(0, 229);
            this.ganttChartView1GanttChartCurrentDateScrollBar.Maximum = 730;
            this.ganttChartView1GanttChartCurrentDateScrollBar.Name = "ganttChartView1GanttChartCurrentDateScrollBar";
            this.ganttChartView1GanttChartCurrentDateScrollBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ganttChartView1GanttChartCurrentDateScrollBar.Size = new System.Drawing.Size(244, 17);
            this.ganttChartView1GanttChartCurrentDateScrollBar.TabIndex = 1;
            // 
            // StatisticsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatisticsView";
            this.Size = new System.Drawing.Size(503, 303);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ganttChartView1.ResumeLayout(false);
            this.ganttChartView1SplitContainer.Panel1.ResumeLayout(false);
            this.ganttChartView1SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ganttChartView1SplitContainer)).EndInit();
            this.ganttChartView1SplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ganttChartView1TasksTreeGrid)).EndInit();
            this.ganttChartView1GanttChartPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private DlhSoft.ProjectDataControlLibrary.GanttChartView ganttChartView1;
        private System.Windows.Forms.SplitContainer ganttChartView1SplitContainer;
        private DlhSoft.ProjectDataControlLibrary.TasksTreeGrid ganttChartView1TasksTreeGrid;
        private DlhSoft.ProjectDataControlLibrary.GanttChartPanel ganttChartView1GanttChartPanel;
        private DlhSoft.ProjectDataControlLibrary.GanttChartHeader ganttChartView1GanttChartHeader;
        private DlhSoft.ProjectDataControlLibrary.GanttChartArea ganttChartView1GanttChartArea;
        private DlhSoft.ProjectDataControlLibrary.GanttChartVerticalScrollBar ganttChartView1GanttChartVerticalScrollBar;
        private DlhSoft.ProjectDataControlLibrary.GanttChartCurrentDateScrollBar ganttChartView1GanttChartCurrentDateScrollBar;
    }
}
