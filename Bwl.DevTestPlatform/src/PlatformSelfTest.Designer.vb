<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlatformSelfTest
    Inherits Bwl.DevTestPlatform.ProdAppBase

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlatformSelfTest))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.operationsGroup.SuspendLayout()
        Me.selectedOperaionGroup.SuspendLayout()
        Me.cycleGroup.SuspendLayout()
        Me.prepareGroup.SuspendLayout()
        CType(Me.infoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.imageGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'operationsGroup
        '
        Me.operationsGroup.Controls.Add(Me.Button5)
        Me.operationsGroup.Controls.Add(Me.Button1)
        Me.operationsGroup.Controls.Add(Me.Button23)
        Me.operationsGroup.Controls.Add(Me.Button26)
        Me.operationsGroup.Controls.Add(Me.Button9)
        Me.operationsGroup.Controls.Add(Me.Button2)
        Me.operationsGroup.Controls.Add(Me.Button17)
        Me.operationsGroup.Controls.Add(Me.Button15)
        Me.operationsGroup.Controls.Add(Me.Button4)
        Me.operationsGroup.Controls.Add(Me.Button24)
        Me.operationsGroup.Controls.Add(Me.Button6)
        Me.operationsGroup.Controls.Add(Me.Button8)
        Me.operationsGroup.Controls.Add(Me.Button16)
        Me.operationsGroup.Controls.Add(Me.Button13)
        Me.operationsGroup.Controls.Add(Me.Button10)
        Me.operationsGroup.Controls.Add(Me.Button18)
        Me.operationsGroup.Controls.Add(Me.Button22)
        Me.operationsGroup.Controls.Add(Me.Button12)
        Me.operationsGroup.Controls.Add(Me.Button20)
        Me.operationsGroup.Controls.Add(Me.Button21)
        Me.operationsGroup.Controls.Add(Me.Button14)
        Me.operationsGroup.Controls.Add(Me.Button25)
        Me.operationsGroup.Controls.Add(Me.Button19)
        Me.operationsGroup.Controls.Add(Me.Button11)
        Me.operationsGroup.Controls.Add(Me.Button3)
        Me.operationsGroup.Controls.Add(Me.Button7)
        Me.operationsGroup.Size = New System.Drawing.Size(413, 227)
        '
        'selectedOperaionGroup
        '
        Me.selectedOperaionGroup.Location = New System.Drawing.Point(640, 12)
        Me.selectedOperaionGroup.Size = New System.Drawing.Size(338, 164)
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(8, 259)
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(970, 359)
        '
        'testNext
        '
        Me.testNext.Location = New System.Drawing.Point(244, 129)
        '
        'testCancel
        '
        Me.testCancel.Location = New System.Drawing.Point(6, 129)
        '
        'testMsg
        '
        Me.testMsg.Location = New System.Drawing.Point(6, 17)
        Me.testMsg.Size = New System.Drawing.Size(326, 109)
        '
        'cycleGroup
        '
        Me.cycleGroup.Location = New System.Drawing.Point(12, 161)
        Me.cycleGroup.Size = New System.Drawing.Size(203, 78)
        Me.cycleGroup.Text = "Управление"
        '
        'infoPicture
        '
        Me.infoPicture.Size = New System.Drawing.Size(320, 32)
        '
        'infoImageLabel
        '
        Me.infoImageLabel.Location = New System.Drawing.Point(6, 15)
        Me.infoImageLabel.Size = New System.Drawing.Size(320, 36)
        '
        'infoImageName
        '
        Me.infoImageName.Size = New System.Drawing.Size(320, 23)
        '
        'cycleNewDeviceButton
        '
        Me.cycleNewDeviceButton.Text = "Начать заново"
        '
        'imageGroup
        '
        Me.imageGroup.Location = New System.Drawing.Point(640, 182)
        Me.imageGroup.Size = New System.Drawing.Size(332, 57)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Tag = "5"
        Me.Button1.Text = "DevName"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 47)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Tag = "1"
        Me.Button2.Text = "Ports List"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(88, 47)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Tag = "2"
        Me.Button3.Text = "UART"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(168, 47)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Tag = "3"
        Me.Button4.Text = "RS232"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(249, 47)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Tag = "4"
        Me.Button5.Text = "RS485"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(5, 76)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 6
        Me.Button6.Tag = "6"
        Me.Button6.Text = "Vol1 15V"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(86, 76)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 7
        Me.Button7.Tag = "7"
        Me.Button7.Text = "Vol1 5V"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(167, 76)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 8
        Me.Button8.Tag = "8"
        Me.Button8.Text = "Vol1 1V"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(167, 105)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 11
        Me.Button9.Tag = "11"
        Me.Button9.Text = "Vol2 1V"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(86, 105)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 10
        Me.Button10.Tag = "10"
        Me.Button10.Text = "Vol2 5V"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(5, 105)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 9
        Me.Button11.Tag = "9"
        Me.Button11.Text = "Vol2 15V"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(5, 134)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(75, 23)
        Me.Button14.TabIndex = 12
        Me.Button14.Tag = "12"
        Me.Button14.Text = "Cur1 3A"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(86, 134)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 23)
        Me.Button12.TabIndex = 13
        Me.Button12.Tag = "13"
        Me.Button12.Text = "Cur1 500mA"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(5, 163)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 23)
        Me.Button13.TabIndex = 14
        Me.Button13.Text = "Relay1"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(6, 192)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(75, 23)
        Me.Button15.TabIndex = 15
        Me.Button15.Text = "Digital1"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(86, 192)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(21, 23)
        Me.Button16.TabIndex = 16
        Me.Button16.Text = "2"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(113, 192)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(21, 23)
        Me.Button17.TabIndex = 17
        Me.Button17.Text = "3"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(167, 192)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(21, 23)
        Me.Button18.TabIndex = 19
        Me.Button18.Text = "5"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(140, 192)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(21, 23)
        Me.Button19.TabIndex = 18
        Me.Button19.Text = "4"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(221, 192)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(21, 23)
        Me.Button20.TabIndex = 21
        Me.Button20.Text = "7"
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(194, 192)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(21, 23)
        Me.Button21.TabIndex = 20
        Me.Button21.Text = "6"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(275, 192)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(21, 23)
        Me.Button22.TabIndex = 23
        Me.Button22.Text = "9"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(248, 192)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(21, 23)
        Me.Button23.TabIndex = 22
        Me.Button23.Text = "8"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Button25
        '
        Me.Button25.Location = New System.Drawing.Point(302, 192)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(30, 23)
        Me.Button25.TabIndex = 24
        Me.Button25.Text = "10"
        Me.Button25.UseVisualStyleBackColor = True
        '
        'Button24
        '
        Me.Button24.Location = New System.Drawing.Point(338, 192)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(30, 23)
        Me.Button24.TabIndex = 25
        Me.Button24.Text = "11"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'Button26
        '
        Me.Button26.Location = New System.Drawing.Point(374, 192)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(30, 23)
        Me.Button26.TabIndex = 26
        Me.Button26.Text = "12"
        Me.Button26.UseVisualStyleBackColor = True
        '
        'PlatformSelfTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 623)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PlatformSelfTest"
        Me.Text = "Самотестирование  платформы"
        Me.operationsGroup.ResumeLayout(False)
        Me.selectedOperaionGroup.ResumeLayout(False)
        Me.cycleGroup.ResumeLayout(False)
        Me.prepareGroup.ResumeLayout(False)
        CType(Me.infoPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.imageGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button26 As System.Windows.Forms.Button

End Class
