using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace netshGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class netshUTILITY : Window
    {
        
        public ProcessStartInfo startInfo { get; set; }

        public Process proc { get; set; }

        public netshUTILITY()
        {
            InitializeComponent();
            set.Click += set_Click;
            start.Click += Start_Click;
            stop.Click += Stop_Click;
            SSID.Text = null;
            KEY.Text = null;

            

            startInfo = new ProcessStartInfo("cmd.exe");
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = @"C:\Windows\System32";
            
            


        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();.
            try
            {
                proc = Process.Start(startInfo);
                proc.StandardInput.WriteLine("netsh wlan stop hostednetwork");
                proc.StandardInput.Close();
                
                outputLabel.Content = proc.StandardOutput.ReadToEnd();
                proc.StandardOutput.Close();
                proc.Close();
            }
            catch (Exception exp)
            {
                outputLabel.Content = exp;
                //throw;
            }
                
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                proc = Process.Start(startInfo);
                proc.StandardInput.WriteLine("netsh wlan start hostednetwork");
                proc.StandardInput.Close();
                outputLabel.Content = proc.StandardOutput.ReadToEnd();
                proc.StandardOutput.Close();
                proc.Close();
            }
            catch (Exception ecp)
            {
                outputLabel.Content = ecp;
                //throw;
            }
                
        }

        private void set_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                proc = Process.Start(startInfo);
                proc.StandardInput.WriteLine("netsh wlan set hostednetwork ssid=" + SSID.Text + " key=" + KEY.Text + " mode=allow");
                proc.StandardInput.Close();
                outputLabel.Content = proc.StandardOutput.ReadToEnd();
                proc.StandardOutput.Close();
                proc.Close();
            }
            catch (Exception egp)
            {
                outputLabel.Content = egp;
                
                //throw;
            }

                
        }


        
    }

}
