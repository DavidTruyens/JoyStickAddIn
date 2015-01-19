<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Param2 = New System.Windows.Forms.ComboBox()
        Me.Param1 = New System.Windows.Forms.ComboBox()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.Max2 = New System.Windows.Forms.TextBox()
        Me.Min2 = New System.Windows.Forms.TextBox()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Max1 = New System.Windows.Forms.TextBox()
        Me.Min1 = New System.Windows.Forms.TextBox()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Param2
        '
        Me.Param2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Param2.FormattingEnabled = True
        Me.Param2.Location = New System.Drawing.Point(25, 59)
        Me.Param2.Name = "Param2"
        Me.Param2.Size = New System.Drawing.Size(121, 24)
        Me.Param2.TabIndex = 5
        '
        'Param1
        '
        Me.Param1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Param1.FormattingEnabled = True
        Me.Param1.Location = New System.Drawing.Point(25, 27)
        Me.Param1.Name = "Param1"
        Me.Param1.Size = New System.Drawing.Size(121, 24)
        Me.Param1.TabIndex = 6
        '
        'TrackBar2
        '
        Me.TrackBar2.LargeChange = 10
        Me.TrackBar2.Location = New System.Drawing.Point(343, 59)
        Me.TrackBar2.Maximum = 100
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Size = New System.Drawing.Size(210, 56)
        Me.TrackBar2.TabIndex = 13
        Me.TrackBar2.TickFrequency = 10
        '
        'Max2
        '
        Me.Max2.Location = New System.Drawing.Point(218, 59)
        Me.Max2.Name = "Max2"
        Me.Max2.Size = New System.Drawing.Size(59, 22)
        Me.Max2.TabIndex = 12
        '
        'Min2
        '
        Me.Min2.Location = New System.Drawing.Point(152, 59)
        Me.Min2.Name = "Min2"
        Me.Min2.Size = New System.Drawing.Size(60, 22)
        Me.Min2.TabIndex = 11
        '
        'TrackBar1
        '
        Me.TrackBar1.LargeChange = 10
        Me.TrackBar1.Location = New System.Drawing.Point(343, 27)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(210, 56)
        Me.TrackBar1.TabIndex = 10
        Me.TrackBar1.TickFrequency = 10
        '
        'Max1
        '
        Me.Max1.Location = New System.Drawing.Point(218, 29)
        Me.Max1.Name = "Max1"
        Me.Max1.Size = New System.Drawing.Size(59, 22)
        Me.Max1.TabIndex = 9
        '
        'Min1
        '
        Me.Min1.Location = New System.Drawing.Point(152, 29)
        Me.Min1.Name = "Min1"
        Me.Min1.Size = New System.Drawing.Size(60, 22)
        Me.Min1.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 296)
        Me.Controls.Add(Me.TrackBar2)
        Me.Controls.Add(Me.Max2)
        Me.Controls.Add(Me.Min2)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Max1)
        Me.Controls.Add(Me.Min1)
        Me.Controls.Add(Me.Param1)
        Me.Controls.Add(Me.Param2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Param2 As System.Windows.Forms.ComboBox
    Friend WithEvents Param1 As System.Windows.Forms.ComboBox
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents Max2 As System.Windows.Forms.TextBox
    Friend WithEvents Min2 As System.Windows.Forms.TextBox
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents Max1 As System.Windows.Forms.TextBox
    Friend WithEvents Min1 As System.Windows.Forms.TextBox
End Class
