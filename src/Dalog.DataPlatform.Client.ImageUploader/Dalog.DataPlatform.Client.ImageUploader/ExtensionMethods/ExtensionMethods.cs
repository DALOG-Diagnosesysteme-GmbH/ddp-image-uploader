// -----------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="DALOG Diagnosesysteme GmbH">
//  Copyright (c) DALOG(r) Diagnosesysteme GmbH. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Dalog.DataPlatform.Client.ImageUploader.ExtensionMethods
{
    /// <summary>
    /// The extension methods class
    /// </summary>
    internal static class ExtensionMethods
    {
        internal static void AddDataBinding<T>(this TextBox control, T dataSource, string dataMember) where T : class
        {
            var binding = new Binding(nameof(control.Text), dataSource, dataMember);
            control.DataBindings.Add(binding);
        }

        internal static void AddDataBinding<T>(this ComboBox control, T dataSource, string dataMember) where T : class
        {
            var binding = new Binding(nameof(control.SelectedItem), dataSource, dataMember);
            control.DataBindings.Add(binding);
        }

        internal static void AddDataBinding<T>(this CheckBox control, T dataSource, string dataMember) where T : class
        {
            var binding = new Binding(nameof(control.Checked), dataSource, dataMember);
            control.DataBindings.Add(binding);
        }

        internal static void AddDataBinding<T>(this NumericUpDown control, T dataSource, string dataMember) where T : class
        {
            var binding = new Binding(nameof(control.Value), dataSource, dataMember);
            control.DataBindings.Add(binding);
        }

        internal static void HideFormWhile(this Form form, Action action)
        {
            form.Visible = false;
            action?.Invoke();
            form.Visible = true;
        }
    }
}
