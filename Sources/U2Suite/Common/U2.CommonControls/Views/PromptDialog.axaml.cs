/* 
 * This file is part of the U2.Suite distribution
 * (https://github.com/ut8uu/U2.Suite).
 * 
 * Copyright (c) 2022 Sergey Usmanov, UT8UU.
 * 
 * This program is free software: you can redistribute it and/or modify  
 * it under the terms of the GNU General Public License as published by  
 * the Free Software Foundation, version 3.
 *
 * This program is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License 
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */

using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace U2.Common;

public enum DialogResult
{
    Ok,
    Cancel,
    Abort,
    Yes,
    No
}

[PropertyChanged.DoNotNotify]
public class PromptDialog : Window
{
    private TextBlock _title = default!;
    private TextBox _response = default!;
    private Button _ok;
    private Button _cancel;

    public PromptDialog()
    {
        AssignControls();
    }

    public PromptDialog(string promptText, string promptInitialResponse = "")
    {
        PromptText = promptText;
        PromptResponse = promptInitialResponse;

        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        AssignControls();

        _title.Text = promptText;
        _response.Text = promptInitialResponse;
    }

    private void AssignControls()
    {
        _title = this.Find<TextBlock>("PromptText");
        Debug.Assert(_title != null);

        _response = this.Find<TextBox>("PromptResponse");
        Debug.Assert(_response != null);

        _ok = this.FindControl<Button>("OkButton");
        Debug.Assert(_ok != null);
        _ok.Click += Ok_Click;

        _cancel = this.FindControl<Button>("CancelButton");
        Debug.Assert(_cancel != null);
        _cancel.Click += Cancel_Click;
    }

    private void Cancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_cancel == null)
        {
            return;
        }
        DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void Ok_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_ok == null)
        {
            return;
        }
        DialogResult = DialogResult.Ok;
        PromptResponse = _response.Text;
        this.Close();
    }

    public DialogResult DialogResult { get; set; } = DialogResult.Ok;
    public string PromptText { get; set; } = "Prompt";
    public string PromptResponse { get; set; } = "Response";

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
