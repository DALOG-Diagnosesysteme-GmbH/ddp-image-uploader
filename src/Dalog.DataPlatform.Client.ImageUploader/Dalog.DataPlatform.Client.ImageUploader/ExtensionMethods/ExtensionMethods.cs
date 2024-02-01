// -----------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Runtime.CompilerServices;

namespace Dalog.DataPlatform.Client.ImageUploader.ExtensionMethods
{
    /// <summary>
    /// The extension methods class
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Adds a data binding to a text box.
        /// </summary>
        /// <typeparam name="T">The data source object</typeparam>
        /// <param name="control">The text box.</param>
        /// <param name="dataSource">The data source object</param>
        /// <param name="dataMember">The data member</param>
        internal static void AddDataBinding<T>(this TextBox control, T dataSource, string dataMember) where T : class
        {
            var binding = new Binding(nameof(control.Text), dataSource, dataMember);
            control.DataBindings.Add(binding);
        }

        /// <summary>
        /// Adds a data binding to a combo box.
        /// </summary>
        /// <typeparam name="T">The data source object</typeparam>
        /// <param name="control">The combo box.</param>
        /// <param name="dataSource">The data source object</param>
        /// <param name="dataMember">The data member</param>
        internal static void AddDataBinding<T>(this ComboBox control, T dataSource, string dataMember) where T : class
        {
            var binding = new Binding(nameof(control.SelectedItem), dataSource, dataMember);
            control.DataBindings.Add(binding);
        }

        /// <summary>
        /// Adds a data binding to a check box.
        /// </summary>
        /// <typeparam name="T">The data source object</typeparam>
        /// <param name="control">The check box.</param>
        /// <param name="dataSource">The data source object</param>
        /// <param name="dataMember">The data member</param>
        internal static void AddDataBinding<T>(this CheckBox control, T dataSource, string dataMember) where T : class
        {
            var binding = new Binding(nameof(control.Checked), dataSource, dataMember);
            control.DataBindings.Add(binding);
        }

        /// <summary>
        /// Adds a data binding to a numeric up down.
        /// </summary>
        /// <typeparam name="T">The data source object</typeparam>
        /// <param name="control">The numeric up down.</param>
        /// <param name="dataSource">The data source object</param>
        /// <param name="dataMember">The data member</param>
        internal static void AddDataBinding<T>(this NumericUpDown control, T dataSource, string dataMember) where T : class
        {
            var binding = new Binding(nameof(control.Value), dataSource, dataMember);
            control.DataBindings.Add(binding);
        }

        /// <summary>
        /// Hides a form while performs an action
        /// </summary>
        /// <param name="form">The form</param>
        /// <param name="action">The action to perform</param>
        internal static void HideFormWhile(this Form form, Action action)
        {
            form.Visible = false;
            action?.Invoke();
            form.Visible = true;
        }
    }
}