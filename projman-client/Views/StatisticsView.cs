using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DlhSoft.ProjectDataControlLibrary;


namespace projman_client.Views
{
    public partial class StatisticsView : IBaseView
    {
        public StatisticsView(List<Task> project)
        {
            InitializeComponent();
            ganttChartView1.StartMember = "Start";
            ganttChartView1.WorkMember = "Work";
            
            ganttChartView1.CompletedWorkMember = "CompletedWork";
            ganttChartView1.PredecessorsMember = "Predecessors";
            ganttChartView1.ResourcesMember = "Resources";
            ganttChartView1.GanttImageIndexMember = "IconIndex";
            ganttChartView1.PlannedStartMember = "PlannedStart";
            ganttChartView1.PlannedWorkMember = "PlannedWork";
            ganttChartView1.PlannedCompletedWorkMember = "PlannedCompletedWork";
            ganttChartView1.TasksTreeGrid.Columns.Add("Test", "test");
            ganttChartView1.TasksTreeGrid.Columns.Add(ganttChartView1.StartMember, ganttChartView1.StartMember);
            ganttChartView1.TasksTreeGrid.Columns.Add(ganttChartView1.WorkMember, ganttChartView1.WorkMember);
            ganttChartView1.TasksTreeGrid.Columns.Add(ganttChartView1.CompletedWorkMember, ganttChartView1.CompletedWorkMember);
            ganttChartView1.TasksTreeGrid.Columns.Add(ganttChartView1.CompletedWorkMember, ganttChartView1.CompletedWorkMember);
            ganttChartView1.Schedule = new Schedule(new DaytimeInterval[] {new DaytimeInterval(0, 24)}, new Dictionary<DayOfWeek, DaytimeInterval[]>(), new Dictionary<DateTime, DaytimeInterval[]>());
            foreach (var task in project)
            {

                ganttChartView1.TasksTreeGrid.Rows.Add(
                    task.title, //name
                  task.StartDate, //start
                   // DateTime.MinValue, //finish is not used in standard (no binding) mode
                    (task.EndDate-task.StartDate).TotalHours, //work
                    24//completed work
                    );
                
                Refresh();
            }


            // ganttChartView1.TasksTreeGrid.IncreaseIndent(1); //Task 2
            //ganttChartView1.TasksTreeGrid.IncreaseIndent(2); //Task 3
            //ganttChartView1.TasksTreeGrid.IncreaseIndent(3); //Task 4

            // ganttChartView1.TasksTreeGrid.SetImageIndex(0, 1); //Task 1
        }

        void init()
        {
            ganttChartView1.CurrentDate = ganttChartView1.InitialDate;

            ganttChartView1.ShowTasksTreeGrid = true;
           

            ganttChartView1.ScaleType = ScaleType.Weeks;
           ganttChartView1.UpdateScaleType = UpdateScaleType.Hour;
            

           // ganttChartView1.Schedule = MyTask.Schedule = Schedule.Default;
         
           ganttChartView1.DefaultWorkBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, 16), Color.FromArgb(128, Color.LightBlue), Color.FromArgb(224, Color.Blue));
          
            ganttChartView1.ShowGanttIconImages = false;
          

            ganttChartView1.ShowMarkers = true;
           

            ganttChartView1.ShowToolTips = true;
           
            ganttChartView1.ShowAssignments = true;
           

            ganttChartView1.ShowDependencies = true;
            ganttChartView1.AllowGanttUpdateDependencies = true;
            

            ganttChartView1.ShowNonworkingDays = true;
           

            ganttChartView1.ShowNonworkingDaytime = false;
            

            ganttChartView1.HighlightCriticalTasks = false;
            

            ganttChartView1.ShowPlannedValues = false;
           

            //Establish the markers image list only in data bound modes (DataTable or Objects).
            ganttChartView1.MarkersImageList = null;
            

            //Establish available interruption intervals only in data bound modes (DataTable or Objects).
            ganttChartView1.AvailableInterruptionTypes.Clear();
           

            //Establish available resources.
            ganttChartView1.AvailableResources.Clear();
            ganttChartView1.AvailableResources.Add("John");
            ganttChartView1.AvailableResources.Add("Diane");
        }
    }
}
