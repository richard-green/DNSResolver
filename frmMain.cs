using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnsResolver
{
    public partial class frmMain : Form
    {
        #region Members

        Queue<string> dnsRequestsToDo = new Queue<string>();

        #endregion Members

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region User Events

        private void dgDnsEntries_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                EnqueueResolve(dgDnsEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as string);
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            dgDnsEntries.Rows.Clear();
        }

        private void btnFlushDNS_Click(object sender, EventArgs e)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "ipconfig";
            p.StartInfo.Arguments = "/flushdns";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            MessageBox.Show(output, "Flush DNS results");
        }

        private void btnResolveAll_Click(object sender, EventArgs e)
        {
            foreach (var hostname in GetCurrentHostnameList())
            {
                EnqueueResolve(hostname);
            }
        }

        private void btnPasteFromClipboard_Click(object sender, EventArgs e)
        {
            var entries = Clipboard.GetText();

            var hostnames = entries.Split(new string[] { ",", "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            DataGridViewRow row;

            foreach (var hostname in hostnames)
            {
                row = new DataGridViewRow();
                row.CreateCells(dgDnsEntries, hostname, "");
                dgDnsEntries.Rows.Add(row);
            }

            foreach (var hostname in hostnames.Distinct())
            {
                EnqueueResolve(hostname);
            }
        }

        #endregion User Events

        #region Private Methods

        private void EnqueueResolve(string hostname)
        {
            lock (dnsRequestsToDo)
            {
                dnsRequestsToDo.Enqueue(hostname);
                UpdateIPAddress(hostname, "pending...");
            }
        }

        private void UpdateIPAddress(string hostname, string newValue)
        {
            this.InvokeAction(@this =>
                {
                    for (int i = 0; i < dgDnsEntries.Rows.Count; i++)
                    {
                        if (hostname.Equals(((string)dgDnsEntries.Rows[i].Cells[0].Value), StringComparison.CurrentCultureIgnoreCase))
                        {
                            dgDnsEntries.Rows[i].Cells[1].Value = newValue;
                        }
                    }
                });
        }

        private IEnumerable<string> GetCurrentHostnameList()
        {
            var hostnames = new List<string>();

            for (int i = 0; i < dgDnsEntries.Rows.Count; i++)
            {
                var hostname = (string)dgDnsEntries.Rows[i].Cells[0].Value;

                if (String.IsNullOrEmpty(hostname) == false)
                {
                    hostnames.Add(hostname);
                }
            }

            return hostnames.Distinct();
        }

        #endregion Private Methods

        #region Events

        private void tmrQueuePoll_Tick(object sender, EventArgs e)
        {
            tmrQueuePoll.Enabled = false;

            try
            {
                lock (dnsRequestsToDo)
                {
                    while (dnsRequestsToDo.Any())
                    {
                        var hostname = dnsRequestsToDo.Dequeue();

                        try
                        {
                            var ip = Dns.GetHostEntry(hostname);
                            UpdateIPAddress(hostname, ip.AddressList[0].ToString());
                        }
                        catch (Exception ex)
                        {
                            UpdateIPAddress(hostname, ex.Message);
                        }
                    }
                }
            }
            finally
            {
                tmrQueuePoll.Enabled = true;
            }
        }

        #endregion Events
    }
}
