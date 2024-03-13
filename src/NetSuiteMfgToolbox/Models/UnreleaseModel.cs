using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using RedBuilt.NetSuite;

namespace NetSuiteMfgToolbox.Models
{
    public class UnreleaseModel
    {
        public static void Unrelease(string salesOrderName)
        {
            // Try to get the sales order
            RBSalesOrder salesOrder;
            try
            {
                salesOrder = RBSalesOrder.GetSalesOrder(salesOrderName);
            }
            catch
            {
                MessageBox.Show($"Could not find sales order {salesOrderName}");
                return;
            }


        }


        //public NetSuiteMfgToolbox.ViewModels.UnreleaseViewModel ViewModel { get; set; }

        //public async Task Unrelease(string soNumber)
        //{
        //    //await Task.Delay(1000);
        //    //MessageBox.Show($"Unreleased {soNumber}");
        //    RBSalesOrder salesOrder = RBSalesOrder.GetSalesOrder(soNumber);
        //    List<RBWorkOrder> allWorkOrders = RBWorkOrder.GetRelatedWorkOrdersByCreatedFrom(salesOrder.InternalId);
        //    foreach(RBWorkOrder order in allWorkOrders)
        //    {
        //        unReleaseWorkOrder(order);
        //    }
        //}

        //private void unReleaseWorkOrder(RBWorkOrder workOrder) 
        //{
        //    //if this is a parent work order, we need to change status from Released to Plan and clear WO Initialize checkbox
        //    if (workOrder.OrderStatus == EWorkOrderStatus.Released)
        //    {
        //        Console.WriteLine("Un-releasing workOrder " + workOrder.Name);
        //        //Delete children WorkOrders
        //        List<RBWorkOrder> childWorkOrders = RBWorkOrder.GetRelatedWorkOrdersByCreatedFrom(workOrder.InternalId);
        //        foreach (RBWorkOrder childOrder in childWorkOrders)
        //        {
        //            Console.WriteLine("Deleting child work order " + childOrder.Name);
        //            childOrder.Delete();
        //        }

        //        //change status from released to plan
        //        workOrder.OrderStatus = EWorkOrderStatus.Planned;

        //        //clear child WOs build checkbox
        //        workOrder.ChildWOsBuilt = false;

        //        //clear WO Initized checkbox
        //        workOrder.RBInitialized = false;

        //        //clear work center
        //        //workOrder.WorkCenterId = null;

        //        workOrder.Update(true);
        //    }
        //    else
        //    {
        //        //Console.WriteLine("Skipping " + workOrder.Name + " with status " + workOrder.OrderStatus);
        //        //ViewModel.
        //    }
        //}

        //private static void UnreleaseWorkOrders(string salesOrderName, bool deleteParentWO)
        //{
        //    RBSalesOrder soToUpdate = RBSalesOrder.GetSalesOrder(salesOrderName);
        //    List<RBWorkOrder> allWorkOrders = RBWorkOrder.GetRelatedWorkOrdersByCreatedFrom(soToUpdate.InternalId);
        //    foreach (RBWorkOrder workOrder in allWorkOrders)
        //    {
        //        if (workOrder.OrderStatus == EWorkOrderStatus.Released)
        //        {
        //            Console.WriteLine("Un-releasing workOrder " + workOrder.Name);
        //            //Delete children WorkOrders
        //            List<RBWorkOrder> childWorkOrders = RBWorkOrder.GetRelatedWorkOrdersByCreatedFrom(workOrder.InternalId);
        //            bool allChildrenDeleted = true;
        //            foreach (RBWorkOrder childOrder in childWorkOrders)
        //            {
        //                //we need to verify all child work orders can be deleted 
        //                //bool thisTreeDeleted = DeleteChildWorkOrderTree(childOrder);
        //                if (allChildrenDeleted && !DeleteChildWorkOrderTree(childOrder))
        //                {
        //                    allChildrenDeleted = false;
        //                }
        //            }
        //            if (allChildrenDeleted)
        //            {
        //                if (deleteParentWO)
        //                {
        //                    Console.WriteLine("Deleting parent work order " + workOrder.Name);
        //                    workOrder.Delete();
        //                }
        //                else
        //                {
        //                    //change status from released to plan
        //                    workOrder.OrderStatus = EWorkOrderStatus.Planned;

        //                    //clear child WOs build checkbox
        //                    workOrder.ChildWOsBuilt = false;

        //                    //clear WO Initized checkbox
        //                    workOrder.RBInitialized = false;

        //                    workOrder.HasChildWOs = false;
        //                    //clear work center
        //                    //workOrder.WorkCenterId = null;
        //                    Console.WriteLine("WorkCenter:" + workOrder.WorkCenterName);

        //                    UpdateBOMRevision(workOrder, false);

        //                    //need to change the SO line source from stock to work order
        //                }

        //                workOrder.Update(true);
        //            }
        //            else
        //            {
        //                Console.WriteLine("Was unable to delete all children work orders for " + workOrder.Name);
        //            }
        //        }
        //        else if (deleteParentWO)
        //        {
        //            Console.WriteLine("Deleting work order " + workOrder.Name);
        //            workOrder.Delete();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Skipping " + workOrder.Name + " with status " + workOrder.OrderStatus);
        //        }
        //    }
        //}
    }
}
