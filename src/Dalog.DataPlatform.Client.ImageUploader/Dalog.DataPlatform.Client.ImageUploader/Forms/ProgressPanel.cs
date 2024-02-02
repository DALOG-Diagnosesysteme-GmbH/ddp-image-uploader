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
        /// <summary>
        /// The cancellation token
        /// </summary>
        private readonly CancellationTokenSource? _cts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressPanel"/> class.
        /// </summary>
        /// <param name="cts">The cancellation token source.</param>
        public ProgressPanel(CancellationTokenSource? cts = null)
        {
            InitializeComponent();
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this._cts = cts;
            this.FormClosing += ProgressPanel_FormClosing;
        }

        /// <summary>
        /// Instantiates a progress panel.
        /// </summary>
        /// <param name="parent">The form parent</param>
        /// <param name="cts">The cancellation token source</param>
        /// <param name="text">The message text</param>
        /// <returns>The progress panel object</returns>
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

        /// <summary>
        /// Changes the label text
        /// </summary>
        /// <param name="text">The new text</param>
        public void ChangeLabelText(string text)
        {
            if (this.labelStatus.InvokeRequired)
            {
                this.labelStatus.Invoke(new MethodInvoker(() => this.ChangeLabelText(text)));
                return;
            }

            this.labelStatus.Text = text;
        }

        /// <summary>
        /// Method called when the form is closing.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The form closing event args.</param>
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