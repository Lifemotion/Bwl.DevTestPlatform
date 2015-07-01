<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProdAppBase
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProdAppBase))
        Me.DatagridLogWriter1 = New Bwl.Framework.DatagridLogWriter()
        Me.operationsGroup = New System.Windows.Forms.GroupBox()
        Me.selectedOperaionGroup = New System.Windows.Forms.GroupBox()
        Me.testMsg = New System.Windows.Forms.Label()
        Me.testNext = New System.Windows.Forms.Button()
        Me.testCancel = New System.Windows.Forms.Button()
        Me.cycleGroup = New System.Windows.Forms.GroupBox()
        Me.cycleNewDeviceButton = New System.Windows.Forms.Button()
        Me.prepareGroup = New System.Windows.Forms.GroupBox()
        Me.prepRestart = New System.Windows.Forms.Button()
        Me.prepMsg = New System.Windows.Forms.Label()
        Me.infoPicture = New System.Windows.Forms.PictureBox()
        Me.checkPreparation = New System.Windows.Forms.Timer(Me.components)
        Me.infoImageLabel = New System.Windows.Forms.Label()
        Me.infoImageName = New System.Windows.Forms.Label()
        Me.imageGroup = New System.Windows.Forms.GroupBox()
        Me.buttonCorrect = New System.Windows.Forms.Button()
        Me.buttonUncorrect = New System.Windows.Forms.Button()
        Me.selectedOperaionGroup.SuspendLayout()
        Me.cycleGroup.SuspendLayout()
        Me.prepareGroup.SuspendLayout()
        CType(Me.infoPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.imageGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(0, 541)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(1007, 152)
        Me.DatagridLogWriter1.TabIndex = 0
        '
        'operationsGroup
        '
        Me.operationsGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.operationsGroup.Enabled = False
        Me.operationsGroup.Location = New System.Drawing.Point(221, 12)
        Me.operationsGroup.Name = "operationsGroup"
        Me.operationsGroup.Size = New System.Drawing.Size(270, 518)
        Me.operationsGroup.TabIndex = 0
        Me.operationsGroup.TabStop = False
        Me.operationsGroup.Text = "Последовательность операций"
        '
        'selectedOperaionGroup
        '
        Me.selectedOperaionGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectedOperaionGroup.Controls.Add(Me.buttonUncorrect)
        Me.selectedOperaionGroup.Controls.Add(Me.buttonCorrect)
        Me.selectedOperaionGroup.Controls.Add(Me.testMsg)
        Me.selectedOperaionGroup.Controls.Add(Me.testNext)
        Me.selectedOperaionGroup.Controls.Add(Me.testCancel)
        Me.selectedOperaionGroup.Location = New System.Drawing.Point(498, 12)
        Me.selectedOperaionGroup.Name = "selectedOperaionGroup"
        Me.selectedOperaionGroup.Size = New System.Drawing.Size(497, 164)
        Me.selectedOperaionGroup.TabIndex = 0
        Me.selectedOperaionGroup.TabStop = False
        Me.selectedOperaionGroup.Text = "Выбранная операция"
        Me.selectedOperaionGroup.Visible = False
        '
        'testMsg
        '
        Me.testMsg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.testMsg.Location = New System.Drawing.Point(6, 21)
        Me.testMsg.Name = "testMsg"
        Me.testMsg.Size = New System.Drawing.Size(485, 97)
        Me.testMsg.TabIndex = 0
        Me.testMsg.Text = "..."
        '
        'testNext
        '
        Me.testNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.testNext.Location = New System.Drawing.Point(405, 121)
        Me.testNext.Name = "testNext"
        Me.testNext.Size = New System.Drawing.Size(86, 33)
        Me.testNext.TabIndex = 0
        Me.testNext.Text = "Дальше"
        Me.testNext.UseVisualStyleBackColor = True
        Me.testNext.Visible = False
        '
        'testCancel
        '
        Me.testCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.testCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.testCancel.Location = New System.Drawing.Point(6, 121)
        Me.testCancel.Name = "testCancel"
        Me.testCancel.Size = New System.Drawing.Size(86, 33)
        Me.testCancel.TabIndex = 0
        Me.testCancel.Text = "Отмена"
        Me.testCancel.UseVisualStyleBackColor = True
        '
        'cycleGroup
        '
        Me.cycleGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cycleGroup.Controls.Add(Me.cycleNewDeviceButton)
        Me.cycleGroup.Enabled = False
        Me.cycleGroup.Location = New System.Drawing.Point(12, 154)
        Me.cycleGroup.Name = "cycleGroup"
        Me.cycleGroup.Size = New System.Drawing.Size(203, 376)
        Me.cycleGroup.TabIndex = 1
        Me.cycleGroup.TabStop = False
        Me.cycleGroup.Text = "Цикл производства"
        '
        'cycleNewDeviceButton
        '
        Me.cycleNewDeviceButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cycleNewDeviceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.cycleNewDeviceButton.Location = New System.Drawing.Point(6, 18)
        Me.cycleNewDeviceButton.Name = "cycleNewDeviceButton"
        Me.cycleNewDeviceButton.Size = New System.Drawing.Size(191, 33)
        Me.cycleNewDeviceButton.TabIndex = 5
        Me.cycleNewDeviceButton.Text = "Новое устройство"
        Me.cycleNewDeviceButton.UseVisualStyleBackColor = True
        '
        'prepareGroup
        '
        Me.prepareGroup.Controls.Add(Me.prepRestart)
        Me.prepareGroup.Controls.Add(Me.prepMsg)
        Me.prepareGroup.Location = New System.Drawing.Point(12, 12)
        Me.prepareGroup.Name = "prepareGroup"
        Me.prepareGroup.Size = New System.Drawing.Size(203, 136)
        Me.prepareGroup.TabIndex = 3
        Me.prepareGroup.TabStop = False
        Me.prepareGroup.Text = "Подготовка"
        '
        'prepRestart
        '
        Me.prepRestart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prepRestart.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.prepRestart.Location = New System.Drawing.Point(6, 97)
        Me.prepRestart.Name = "prepRestart"
        Me.prepRestart.Size = New System.Drawing.Size(191, 33)
        Me.prepRestart.TabIndex = 4
        Me.prepRestart.Text = "Проверить заново"
        Me.prepRestart.UseVisualStyleBackColor = True
        Me.prepRestart.Visible = False
        '
        'prepMsg
        '
        Me.prepMsg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prepMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.prepMsg.Location = New System.Drawing.Point(6, 16)
        Me.prepMsg.Name = "prepMsg"
        Me.prepMsg.Size = New System.Drawing.Size(197, 111)
        Me.prepMsg.TabIndex = 3
        Me.prepMsg.Text = "Ожидание проверки готовности..."
        Me.prepMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'infoPicture
        '
        Me.infoPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoPicture.Location = New System.Drawing.Point(6, 19)
        Me.infoPicture.Name = "infoPicture"
        Me.infoPicture.Size = New System.Drawing.Size(485, 323)
        Me.infoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.infoPicture.TabIndex = 4
        Me.infoPicture.TabStop = False
        Me.infoPicture.WaitOnLoad = True
        '
        'checkPreparation
        '
        Me.checkPreparation.Enabled = True
        '
        'infoImageLabel
        '
        Me.infoImageLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoImageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.infoImageLabel.Location = New System.Drawing.Point(6, 306)
        Me.infoImageLabel.Name = "infoImageLabel"
        Me.infoImageLabel.Size = New System.Drawing.Size(485, 36)
        Me.infoImageLabel.TabIndex = 5
        Me.infoImageLabel.Text = "Щелчок по картинке - следующее изображение" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Щелчок по надписи - открыть в отдельн" & _
    "ом окне"
        Me.infoImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'infoImageName
        '
        Me.infoImageName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.infoImageName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.infoImageName.Location = New System.Drawing.Point(6, 19)
        Me.infoImageName.Name = "infoImageName"
        Me.infoImageName.Size = New System.Drawing.Size(485, 23)
        Me.infoImageName.TabIndex = 6
        Me.infoImageName.Text = "..."
        Me.infoImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imageGroup
        '
        Me.imageGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imageGroup.Controls.Add(Me.infoImageName)
        Me.imageGroup.Controls.Add(Me.infoImageLabel)
        Me.imageGroup.Controls.Add(Me.infoPicture)
        Me.imageGroup.Location = New System.Drawing.Point(498, 182)
        Me.imageGroup.Name = "imageGroup"
        Me.imageGroup.Size = New System.Drawing.Size(497, 348)
        Me.imageGroup.TabIndex = 0
        Me.imageGroup.TabStop = False
        Me.imageGroup.Text = "Изображение"
        Me.imageGroup.Visible = False
        '
        'buttonCorrect
        '
        Me.buttonCorrect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCorrect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.buttonCorrect.Location = New System.Drawing.Point(313, 121)
        Me.buttonCorrect.Name = "buttonCorrect"
        Me.buttonCorrect.Size = New System.Drawing.Size(86, 33)
        Me.buttonCorrect.TabIndex = 1
        Me.buttonCorrect.Text = "Верно"
        Me.buttonCorrect.UseVisualStyleBackColor = True
        Me.buttonCorrect.Visible = False
        '
        'buttonUncorrect
        '
        Me.buttonUncorrect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonUncorrect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.buttonUncorrect.Location = New System.Drawing.Point(221, 121)
        Me.buttonUncorrect.Name = "buttonUncorrect"
        Me.buttonUncorrect.Size = New System.Drawing.Size(86, 33)
        Me.buttonUncorrect.TabIndex = 2
        Me.buttonUncorrect.Text = "Не верно"
        Me.buttonUncorrect.UseVisualStyleBackColor = True
        Me.buttonUncorrect.Visible = False
        '
        'ProdAppBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 692)
        Me.Controls.Add(Me.imageGroup)
        Me.Controls.Add(Me.prepareGroup)
        Me.Controls.Add(Me.cycleGroup)
        Me.Controls.Add(Me.selectedOperaionGroup)
        Me.Controls.Add(Me.operationsGroup)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProdAppBase"
        Me.Text = "Производственные операции"
        Me.selectedOperaionGroup.ResumeLayout(False)
        Me.cycleGroup.ResumeLayout(False)
        Me.prepareGroup.ResumeLayout(False)
        CType(Me.infoPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.imageGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents operationsGroup As System.Windows.Forms.GroupBox
    Protected WithEvents selectedOperaionGroup As System.Windows.Forms.GroupBox
    Protected WithEvents DatagridLogWriter1 As Bwl.Framework.DatagridLogWriter
    Protected WithEvents testNext As System.Windows.Forms.Button
    Protected WithEvents testCancel As System.Windows.Forms.Button
    Protected WithEvents testMsg As System.Windows.Forms.Label
    Protected WithEvents cycleGroup As System.Windows.Forms.GroupBox
    Protected WithEvents prepareGroup As System.Windows.Forms.GroupBox
    Protected WithEvents prepRestart As System.Windows.Forms.Button
    Protected WithEvents prepMsg As System.Windows.Forms.Label
    Protected WithEvents infoPicture As System.Windows.Forms.PictureBox
    Protected WithEvents infoImageLabel As System.Windows.Forms.Label
    Protected WithEvents infoImageName As System.Windows.Forms.Label
    Protected WithEvents cycleNewDeviceButton As System.Windows.Forms.Button
    Protected WithEvents imageGroup As System.Windows.Forms.GroupBox
    Friend WithEvents checkPreparation As System.Windows.Forms.Timer
    Protected WithEvents buttonUncorrect As System.Windows.Forms.Button
    Protected WithEvents buttonCorrect As System.Windows.Forms.Button
End Class
