using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetSuiteMfgToolbox.Models
{
    public class UpdateBOMRevisionModel
    {
        public async Task Update(string soNumber)
        {
            await Task.Delay(1000);
            MessageBox.Show($"Updated {soNumber}'s BOM Revisions");
        }
    }
}
