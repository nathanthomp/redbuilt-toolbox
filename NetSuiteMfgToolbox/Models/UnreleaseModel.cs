using System.Threading.Tasks;
using System.Windows;

namespace NetSuiteMfgToolbox.Models
{
    public class UnreleaseModel
    {
        public async Task Unrelease(string soNumber)
        {
            await Task.Delay(1000);
            MessageBox.Show($"Unreleased {soNumber}");
        }
    }
}
