Imports Emgu.CV
Imports Emgu.CV.CvEnum

Public Class AntWindow
    Public y As Integer = 50
    Public rotation As Integer = 0
    Public AntList As New List(Of Ant)
    Public r As Random = New Random
    Public AntsToRemove As New List(Of Integer)
    Public showCalibrationWindow As Boolean = False
    Private Const NR_OF_antRunImg As Integer = 33
    Private antRunRedImg(NR_OF_antRunImg) As Image
    Private antRunBrownImg(NR_OF_antRunImg) As Image
    Private antRunGrayImg(NR_OF_antRunImg) As Image
    Private Const NR_OF_Explosion1 As Integer = 19
    Private Explosion1Img(NR_OF_Explosion1) As Image
    Private Const NR_OF_Explosion2 As Integer = 22
    Private Explosion2Img(NR_OF_Explosion2) As Image
    Private Const NR_OF_Explosion3 As Integer = 26
    Private Explosion3Img(NR_OF_Explosion3) As Image

    Private Sub AntWindow_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        If Me.WindowState = FormWindowState.Normal Then
            My.Forms.AntWindow.WindowState = FormWindowState.Maximized
            My.Forms.AntWindow.FormBorderStyle = FormBorderStyle.None
        Else
            My.Forms.AntWindow.WindowState = FormWindowState.Normal
            My.Forms.AntWindow.FormBorderStyle = FormBorderStyle.SizableToolWindow
        End If
    End Sub
    Private Sub AntWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim resourcePath As String
        'resourcePath = IO.Path.GetFullPath(Application.StartupPath).
        'load image files under resources
        'red ant running
        For i = 0 To NR_OF_antRunImg - 1
            antRunRedImg(i) = Image.FromFile("..\..\Resources\Ant_Running_Red_frame_" + (i + 1).ToString.PadLeft(4, "0"c) + ".png")
        Next
        'brown ant running
        For i = 0 To NR_OF_antRunImg - 1
            antRunBrownImg(i) = Image.FromFile("..\..\Resources\Ant_Running_Brown_frame_" + (i + 1).ToString.PadLeft(4, "0"c) + ".gif")
        Next
        'gray ant running
        For i = 0 To NR_OF_antRunImg - 1
            antRunGrayImg(i) = Image.FromFile("..\..\Resources\Ant_Running_Gray_small_frame_" + (i + 1).ToString.PadLeft(4, "0"c) + ".gif")
        Next
        'explosion1
        For i = 0 To NR_OF_Explosion1 - 1
            Explosion1Img(i) = Image.FromFile("..\..\Resources\Explosion1_frame_" + (i + 1).ToString.PadLeft(4, "0"c) + ".png")
        Next
        'explosion2
        For i = 0 To NR_OF_Explosion2 - 1
            Explosion2Img(i) = Image.FromFile("..\..\Resources\Explosion2_frame_" + (i + 1).ToString.PadLeft(4, "0"c) + ".gif")
        Next
        'explosion2
        For i = 0 To NR_OF_Explosion3 - 1
            Explosion3Img(i) = Image.FromFile("..\..\Resources\Explosion3_frame_" + (i + 1).ToString.PadLeft(4, "0"c) + ".gif")
        Next

        'Dim A As Ant = New Ant(50, 50, 0, New Random, 10, 10, NR_OF_Explosion1 - 1)
        'initialise ant with position, rotation etc
        'AntList.Add(New Ant(50, 50, 0, New Random(AntList.Count), 10, 10, NR_OF_Explosion1 - 1))
        'AntList.Add(New Ant(300, 50, 0, New Random(AntList.Count), 10, 10, NR_OF_Explosion1 - 1))
        'AntList.Add(New Ant(500, 50, 0, New Random(AntList.Count), 10, 10, NR_OF_Explosion1 - 1))
        'AntList.Add(New Ant(1200, 360, GetRotationToCenter(1280, 360, 640, 360), New Random(AntList.Count), 10, 10, NR_OF_Explosion1 - 1))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim canvas As Bitmap = New Bitmap(My.Forms.AntWindow.Width, My.Forms.AntWindow.Height)

        'show calibration image on 1280, 720 with 4 corners green
        If showCalibrationWindow = True Then
            Dim myBrush As Brush = New SolidBrush(Drawing.Color.Cyan)
            Using g As Graphics = Graphics.FromImage(canvas)
                g.FillRectangle(myBrush, 0, 0, 40, 40)
                g.FillRectangle(myBrush, 1240, 0, 40, 40)
                g.FillRectangle(myBrush, 1240, 680, 40, 40)
                g.FillRectangle(myBrush, 0, 680, 40, 40)
            End Using
            My.Forms.AntWindow.BackgroundImage = canvas
            Exit Sub
        End If
        'generate new ants
        If AntList.Count < 15 Then
            SummonNewAnt()
        End If

        Dim antIndex As Integer = 0
        For Each ant In AntList


            'draw ant or explosion on canvas
            Using g As Graphics = Graphics.FromImage(canvas)
                If ant.bIsDying = False Then
                    Select Case ant.type
                        Case Ant.antType.Red
                            g.DrawImage(RotateImage(antRunRedImg(ant.stepsToWalk), ant.rotation), ant.x, ant.y)
                        Case Ant.antType.Gray
                            g.DrawImage(RotateImage(antRunGrayImg(ant.stepsToWalk), ant.rotation), ant.x, ant.y)
                        Case Ant.antType.Brown
                            g.DrawImage(RotateImage(antRunBrownImg(ant.stepsToWalk), ant.rotation), ant.x, ant.y)
                    End Select

                Else
                    Try 'sometimes stepsToExplode = -1?
                        Select Case ant.type
                            Case Ant.antType.Red
                                g.DrawImage(Explosion1Img(NR_OF_Explosion1 - ant.stepsToExplode), ant.x + 40, ant.y + 20)
                            Case Ant.antType.Gray
                                g.DrawImage(Explosion3Img(NR_OF_Explosion3 - ant.stepsToExplode), ant.x - 10, ant.y - 45)
                            Case Ant.antType.Brown
                                g.DrawImage(Explosion2Img(NR_OF_Explosion2 - ant.stepsToExplode), ant.x + 10, ant.y)
                        End Select

                    Catch ex As Exception
                    End Try

                End If
            End Using

            'draw detected sunspot
            If AntAntics.sunSpots IsNot Nothing Then
                Dim myPen1 As Pen = New Pen(Drawing.Color.Pink, 1)
                For Each spot In AntAntics.sunSpots
                    Using g As Graphics = Graphics.FromImage(canvas)
                        g.DrawRectangle(myPen1, spot.X, spot.Y, 3, 3)
                    End Using
                Next
            End If
            'an ant walks until stepsToWalk reaches 0, then it will rest until stepsToRest is 0
            If ant.bIsDying = False Then
                If ant.bIsWalking AndAlso ant.stepsToWalk = 0 Then 'reached end of walk
                    Dim r = New Random
                    ant.stepsToRest = r.Next(0, 5)
                    ant.bIsWalking = False
                ElseIf ant.bIsWalking AndAlso ant.stepsToWalk >= 1 Then 'it is walking
                    ant.stepsToWalk = ant.stepsToWalk - 1
                    Dim newLocation As Point = GetNewPoint(ant.x, ant.y, ant.rotation, ant.stepSize)
                    ant.x = newLocation.X
                    ant.y = newLocation.Y
                End If
                If ant.bIsWalking = False AndAlso ant.stepsToRest = 0 Then 'reached end of rest
                    Dim r = New Random
                    ant.stepsToWalk = r.Next(10, 33)
                    ant.rotation = GetNewRotation(ant.rotation, ant.ranGen)
                    ant.bIsWalking = True
                ElseIf ant.bIsWalking = False AndAlso ant.stepsToRest >= 1 Then 'it is resting
                    ant.stepsToRest = ant.stepsToRest - 1
                End If
            End If
            'mark ant for deletion if it is completely outside window 1280x720 for too many steps
            If ant.x < -50 Or ant.x > 1280 Or ant.y < -20 Or ant.y > 750 Then
                ant.stepsToDie = ant.stepsToDie + 1
            End If
            If ant.stepsToDie > 200 Then
                AntsToRemove.Add(antIndex)
            End If

            'check collision of sunspot with ant
            'if spot is inside rectangle of image
            Dim antRect As Rectangle = New Rectangle(ant.x + 80, ant.y + 70, 45, 45) 'get rectangle from ant starts at x,y and extends with image
            Select Case ant.type
                Case Ant.antType.Red
                    antRect = New Rectangle(ant.x + 80, ant.y + 70, 45, 45) 'get rectangle from ant starts at x,y and extends with image
                Case Ant.antType.Brown
                    antRect = New Rectangle(ant.x + 70, ant.y + 50, 80, 80) 'bigger hitbox because ant is bigger
                Case Ant.antType.Gray
                    antRect = New Rectangle(ant.x + 35, ant.y + 25, 40, 40) 'smaller hitbox because ant is smaller
            End Select
            Dim myPen As Pen = New Pen(Drawing.Color.Green, 1)
            Using g As Graphics = Graphics.FromImage(canvas)
                'g.DrawRectangle(myPen, antRect)
            End Using
            For Each spot In AntAntics.sunSpots

                If antRect.Contains(spot) Then
                    'Dim myPen1 As Pen = New Pen(Drawing.Color.OrangeRed, 1)
                    Dim burnsize As Integer = r.Next(5, 15)
                    Using g As Graphics = Graphics.FromImage(canvas)
                        g.FillEllipse(Brushes.OrangeRed, spot.X, spot.Y, burnsize, burnsize)
                    End Using

                    ant.HealthPoints = ant.HealthPoints - 1 'decrease life
                    If ant.HealthPoints < 0 AndAlso ant.bIsDying = False Then ant.bIsDying = True 'life reached 0, let it die
                End If
            Next

            'when explosion animation is done, remove ant
            If ant.bIsDying Then ant.stepsToExplode = ant.stepsToExplode - 1
            If ant.stepsToExplode < 1 Then AntsToRemove.Add(antIndex)

            antIndex = antIndex + 1
        Next 'ant



        'actually delete ants from list
        AntsToRemove.Sort()
        AntsToRemove.Reverse()
        For Each a In AntsToRemove
            AntList.Remove(AntList.Item(a))
        Next
        AntsToRemove.Clear()





        'update form with drawn ants
        If My.Forms.AntWindow.BackgroundImage IsNot Nothing Then My.Forms.AntWindow.BackgroundImage.Dispose()
        My.Forms.AntWindow.BackgroundImage = canvas
    End Sub

    Private Sub SummonNewAnt()
        r = New Random
        Dim randomX As Integer
        Dim randomY As Integer

        Select Case r.Next(0, 4)
            Case 0 'coming from left side
                randomX = r.Next(0, 200) - 300
                randomY = r.Next(0, 720)
            Case 1 'coming from bottom side
                randomX = r.Next(0, 1280)
                randomY = r.Next(720, 820) + 150
            Case 2 'coming from right side
                randomX = r.Next(1280, 1480) + 150
                randomY = r.Next(0, 720)
            Case 3 'coming from top side
                randomX = r.Next(0, 1280)
                randomY = r.Next(0, 100) - 200
        End Select
        Dim newType As Ant.antType
        Dim antspeed As Integer
        Dim stepsToExplode As Integer = 1
        Dim lifepoints As Integer = 10
        r = New Random
        Select Case r.Next(0, 4)
            Case 0
                newType = Ant.antType.Gray
                antspeed = r.Next(6, 20)
                stepsToExplode = NR_OF_Explosion3
                lifepoints = 4
            Case 1
                newType = Ant.antType.Gray
                antspeed = r.Next(4, 14)
                stepsToExplode = NR_OF_Explosion3
                lifepoints = 3
            Case 2
                newType = Ant.antType.Red
                antspeed = r.Next(5, 16)
                stepsToExplode = NR_OF_Explosion1
                lifepoints = 10
            Case 3
                newType = Ant.antType.Brown
                antspeed = r.Next(3, 8)
                stepsToExplode = NR_OF_Explosion2
                lifepoints = 20
        End Select

        AntList.Add(New Ant(newType, randomX, randomY, GetRotationToCenter(randomX, randomY, 640, 360), New Random(AntList.Count), 10, 10, stepsToExplode, antspeed, lifepoints))
    End Sub

    ''' get rotation angle to center point so ants will start out walking to center
    Public Function GetRotationToCenter(x As Integer, y As Integer, CenterX As Integer, CenterY As Integer) As Integer
        'To convert degrees to radians, multiply degrees by pi/180
        Return CInt(Math.Atan2((CenterY - y), (CenterX - x)) * 180 / Math.PI)
    End Function
    ''' <summary>
    ''' get new point when we know the previous location, distance to travel and direction/rotation
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="rotation"></param>
    ''' <param name="distance"></param>
    ''' <returns></returns>
    Public Function GetNewPoint(x As Integer, y As Integer, rotation As Integer, distance As Integer) As Point
        Dim newLoc As Point = New Point
        'To convert degrees to radians, multiply degrees by pi/180
        newLoc.X = distance * Math.Cos(rotation * Math.PI / 180) + x
        newLoc.Y = distance * Math.Sin(rotation * Math.PI / 180) + y
        Return newLoc
    End Function
    ''' <summary>
    ''' Get a new rotation (0-359), close to the current one, with a preference to the current rotation
    ''' </summary>
    ''' <param name="CurrentRotation"></param>
    ''' <returns></returns>
    Public Function GetNewRotation(CurrentRotation As Integer, r As Random) As Integer

        Dim change As Integer = 0
        Dim NewRotation As Integer = 0
        Select Case r.Next(0, 7)
            Case 0 : change = -30
            Case 1 : change = -15
            Case 2, 3, 4 : change = 0
            Case 5 : change = 15
            Case 6 : change = 30
        End Select
        NewRotation = CurrentRotation + change
        If NewRotation > 359 Then NewRotation = NewRotation - 359
        If NewRotation < 0 Then NewRotation = NewRotation + 359
        Return NewRotation
    End Function
    Public Function RotateImage(imgToRotate As Bitmap, angle As Double) As Bitmap
        Dim rotatedImage As Bitmap = New Bitmap(imgToRotate.Width, imgToRotate.Height)
        Using g = Graphics.FromImage(rotatedImage)
            ' Set the rotation point to the center in the matrix
            g.TranslateTransform(imgToRotate.Width / 2, imgToRotate.Height / 2)
            ' Rotate
            g.RotateTransform(angle)
            ' Restore rotation point in the matrix
            g.TranslateTransform(-imgToRotate.Width / 2, -imgToRotate.Height / 2)
            ' Draw the image on the bitmap
            g.DrawImage(imgToRotate, New Point(0, 0))
        End Using
        Return rotatedImage
    End Function
End Class