using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using RedBuilt.NetSuite;

namespace NetSuiteMfgToolbox.Models
{
    public class UnreleaseModel
    {
        public NetSuiteMfgToolbox.ViewModels.UnreleaseViewModel ViewModel { get; set; }

        public async Task Unrelease(string soNumber)
        {
            //await Task.Delay(1000);
            //MessageBox.Show($"Unreleased {soNumber}");
            RBSalesOrder salesOrder = RBSalesOrder.GetSalesOrder(soNumber);
            List<RBWorkOrder> allWorkOrders = RBWorkOrder.GetRelatedWorkOrdersByCreatedFrom(salesOrder.InternalId);
            foreach(RBWorkOrder order in allWorkOrders)
            {
                unReleaseWorkOrder(order);
            }
        }
        private void unReleaseWorkOrder(RBWorkOrder workOrder) 
        {
            //if this is a parent work order, we need to change status from Released to Plan and clear WO Initialize checkbox
            if (workOrder.OrderStatus == EWorkOrderStatus.Released)
            {
                Console.WriteLine("Un-releasing workOrder " + workOrder.Name);
                //Delete children WorkOrders
                List<RBWorkOrder> childWorkOrders = RBWorkOrder.GetRelatedWorkOrdersByCreatedFrom(workOrder.InternalId);
                foreach (RBWorkOrder childOrder in childWorkOrders)
                {
                    Console.WriteLine("Deleting child work order " + childOrder.Name);
                    childOrder.Delete();
                }

                //change status from released to plan
                workOrder.OrderStatus = EWorkOrderStatus.Planned;

                //clear child WOs build checkbox
                workOrder.ChildWOsBuilt = false;

                //clear WO Initized checkbox
                workOrder.RBInitialized = false;

                //clear work center
                //workOrder.WorkCenterId = null;

                workOrder.Update(true);
            }
            else
            {
                //Console.WriteLine("Skipping " + workOrder.Name + " with status " + workOrder.OrderStatus);
                //ViewModel.
            }
        }
    }
}
