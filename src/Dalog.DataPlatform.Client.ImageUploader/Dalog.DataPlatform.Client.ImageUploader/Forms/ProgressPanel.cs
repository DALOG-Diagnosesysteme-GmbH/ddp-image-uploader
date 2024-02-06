// -----------------------------------------------------------------------
// <copyright file="ProgressPanel.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Dalog.DataPlatform.Client.ImageUploader.Forms
{
    /// <summary>
    /// The progress panel form.
    /// </summary>
    public partial class ProgressPanel : Form
    {
        private readonly CancellationTokenSource? _cts;

        public ProgressPanel(CancellationTokenSource? cts = null)
        {
            InitializeComponent();
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this._cts = cts;
            this.FormClosing += ProgressPanel_FormClosing;
        }

        public static ProgressPanel? Instantiate(Form parent, CancellationTokenSource cts, string text)
        {
            if (parent.InvokeRequired)
            {
                parent.Invoke(new MethodInvoker(() => Instantiate(parent, cts, text)));
                return null;
            }

            var panel = new ProgressPanel(cts);
            panel.ChangeLabelText(text);
            return panel;
        }

        public void ChangeLabelText(string text)
        {
            if (this.labelStatus.InvokeRequired)
            {
                this.labelStatus.Invoke(new MethodInvoker(() => this.ChangeLabelText(text)));
                return;
            }

            this.labelStatus.Text = text;
        }

        private void ProgressPanel_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.FormClosing -= ProgressPanel_FormClosing;
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                return;
            }

            this._cts?.Cancel();
            this.Close();
        }
    }
}
