using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace SimpleProjectManager.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {

            base.UpdateDatabaseAfterUpdateSchema();
            if (ObjectSpace.CanInstantiate(typeof(BusinessObjects.Planning.Project)))
            {
                BusinessObjects.Planning.Project project = ObjectSpace.FindObject<BusinessObjects.Planning.Project>(
                    new BinaryOperator("Name", "DevExpress XAF Features Overview"));
                if (project == null)
                {
                    project = ObjectSpace.CreateObject<BusinessObjects.Planning.Project>();
                    project.Name = "DevExpress XAF Features Overview";
                }
                ObjectSpace.CommitChanges();
            }
            /*if (ObjectSpace.CanInstantiate(typeof(Customer)))
            {
                Customer customer = ObjectSpace.FindObject<Customer>(
                    CriteriaOperator.Parse("FirstName == 'Robert' && LastName == 'Anderson'"));
                if (customer == null)
                {
                    customer = ObjectSpace.CreateObject<Customer>();
                    customer.FirstName = "Robert";
                    customer.LastName = "Anderson";
                    customer.Company = "Coprocess, ZeroSharp";
                }
                ObjectSpace.CommitChanges();
            }*/

        }
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
    }
}
