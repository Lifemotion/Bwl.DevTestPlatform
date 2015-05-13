<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevTest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevTest))
        Me.statesList = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.scriptGroupbox = New System.Windows.Forms.GroupBox()
        Me.CodeExecutor1 = New Bwl.DevTestPlatform.CodeExecutor2()
        Me.rs485Groupbox = New System.Windows.Forms.GroupBox()
        Me.rs485portLabel = New System.Windows.Forms.Label()
        Me.rs485CheckboxOpened = New System.Windows.Forms.CheckBox()
        Me.uartGroupbox = New System.Windows.Forms.GroupBox()
        Me.uartPortLabel = New System.Windows.Forms.Label()
        Me.uartCheckboxOpened = New System.Windows.Forms.CheckBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.toolsGroupbox = New System.Windows.Forms.GroupBox()
        Me.coreGroupbox = New System.Windows.Forms.GroupBox()
        Me.scriptGroupbox.SuspendLayout()
        Me.rs485Groupbox.SuspendLayout()
        Me.uartGroupbox.SuspendLayout()
        Me.toolsGroupbox.SuspendLayout()
        Me.coreGroupbox.SuspendLayout()
        Me.SuspendLayout()
        '
        'logWriter
        '
        Me.logWriter.Location = New System.Drawing.Point(2, 342)
        Me.logWriter.Size = New System.Drawing.Size(889, 322)
        '
        'statesList
        '
        Me.statesList.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.statesList.FormattingEnabled = True
        Me.statesList.Location = New System.Drawing.Point(6, 19)
        Me.statesList.Name = "statesList"
        Me.statesList.Size = New System.Drawing.Size(168, 277)
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
        Me.Button3.Location = New System.Drawing.Point(9, 48)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(147, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Internal SimplSerial"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(9, 19)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(147, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "SimplSerial"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(9, 77)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(147, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "SelfTest"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'scriptGroupbox
        '
        Me.scriptGroupbox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scriptGroupbox.Controls.Add(Me.CodeExecutor1)
        Me.scriptGroupbox.Location = New System.Drawing.Point(201, 27)
        Me.scriptGroupbox.Name = "scriptGroupbox"
        Me.scriptGroupbox.Size = New System.Drawing.Size(511, 303)
        Me.scriptGroupbox.TabIndex = 11
        Me.scriptGroupbox.TabStop = False
        Me.scriptGroupbox.Text = "Script"
        '
        'CodeExecutor1
        '
        Me.CodeExecutor1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodeExecutor1.ImportsList = CType(resources.GetObject("CodeExecutor1.ImportsList"), System.Collections.Generic.List(Of String))
        Me.CodeExecutor1.Location = New System.Drawing.Point(0, 16)
        Me.CodeExecutor1.Name = "CodeExecutor1"
        Me.CodeExecutor1.ReferencesList = CType(resources.GetObject("CodeExecutor1.ReferencesList"), System.Collections.Generic.List(Of String))
        Me.CodeExecutor1.Size = New System.Drawing.Size(507, 287)
        Me.CodeExecutor1.SourceText = ""
        Me.CodeExecutor1.TabIndex = 0
        Me.CodeExecutor1.Template = "Imports Bwl.Hardware.SimplSerial.SimplSerialBus'importsPublic Class TestProgram'c" & _
    "odeEnd Class"
        '
        'rs485Groupbox
        '
        Me.rs485Groupbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rs485Groupbox.Controls.Add(Me.rs485portLabel)
        Me.rs485Groupbox.Controls.Add(Me.rs485CheckboxOpened)
        Me.rs485Groupbox.Controls.Add(Me.Button2)
        Me.rs485Groupbox.Enabled = False
        Me.rs485Groupbox.Location = New System.Drawing.Point(718, 27)
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
        Me.uartGroupbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.uartGroupbox.Controls.Add(Me.uartPortLabel)
        Me.uartGroupbox.Controls.Add(Me.uartCheckboxOpened)
        Me.uartGroupbox.Controls.Add(Me.Button6)
        Me.uartGroupbox.Enabled = False
        Me.uartGroupbox.Location = New System.Drawing.Point(718, 98)
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
        Me.toolsGroupbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toolsGroupbox.Controls.Add(Me.Button5)
        Me.toolsGroupbox.Controls.Add(Me.Button3)
        Me.toolsGroupbox.Controls.Add(Me.Button4)
        Me.toolsGroupbox.Location = New System.Drawing.Point(718, 169)
        Me.toolsGroupbox.Name = "toolsGroupbox"
        Me.toolsGroupbox.Size = New System.Drawing.Size(162, 161)
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
        Me.coreGroupbox.Size = New System.Drawing.Size(183, 303)
        Me.coreGroupbox.TabIndex = 14
        Me.coreGroupbox.TabStop = False
        Me.coreGroupbox.Text = "TestBoxCore"
        '
        'DevTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 665)
        Me.Controls.Add(Me.coreGroupbox)
        Me.Controls.Add(Me.toolsGroupbox)
        Me.Controls.Add(Me.uartGroupbox)
        Me.Controls.Add(Me.rs485Groupbox)
        Me.Controls.Add(Me.scriptGroupbox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MaximizeBox = True
        Me.Name = "DevTest"
        Me.Text = "Bwl DevTestPlatform"
        Me.Controls.SetChildIndex(Me.logWriter, 0)
        Me.Controls.SetChildIndex(Me.scriptGroupbox, 0)
        Me.Controls.SetChildIndex(Me.rs485Groupbox, 0)
        Me.Controls.SetChildIndex(Me.uartGroupbox, 0)
        Me.Controls.SetChildIndex(Me.toolsGroupbox, 0)
        Me.Controls.SetChildIndex(Me.coreGroupbox, 0)
        Me.scriptGroupbox.ResumeLayout(False)
        Me.rs485Groupbox.ResumeLayout(False)
        Me.rs485Groupbox.PerformLayout()
        Me.uartGroupbox.ResumeLayout(False)
        Me.uartGroupbox.PerformLayout()
        Me.toolsGroupbox.ResumeLayout(False)
        Me.coreGroupbox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statesList As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents scriptGroupbox As System.Windows.Forms.GroupBox
    Friend WithEvents rs485Groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents rs485CheckboxOpened As System.Windows.Forms.CheckBox
    Friend WithEvents rs485portLabel As System.Windows.Forms.Label
    Friend WithEvents uartGroupbox As System.Windows.Forms.GroupBox
    Friend WithEvents uartPortLabel As System.Windows.Forms.Label
    Friend WithEvents uartCheckboxOpened As System.Windows.Forms.CheckBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents toolsGroupbox As System.Windows.Forms.GroupBox
    Friend WithEvents coreGroupbox As System.Windows.Forms.GroupBox
    Friend WithEvents CodeExecutor1 As Bwl.DevTestPlatform.CodeExecutor2

End Class
