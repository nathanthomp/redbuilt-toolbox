using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetSuiteMfgToolbox.Models
{
    public class UnreleaseModel
    {
        public void Unrelease(string soNumber)
        {
            MessageBox.Show($"Unreleased {soNumber}");
        }

    }
}
