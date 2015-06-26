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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProdAppBase))
        Me.DatagridLogWriter1 = New Bwl.Framework.DatagridLogWriter()
        Me.operationsGroup = New System.Windows.Forms.GroupBox()
        Me.selectedOperaionGroup = New System.Windows.Forms.GroupBox()
        Me.testMsg = New System.Windows.Forms.Label()
        Me.testNext = New System.Windows.Forms.Button()
        Me.testCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.selectedOperaionGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'DatagridLogWriter1
        '
        Me.DatagridLogWriter1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatagridLogWriter1.FilterText = ""
        Me.DatagridLogWriter1.Location = New System.Drawing.Point(8, 285)
        Me.DatagridLogWriter1.LogEnabled = True
        Me.DatagridLogWriter1.Margin = New System.Windows.Forms.Padding(0)
        Me.DatagridLogWriter1.Name = "DatagridLogWriter1"
        Me.DatagridLogWriter1.ShowDebug = False
        Me.DatagridLogWriter1.ShowErrors = True
        Me.DatagridLogWriter1.ShowInformation = True
        Me.DatagridLogWriter1.ShowMessages = True
        Me.DatagridLogWriter1.ShowWarnings = True
        Me.DatagridLogWriter1.Size = New System.Drawing.Size(862, 302)
        Me.DatagridLogWriter1.TabIndex = 0
        '
        'operationsGroup
        '
        Me.operationsGroup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.operationsGroup.Location = New System.Drawing.Point(8, 12)
        Me.operationsGroup.Name = "operationsGroup"
        Me.operationsGroup.Size = New System.Drawing.Size(438, 255)
        Me.operationsGroup.TabIndex = 0
        Me.operationsGroup.TabStop = False
        Me.operationsGroup.Text = "Операции"
        '
        'selectedOperaionGroup
        '
        Me.selectedOperaionGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.selectedOperaionGroup.Controls.Add(Me.testMsg)
        Me.selectedOperaionGroup.Controls.Add(Me.testNext)
        Me.selectedOperaionGroup.Controls.Add(Me.testCancel)
        Me.selectedOperaionGroup.Location = New System.Drawing.Point(452, 75)
        Me.selectedOperaionGroup.Name = "selectedOperaionGroup"
        Me.selectedOperaionGroup.Size = New System.Drawing.Size(418, 192)
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
        Me.testMsg.Location = New System.Drawing.Point(6, 19)
        Me.testMsg.Name = "testMsg"
        Me.testMsg.Size = New System.Drawing.Size(406, 137)
        Me.testMsg.TabIndex = 0
        Me.testMsg.Text = "..."
        '
        'testNext
        '
        Me.testNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testNext.Location = New System.Drawing.Point(337, 159)
        Me.testNext.Name = "testNext"
        Me.testNext.Size = New System.Drawing.Size(75, 23)
        Me.testNext.TabIndex = 0
        Me.testNext.Text = "Дальше"
        Me.testNext.UseVisualStyleBackColor = True
        Me.testNext.Visible = False
        '
        'testCancel
        '
        Me.testCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.testCancel.Location = New System.Drawing.Point(6, 159)
        Me.testCancel.Name = "testCancel"
        Me.testCancel.Size = New System.Drawing.Size(75, 23)
        Me.testCancel.TabIndex = 0
        Me.testCancel.Text = "Отмена"
        Me.testCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(452, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(418, 57)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Информация"
        '
        'ProdAppBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 590)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.selectedOperaionGroup)
        Me.Controls.Add(Me.operationsGroup)
        Me.Controls.Add(Me.DatagridLogWriter1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProdAppBase"
        Me.Text = "Производственные операции"
        Me.selectedOperaionGroup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents operationsGroup As System.Windows.Forms.GroupBox
    Protected WithEvents selectedOperaionGroup As System.Windows.Forms.GroupBox
    Protected WithEvents DatagridLogWriter1 As Bwl.Framework.DatagridLogWriter
    Protected WithEvents testNext As System.Windows.Forms.Button
    Protected WithEvents testCancel As System.Windows.Forms.Button
    Protected WithEvents testMsg As System.Windows.Forms.Label
    Protected WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
