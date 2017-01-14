using System;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using SimpleProjectManager.Module.BusinessObjects.Planning;

namespace SimpleProjectManager.Module.Controllers
{
    public class ProjectTaskController : ViewController
    {
        private SimpleAction simpleAction1;
        private System.ComponentModel.IContainer components;

        public ProjectTaskController()
        {
            TargetObjectType = typeof(ProjectTask);
            TargetViewType = ViewType.Any;
            //tests
            SimpleAction markCompletedAction = new SimpleAction(
                this, "MarkCompleted",
                DevExpress.Persistent.Base.PredefinedCategory.RecordEdit)
            {
                TargetObjectsCriteria = (
                    CriteriaOperator.Parse("Status != ?", ProjectTaskStatus.Completed)
                                                                     ).ToString(),
                ConfirmationMessage =
                            "Are you sure you want to mark the selected task(s) as 'Completed'?",
                ImageName = "State_Task_Completed"
            };
            markCompletedAction.Execute += (s, e) => {
                foreach (ProjectTask task in e.SelectedObjects)
                {
                    task.EndDate = DateTime.Now;
                    task.Status = ProjectTaskStatus.Completed;
                    View.ObjectSpace.SetModified(task);
                }
                View.ObjectSpace.CommitChanges();
                View.ObjectSpace.Refresh();
            };
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleAction1 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // simpleAction1
            // 
            this.simpleAction1.Caption = null;
            this.simpleAction1.ConfirmationMessage = null;
            this.simpleAction1.Id = "aed39b0f-a26a-41a0-89fa-f98199d957b3";
            this.simpleAction1.TargetObjectType = typeof(SimpleProjectManager.Module.BusinessObjects.Planning.Project);
            this.simpleAction1.ToolTip = null;
            // 
            // ProjectTaskController
            // 
            this.Actions.Add(this.simpleAction1);

        }
    }
}