// -----------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalog.DataPlatform.Client.ImageUploader.ExtensionMethods
{
    /// <summary>
    /// The extension methods class
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Fits a form size to fit a determined user control
        /// </summary>
        /// <param name="input">The form</param>
        /// <param name="content">The user control</param>
        internal static void AddAndFitToUserControl(this Form input, UserControl content)
        {
            if (content == null)
            {
                return;
            }

            input.SuspendLayout();
            var menuSize = new Size(content.Width, content.Height);
            input.ClientSize = menuSize;
            input.AutoSize = true;
            input.Controls.Add(content);
            input.Controls.SetChildIndex(content, 0);
            content.Dock = DockStyle.Top;
            input.ResumeLayout();
        }
    }
}