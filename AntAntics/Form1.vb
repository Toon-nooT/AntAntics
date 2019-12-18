Imports Emgu.CV
Imports Emgu.CV.UI
Imports Emgu.CV.Structure
Imports Emgu.CV.CvEnum
Imports Emgu.CV.Util
Imports System.IO

Public Class AntAntics
    Public vidcap As VideoCapture = New Emgu.CV.VideoCapture
    Public hsv As Integer
    Public camera_img As Mat = New Mat() 'image grabbed from webcam flipped horizontally
    Public HSV_img As Mat = New Mat() 'camera_img converted to HSV
    Public threshold_img As Mat = New Mat() 'HSV_img tresholded for a certain hue
    Public processed_threshold_img As Mat = New Mat() 'threshold_img with postprocessing
    Public contour_img As Mat = New Mat() 'processed_threshold_img with contour detection
    Public structuringElement As Mat = CvInvoke.GetStructuringElement(ElementShape.Rectangle, New Size(3, 3), New Point(-1, -1))
    Public sunSpots As List(Of Point) = New List(Of Point)
    '# initialzie a list Of coordinates that will be ordered
    '# such that the first entry In the list Is the top-left,
    '# the second entry Is the top-right, the third Is the
    '# bottom-right, And the fourth Is the bottom-left
    Public pTopLeft As Point = New Point
    Public pTopRight As Point = New Point
    Public pBottomRight As Point = New Point
    Public pBottomLeft As Point = New Point
    Public bDoCalibrate As Boolean = False
    Public calibrationRectangle(3) As PointF
    Public destRectangle(3) As PointF '1280x720
    Public mapMatrix As Mat = New Mat()  'for perspective transformation
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Start up the BackgroundWorker1.
        BackgroundWorker1.RunWorkerAsync()
        vidcap.SetCaptureProperty(CapProp.FrameWidth, 1280)
        vidcap.SetCaptureProperty(CapProp.FrameHeight, 720)

        destRectangle(0).X = 0
        destRectangle(0).Y = 0
        destRectangle(1).X = 1279
        destRectangle(1).Y = 0
        destRectangle(2).X = 1279
        destRectangle(2).Y = 719
        destRectangle(3).X = 0
        destRectangle(3).Y = 719


        'calibrationRectangle(0).X = 200
        'calibrationRectangle(0).Y = 200
        'calibrationRectangle(1).X = 800
        'calibrationRectangle(1).Y = 200
        'calibrationRectangle(2).X = 800
        'calibrationRectangle(2).Y = 700
        'calibrationRectangle(3).X = 200
        'calibrationRectangle(3).Y = 700

        AntWindow.Show()

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object,
                                         ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                         Handles BackgroundWorker1.DoWork
        ' Do some time-consuming work on this thread.
        'System.Threading.Thread.Sleep(1000)

        'Dim imagez As Image(Of Bgr, Byte)


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sunSpots.Clear()

        Using camera_img
            camera_img = vidcap.QueryFrame()
            Dim camera_img_clone As Mat = New Mat()
            camera_img_clone = camera_img.Clone()
            'CvInvoke.Flip(camera_img_clone, camera_img, 4) '1 for vertical

            If CheckBoxUseCalibration.Checked Then
                mapMatrix = CvInvoke.GetPerspectiveTransform(calibrationRectangle, destRectangle)
                camera_img_clone = camera_img.Clone()
                CvInvoke.WarpPerspective(camera_img.Clone, camera_img, mapMatrix, New System.Drawing.Size(1279, 719))
            End If
            camera_img_clone.Dispose()


            If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Dispose()
            PictureBox1.Image = camera_img.Bitmap

            Using HSV_img
                HSV_img = New Mat(PictureBox1.Image.Size, DepthType.Cv8U, 3)
                ' Convert camera capture from BGR to HVS
                CvInvoke.CvtColor(camera_img, HSV_img, ColorConversion.Bgr2Hsv)
                Using threshold_img
                    threshold_img = New Mat(PictureBox1.Image.Size, DepthType.Cv8U, 1)
                    ' Threshold the yellow colors only (please adopt the scalar values to whatever values suit your needs)
                    Dim lowerHvalue As Integer = TrackBarH.Value - TrackBarHueTolerance.Value
                    Dim upperHvalue As Integer = TrackBarH.Value + TrackBarHueTolerance.Value
                    If lowerHvalue < 0 Then lowerHvalue = 0
                    If upperHvalue > 179 Then upperHvalue = 179
                    CvInvoke.InRange(HSV_img, New ScalarArray(New MCvScalar(lowerHvalue, TrackBarSMin.Value, TrackBarVMin.Value)), New ScalarArray(New MCvScalar(upperHvalue + 10, TrackBarSMax.Value, TrackBarVMax.Value)), threshold_img)
                    If PictureBox2.Image IsNot Nothing Then PictureBox2.Image.Dispose()
                    PictureBox2.Image = threshold_img.Bitmap
                    Using processed_threshold_img

                        processed_threshold_img = threshold_img 'New Mat(PictureBox1.Image.Size, DepthType.Cv8U, 1)
                        For i = 1 To TrackBarBlur.Value
                            CvInvoke.GaussianBlur(processed_threshold_img, processed_threshold_img, New Size(3, 3), 0)
                        Next

                        'For i = 1 To TrackBarErode.Value
                        CvInvoke.Erode(processed_threshold_img, processed_threshold_img, structuringElement, New Point(-1, -1), TrackBarErode.Value, BorderType.Default, New MCvScalar(0, 0, 0))
                        'Next
                        'For i = 1 To TrackBarDilate.Value
                        CvInvoke.Dilate(processed_threshold_img, processed_threshold_img, structuringElement, New Point(-1, -1), TrackBarDilate.Value, BorderType.Default, New MCvScalar(0, 0, 0))
                        'Next

                        If PictureBox3.Image IsNot Nothing Then PictureBox3.Image.Dispose()
                        PictureBox3.Image = processed_threshold_img.Bitmap

                        Dim contours As VectorOfVectorOfPoint = New VectorOfVectorOfPoint()

                        CvInvoke.FindContours(processed_threshold_img, contours, Nothing, RetrType.External, CvEnum.ChainApproxMethod.ChainApproxNone)
                        'keep only contours that are the right size
                        KeepContoursOfSize(processed_threshold_img, contours, TrackBarMinContour.Value, TrackBarMaxContour.Value, TrackBarMinContour.Value, TrackBarMaxContour.Value)
                        If PictureBox4.Image IsNot Nothing Then PictureBox4.Image.Dispose()
                        PictureBox4.Image = processed_threshold_img.Bitmap
                        'calculate middlepoint
                        Dim m As Moments = New Moments()
                        For IndexContour As Integer = 0 To contours.Size - 1
                            m = CvInvoke.Moments(contours(IndexContour), True)
                            If Not m.M00 = 0 Then
                                Dim cpoint As Point
                                cpoint.X = m.M10 / m.M00
                                cpoint.Y = m.M01 / m.M00
                                sunSpots.Add(cpoint)
                                CvInvoke.Circle(camera_img, cpoint, 10, New MCvScalar(255, 0, 0), 3)
                            End If
                        Next
                        contours.Dispose()
                        If PictureBox5.Image IsNot Nothing Then PictureBox5.Image.Dispose()
                        PictureBox5.Image = camera_img.Bitmap

                        If bDoCalibrate Then DoCalibration()


                    End Using 'processed_threshold_img
                End Using 'threshold_img
            End Using 'HSV_img
            'camera_img.Dispose()
        End Using 'camera_img

    End Sub

    Private Sub DoCalibration()
        'try to find calibration points
        If sunSpots.Count = 4 Then
            pTopLeft = sunSpots(0)
            pTopRight = sunSpots(1)
            pBottomRight = sunSpots(2)
            pBottomLeft = sunSpots(3)
            '# the top-left point will have the smallest sum, whereas
            '# the bottom-right point will have the largest sum
            Dim largestSunspot As Integer = 0
            Dim largestSunspotSum As Integer = sunSpots(0).X + sunSpots(0).Y
            Dim smallesSunspot As Integer = 0
            Dim smallestSunspotSum As Integer = sunSpots(0).X + sunSpots(0).Y
            For i = 1 To sunSpots.Count - 1
                If sunSpots(i).X + sunSpots(i).Y > largestSunspotSum Then largestSunspot = i : largestSunspotSum = sunSpots(i).X + sunSpots(i).Y
                If sunSpots(i).X + sunSpots(i).Y < smallestSunspotSum Then smallesSunspot = i : smallestSunspotSum = sunSpots(i).X + sunSpots(i).Y
            Next
            pTopLeft = sunSpots(smallesSunspot)
            pBottomRight = sunSpots(largestSunspot)
            '# now, compute the difference between the points, the
            '# top-right point will have the smallest difference,
            '# whereas the bottom-left will have the largest difference
            Dim largestSunspotDifference As Integer = 0
            Dim largestSunspotDifferenceIndex As Integer = 0
            Dim remainingsunspots As New List(Of Integer) 'put topright and bottomleft in here
            For i = 0 To sunSpots.Count - 1
                If Not i = largestSunspot AndAlso Not i = smallesSunspot Then
                    remainingsunspots.Add(i)
                End If
            Next
            If remainingsunspots.Count = 2 Then
                If sunSpots(remainingsunspots(0)).X > sunSpots(remainingsunspots(1)).X Then
                    pTopRight = sunSpots(remainingsunspots(0))
                    pBottomLeft = sunSpots(remainingsunspots(1))
                Else
                    pTopRight = sunSpots(remainingsunspots(1))
                    pBottomLeft = sunSpots(remainingsunspots(0))
                End If

            End If
            '    For i = 0 To sunSpots.Count - 1
            '    If Not i = largestSunspot AndAlso Not i = smallesSunspot Then
            '        If sunSpots(i).X - sunSpots(i).Y > largestSunspotDifference Then
            '            pTopRight = sunSpots(i)
            '            largestSunspotDifference = sunSpots(i).X - sunSpots(i).Y
            '        Else
            '            pBottomLeft = sunSpots(i)

            '        End If
            '    End If
            'Next
            'put it in pointf for transform: top left clockwise
            calibrationRectangle(0).X = pTopLeft.X
            calibrationRectangle(0).Y = pTopLeft.Y
            calibrationRectangle(1).X = pTopRight.X
            calibrationRectangle(1).Y = pTopRight.Y
            calibrationRectangle(2).X = pBottomRight.X
            calibrationRectangle(2).Y = pBottomRight.Y
            calibrationRectangle(3).X = pBottomLeft.X
            calibrationRectangle(3).Y = pBottomLeft.Y
            'show in RichTextBox1
            RichTextBox1.Clear()
            For Each p In calibrationRectangle
                RichTextBox1.AppendText(p.X.ToString + " , " + p.Y.ToString + vbCrLf)
            Next

        End If
        bDoCalibrate = False
    End Sub

    Private Sub TrackBarSMin_Scroll(sender As Object, e As EventArgs) Handles TrackBarSMin.Scroll, TrackBarSMax.Scroll
        If TrackBarSMin.Value >= TrackBarSMax.Value Then
            TrackBarSMin.Value = TrackBarSMax.Value - 1
        End If
    End Sub
    Private Sub TrackBarVMin_Scroll(sender As Object, e As EventArgs) Handles TrackBarVMin.Scroll, TrackBarVMax.Scroll
        If TrackBarVMin.Value >= TrackBarVMax.Value Then
            TrackBarVMin.Value = TrackBarVMax.Value - 1
        End If
    End Sub

    ''' <summary>
    ''' Remove noise specks of specific size
    ''' </summary>
    ''' <param name="frame"></param>
    ''' <param name="contours"></param>
    ''' <param name="minWidth"></param>
    ''' <param name="maxWidth"></param>
    ''' <param name="minHeight"></param>
    ''' <param name="maxHeight"></param>
    Private Sub RemoveNoiseParticles(frame As Mat, contours As VectorOfVectorOfPoint, minWidth As Integer, maxWidth As Integer, minHeight As Integer, maxHeight As Integer)
        For IndexContour As Integer = 0 To contours.Size - 1
            Dim box As Rectangle
            box = CvInvoke.BoundingRectangle(contours(IndexContour))
            If box.Width > minWidth AndAlso box.Width < maxWidth AndAlso box.Height > minHeight AndAlso box.Height < maxHeight Then
                CvInvoke.DrawContours(frame, contours, IndexContour, New MCvScalar(0, 0, 0), -1) 'draw this contour over with black
            End If
        Next
    End Sub
    ''' <summary>
    ''' Remove contours that don't fall within a specific size interval
    ''' </summary>
    ''' <param name="frame"></param>
    ''' <param name="contours"></param>
    ''' <param name="minWidth"></param>
    ''' <param name="maxWidth"></param>
    ''' <param name="minHeight"></param>
    ''' <param name="maxHeight"></param>
    Private Sub KeepContoursOfSize(frame As Mat, contours As VectorOfVectorOfPoint, minWidth As Integer, maxWidth As Integer, minHeight As Integer, maxHeight As Integer)
        For IndexContour As Integer = 0 To contours.Size - 1
            Dim box As Rectangle
            box = CvInvoke.BoundingRectangle(contours(IndexContour))
            If Not (box.Width > minWidth AndAlso box.Width < maxWidth AndAlso box.Height > minHeight AndAlso box.Height < maxHeight) Then
                CvInvoke.DrawContours(frame, contours, IndexContour, New MCvScalar(0, 0, 0), -1) 'draw this contour over with black
            End If
        Next
    End Sub

    Private Sub TrackBarMinContour_Scroll(sender As Object, e As EventArgs) Handles TrackBarMinContour.Scroll
        If TrackBarMinContour.Value >= TrackBarMaxContour.Value Then
            TrackBarMinContour.Value = TrackBarMaxContour.Value - 1
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If AntWindow.showCalibrationWindow = True Then
            AntWindow.showCalibrationWindow = False
        Else
            AntWindow.showCalibrationWindow = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bDoCalibrate = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If System.IO.File.Exists("..\..\Resources\Settings.ini") Then System.IO.File.Delete("..\..\Resources\Settings.ini")
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("..\..\Resources\Settings.ini", True)
        file.WriteLine(TrackBarH.Value.ToString)
        file.WriteLine(TrackBarHueTolerance.Value.ToString)
        file.WriteLine(TrackBarSMin.Value.ToString)
        file.WriteLine(TrackBarSMax.Value.ToString)
        file.WriteLine(TrackBarVMin.Value.ToString)
        file.WriteLine(TrackBarVMax.Value.ToString)
        file.WriteLine(TrackBarBlur.Value.ToString)
        file.WriteLine(TrackBarErode.Value.ToString)
        file.WriteLine(TrackBarDilate.Value.ToString)
        file.WriteLine(TrackBarMinContour.Value.ToString)
        file.WriteLine(TrackBarMaxContour.Value.ToString)
        file.WriteLine(calibrationRectangle(0).X.ToString)
        file.WriteLine(calibrationRectangle(0).Y.ToString)
        file.WriteLine(calibrationRectangle(1).X.ToString)
        file.WriteLine(calibrationRectangle(1).Y.ToString)
        file.WriteLine(calibrationRectangle(2).X.ToString)
        file.WriteLine(calibrationRectangle(2).Y.ToString)
        file.WriteLine(calibrationRectangle(3).X.ToString)
        file.WriteLine(calibrationRectangle(3).Y.ToString)
        file.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sr As StreamReader = New StreamReader("..\..\Resources\Settings.ini")
        TrackBarH.Value = sr.ReadLine()
        TrackBarHueTolerance.Value = sr.ReadLine()
        TrackBarSMin.Value = sr.ReadLine()
        TrackBarSMax.Value = sr.ReadLine()
        TrackBarVMin.Value = sr.ReadLine()
        TrackBarVMax.Value = sr.ReadLine()
        TrackBarBlur.Value = sr.ReadLine()
        TrackBarErode.Value = sr.ReadLine()
        TrackBarDilate.Value = sr.ReadLine()
        TrackBarMinContour.Value = sr.ReadLine()

        TrackBarMaxContour.Value = sr.ReadLine()
        calibrationRectangle(0).X = sr.ReadLine()
        calibrationRectangle(0).Y = sr.ReadLine()
        calibrationRectangle(1).X = sr.ReadLine()
        calibrationRectangle(1).Y = sr.ReadLine()
        calibrationRectangle(2).X = sr.ReadLine()
        calibrationRectangle(2).Y = sr.ReadLine()
        calibrationRectangle(3).X = sr.ReadLine()
        calibrationRectangle(3).Y = sr.ReadLine()
        sr.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If System.IO.File.Exists("..\..\Resources\CalibrationSettings.ini") Then System.IO.File.Delete("..\..\Resources\CalibrationSettings.ini")
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("..\..\Resources\CalibrationSettings.ini", True)
        file.WriteLine(TrackBarH.Value.ToString)
        file.WriteLine(TrackBarHueTolerance.Value.ToString)
        file.WriteLine(TrackBarSMin.Value.ToString)
        file.WriteLine(TrackBarSMax.Value.ToString)
        file.WriteLine(TrackBarVMin.Value.ToString)
        file.WriteLine(TrackBarVMax.Value.ToString)
        file.WriteLine(TrackBarBlur.Value.ToString)
        file.WriteLine(TrackBarErode.Value.ToString)
        file.WriteLine(TrackBarDilate.Value.ToString)
        file.WriteLine(TrackBarMinContour.Value.ToString)
        file.WriteLine(TrackBarMaxContour.Value.ToString)
        file.WriteLine(calibrationRectangle(0).X.ToString)
        file.WriteLine(calibrationRectangle(0).Y.ToString)
        file.WriteLine(calibrationRectangle(1).X.ToString)
        file.WriteLine(calibrationRectangle(1).Y.ToString)
        file.WriteLine(calibrationRectangle(2).X.ToString)
        file.WriteLine(calibrationRectangle(2).Y.ToString)
        file.WriteLine(calibrationRectangle(3).X.ToString)
        file.WriteLine(calibrationRectangle(3).Y.ToString)
        file.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim sr As StreamReader = New StreamReader("..\..\Resources\CalibrationSettings.ini")
        TrackBarH.Value = sr.ReadLine()
        TrackBarHueTolerance.Value = sr.ReadLine()
        TrackBarSMin.Value = sr.ReadLine()
        TrackBarSMax.Value = sr.ReadLine()
        TrackBarVMin.Value = sr.ReadLine()
        TrackBarVMax.Value = sr.ReadLine()
        TrackBarBlur.Value = sr.ReadLine()
        TrackBarErode.Value = sr.ReadLine()
        TrackBarDilate.Value = sr.ReadLine()
        TrackBarMinContour.Value = sr.ReadLine()

        TrackBarMaxContour.Value = sr.ReadLine()
        calibrationRectangle(0).X = sr.ReadLine()
        calibrationRectangle(0).Y = sr.ReadLine()
        calibrationRectangle(1).X = sr.ReadLine()
        calibrationRectangle(1).Y = sr.ReadLine()
        calibrationRectangle(2).X = sr.ReadLine()
        calibrationRectangle(2).Y = sr.ReadLine()
        calibrationRectangle(3).X = sr.ReadLine()
        calibrationRectangle(3).Y = sr.ReadLine()
        sr.Close()
    End Sub
End Class
