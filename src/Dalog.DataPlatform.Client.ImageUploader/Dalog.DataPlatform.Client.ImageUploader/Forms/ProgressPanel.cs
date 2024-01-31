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
        /// <param name="labelText">The label text.</param>
        public ProgressPanel(CancellationTokenSource? cts = null, string labelText = "Loading...")
        {
            InitializeComponent();
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.LabelText = labelText;
            this._cts = cts;
            this.FormClosing += ProgressPanel_FormClosing;
        }

        /// <summary>
        /// The label text.
        /// </summary>
        public string LabelText
        {
            get { return this.labelStatus.Text; }
            set { this.labelStatus.Text = value; }
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