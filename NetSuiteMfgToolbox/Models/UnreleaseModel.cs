using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using RedBuilt.NetSuite;

namespace NetSuiteMfgToolbox.Models
{
    public class UnreleaseModel
    {
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
            
        }
    }
}
