Public Class Form1

    'Declarea variabilelor
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True 'variabilele penru a putea muta mouse-ul
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'mouse in X
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'mouse in Y
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'daca este activa functia drag, atunci do this
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False 'se opreste drag
    End Sub

    
    '##################################################################################
    'Navigare cu mouse pe header
    '##################################################################################
    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        drag = True 'variabilele penru a putea muta mouse-ul
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'mouse in X
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'mouse in Y
    End Sub
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        drag = False 'se opreste drag
    End Sub


    '####################################################
    'Inceput cod program
    'Se mentioneaza faptul ca unele elemente de aici sunt personalizate
    '####################################################

    'Inchide aplicatia
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    'Load form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Adauga coloanele pentru listview
        ListView1.Columns.Add("Nume", 100, HorizontalAlignment.Center)
        ListView1.Columns.Add("Prenume", 100, HorizontalAlignment.Center)
        ListView1.View = View.Details

    End Sub
    'Meniurile
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.ContextAdmin.Show(Me.Label1, New Point(0, 0))
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Me.ContextTombola.Show(Me.Label4, New Point(0, 0))
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.ContextCategorii.Show(Me.Label5, New Point(0, 0))
    End Sub

    'Dialog optiuni
    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub

    'Selectare categorii
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        PicSelected.BackgroundImage = My.Resources.csgo
        txtnumejoc.Text = "Counter-Strike: GO"
        txtcategorie.Text = "Actiune"
        txtproducator.Text = "Valve"
        txtanjoc.Text = "21 aug., 2012"
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        PicSelected.BackgroundImage = My.Resources.css
        txtnumejoc.Text = "Counter-Strike: Source"
        txtcategorie.Text = "Actiune"
        txtproducator.Text = "Valve"
        txtanjoc.Text = "1 nov., 2004"
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        PicSelected.BackgroundImage = My.Resources.cs16
        txtnumejoc.Text = "Counter-Strike: 1.6"
        txtcategorie.Text = "Actiune"
        txtproducator.Text = "Valve"
        txtanjoc.Text = "1 nov., 2000"
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        PicSelected.BackgroundImage = My.Resources.csall
        txtnumejoc.Text = "Pachet complet"
        txtcategorie.Text = "Actiune"
        txtproducator.Text = "Valve"
        txtanjoc.Text = "2000 - 2014"
    End Sub

    'Adauga concurent in ListView
    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        AdaugaUser.Show()
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        'Progressbar
        Timer1.Start()
        
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(1)
        If ProgressBar1.Value = 100 Then

            procestext.Text = "Tombola a luat sfarsit! Avem un castigator :)"
            'Functia random pentru a alege un castigator
            Dim rnd As New Random()
            Dim i As Integer = ListView1.Items.Count
            Dim chosenItem As ListViewItem = ListView1.Items.Item(rnd.Next(i))
            numecastigator.Text = chosenItem.SubItems(0).Text
            prenumecastigator.Text = chosenItem.SubItems(1).Text
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Timer1.Stop()
    End Sub

    Private Sub InchideToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InchideToolStripMenuItem.Click
        Me.Close()
    End Sub

End Class
