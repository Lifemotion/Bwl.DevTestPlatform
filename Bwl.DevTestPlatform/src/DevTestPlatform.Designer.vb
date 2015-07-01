<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevTestPlatform
    Inherits Bwl.Framework.FormAppBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevTestPlatform))
        Me.statesList = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.rs485Groupbox = New System.Windows.Forms.GroupBox()
        Me.rs485portLabel = New System.Windows.Forms.Label()
        Me.rs485CheckboxOpened = New System.Windows.Forms.CheckBox()
        Me.uartGroupbox = New System.Windows.Forms.GroupBox()
        Me.uartPortLabel = New System.Windows.Forms.Label()
        Me.uartCheckboxOpened = New System.Windows.Forms.CheckBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.toolsGroupbox = New System.Windows.Forms.GroupBox()
        Me.coreGroupbox = New System.Windows.Forms.GroupBox()
        Me.rs232Groupbox = New System.Windows.Forms.GroupBox()
        Me.rs232portLabel = New System.Windows.Forms.Label()
        Me.rs232CheckboxOpened = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rs485Groupbox.SuspendLayout()
        Me.uartGroupbox.SuspendLayout()
        Me.toolsGroupbox.SuspendLayout()
        Me.coreGroupbox.SuspendLayout()
        Me.rs232Groupbox.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.Location = New System.Drawing.Point(0, 360)
        Me.logWriter.Size = New System.Drawing.Size(636, 244)
        '
        'statesList
        '
        Me.statesList.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.statesList.FormattingEnabled = True
        Me.statesList.Location = New System.Drawing.Point(6, 19)
        Me.statesList.Name = "statesList"
        Me.statesList.Size = New System.Drawing.Size(201, 290)
        Me.statesList.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 34)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(150, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "SimplSerialTool"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(7, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(150, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Internal SimplSerial"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 48)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(150, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "New SimplSerial"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(6, 77)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(150, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Self Test Tool"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'rs485Groupbox
        '
        Me.rs485Groupbox.Controls.Add(Me.rs485portLabel)
        Me.rs485Groupbox.Controls.Add(Me.rs485CheckboxOpened)
        Me.rs485Groupbox.Controls.Add(Me.Button2)
        Me.rs485Groupbox.Enabled = False
        Me.rs485Groupbox.Location = New System.Drawing.Point(232, 98)
        Me.rs485Groupbox.Name = "rs485Groupbox"
        Me.rs485Groupbox.Size = New System.Drawing.Size(162, 65)
        Me.rs485Groupbox.TabIndex = 12
        Me.rs485Groupbox.TabStop = False
        Me.rs485Groupbox.Text = "RS-485"
        '
        'rs485portLabel
        '
        Me.rs485portLabel.AutoSize = True
        Me.rs485portLabel.Location = New System.Drawing.Point(6, 16)
        Me.rs485portLabel.Name = "rs485portLabel"
        Me.rs485portLabel.Size = New System.Drawing.Size(38, 13)
        Me.rs485portLabel.TabIndex = 8
        Me.rs485portLabel.Text = "COM#"
        '
        'rs485CheckboxOpened
        '
        Me.rs485CheckboxOpened.AutoSize = True
        Me.rs485CheckboxOpened.Location = New System.Drawing.Point(84, 14)
        Me.rs485CheckboxOpened.Name = "rs485CheckboxOpened"
        Me.rs485CheckboxOpened.Size = New System.Drawing.Size(64, 17)
        Me.rs485CheckboxOpened.TabIndex = 7
        Me.rs485CheckboxOpened.Text = "Opened"
        Me.rs485CheckboxOpened.UseVisualStyleBackColor = True
        '
        'uartGroupbox
        '
        Me.uartGroupbox.Controls.Add(Me.uartPortLabel)
        Me.uartGroupbox.Controls.Add(Me.uartCheckboxOpened)
        Me.uartGroupbox.Controls.Add(Me.Button6)
        Me.uartGroupbox.Enabled = False
        Me.uartGroupbox.Location = New System.Drawing.Point(232, 27)
        Me.uartGroupbox.Name = "uartGroupbox"
        Me.uartGroupbox.Size = New System.Drawing.Size(162, 65)
        Me.uartGroupbox.TabIndex = 12
        Me.uartGroupbox.TabStop = False
        Me.uartGroupbox.Text = "UART"
        '
        'uartPortLabel
        '
        Me.uartPortLabel.AutoSize = True
        Me.uartPortLabel.Location = New System.Drawing.Point(6, 16)
        Me.uartPortLabel.Name = "uartPortLabel"
        Me.uartPortLabel.Size = New System.Drawing.Size(38, 13)
        Me.uartPortLabel.TabIndex = 8
        Me.uartPortLabel.Text = "COM#"
        '
        'uartCheckboxOpened
        '
        Me.uartCheckboxOpened.AutoSize = True
        Me.uartCheckboxOpened.Location = New System.Drawing.Point(84, 14)
        Me.uartCheckboxOpened.Name = "uartCheckboxOpened"
        Me.uartCheckboxOpened.Size = New System.Drawing.Size(64, 17)
        Me.uartCheckboxOpened.TabIndex = 7
        Me.uartCheckboxOpened.Text = "Opened"
        Me.uartCheckboxOpened.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(6, 34)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(150, 23)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "SimplSerialTool"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'toolsGroupbox
        '
        Me.toolsGroupbox.Controls.Add(Me.Button5)
        Me.toolsGroupbox.Controls.Add(Me.Button3)
        Me.toolsGroupbox.Controls.Add(Me.Button4)
        Me.toolsGroupbox.Location = New System.Drawing.Point(231, 242)
        Me.toolsGroupbox.Name = "toolsGroupbox"
        Me.toolsGroupbox.Size = New System.Drawing.Size(163, 108)
        Me.toolsGroupbox.TabIndex = 13
        Me.toolsGroupbox.TabStop = False
        Me.toolsGroupbox.Text = "Tools"
        '
        'coreGroupbox
        '
        Me.coreGroupbox.Controls.Add(Me.statesList)
        Me.coreGroupbox.Enabled = False
        Me.coreGroupbox.Location = New System.Drawing.Point(12, 27)
        Me.coreGroupbox.Name = "coreGroupbox"
        Me.coreGroupbox.Size = New System.Drawing.Size(213, 323)
        Me.coreGroupbox.TabIndex = 14
        Me.coreGroupbox.TabStop = False
        Me.coreGroupbox.Text = "TestBoxCore"
        '
        'rs232Groupbox
        '
        Me.rs232Groupbox.Controls.Add(Me.rs232portLabel)
        Me.rs232Groupbox.Controls.Add(Me.rs232CheckboxOpened)
        Me.rs232Groupbox.Controls.Add(Me.Button1)
        Me.rs232Groupbox.Enabled = False
        Me.rs232Groupbox.Location = New System.Drawing.Point(232, 169)
        Me.rs232Groupbox.Name = "rs232Groupbox"
        Me.rs232Groupbox.Size = New System.Drawing.Size(162, 65)
        Me.rs232Groupbox.TabIndex = 13
        Me.rs232Groupbox.TabStop = False
        Me.rs232Groupbox.Text = "RS-232"
        '
        'rs232portLabel
        '
        Me.rs232portLabel.AutoSize = True
        Me.rs232portLabel.Location = New System.Drawing.Point(6, 16)
        Me.rs232portLabel.Name = "rs232portLabel"
        Me.rs232portLabel.Size = New System.Drawing.Size(38, 13)
        Me.rs232portLabel.TabIndex = 8
        Me.rs232portLabel.Text = "COM#"
        '
        'rs232CheckboxOpened
        '
        Me.rs232CheckboxOpened.AutoSize = True
        Me.rs232CheckboxOpened.Location = New System.Drawing.Point(84, 14)
        Me.rs232CheckboxOpened.Name = "rs232CheckboxOpened"
        Me.rs232CheckboxOpened.Size = New System.Drawing.Size(64, 17)
        Me.rs232CheckboxOpened.TabIndex = 7
        Me.rs232CheckboxOpened.Text = "Opened"
        Me.rs232CheckboxOpened.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "SimplSerialTool"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DevTestPlatform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 605)
        Me.Controls.Add(Me.rs232Groupbox)
        Me.Controls.Add(Me.coreGroupbox)
        Me.Controls.Add(Me.toolsGroupbox)
        Me.Controls.Add(Me.uartGroupbox)
        Me.Controls.Add(Me.rs485Groupbox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DevTestPlatform"
        Me.Text = "Bwl DevTestPlatform"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.rs485Groupbox, 0)
        Me.Controls.SetChildIndex(Me.uartGroupbox, 0)
        Me.Controls.SetChildIndex(Me.toolsGroupbox, 0)
        Me.Controls.SetChildIndex(Me.coreGroupbox, 0)
        Me.Controls.SetChildIndex(Me.rs232Groupbox, 0)
        Me.rs485Groupbox.ResumeLayout(False)
        Me.rs485Groupbox.PerformLayout()
        Me.uartGroupbox.ResumeLayout(False)
        Me.uartGroupbox.PerformLayout()
        Me.toolsGroupbox.ResumeLayout(False)
        Me.coreGroupbox.ResumeLayout(False)
        Me.rs232Groupbox.ResumeLayout(False)
        Me.rs232Groupbox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statesList As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents rs485Groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents rs485CheckboxOpened As System.Windows.Forms.CheckBox
    Friend WithEvents rs485portLabel As System.Windows.Forms.Label
    Friend WithEvents uartGroupbox As System.Windows.Forms.GroupBox
    Friend WithEvents uartPortLabel As System.Windows.Forms.Label
    Friend WithEvents uartCheckboxOpened As System.Windows.Forms.CheckBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents toolsGroupbox As System.Windows.Forms.GroupBox
    Friend WithEvents coreGroupbox As System.Windows.Forms.GroupBox
    Friend WithEvents rs232Groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents rs232portLabel As System.Windows.Forms.Label
    Friend WithEvents rs232CheckboxOpened As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
