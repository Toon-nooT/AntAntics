Public Class Ant
    Public rotation As Integer   ' 0-360
    Public x As Single  ' x position
    Public y As Single   ' y position
    Public type As String
    Public stepsToWalk As Integer 'will be substracted by 1 till reaches 0
    Public stepsToRest As Integer 'will be substracted by 1 till reaches 0
    Public ranGen As Random
    Public stepsToDie As Integer 'counter when it is outside of window
    Public bIsWalking As Boolean 'walking or resting
    Public bIsDying As Boolean 'dying
    Public stepsToExplode As Integer 'will be substracted by 1 till reaches 0
    Public stepSize As Integer 'amount of pixels to move each tick
    Public HealthPoints As Integer 'decreases when hitbox is hit, explosion animation starts when it reaches 0

    Public Enum antType
        Red
        Gray
        Brown
    End Enum

    Public Sub New(antType As antType, ByVal xpos As Integer, ByVal ypos As Integer, ByVal rot As Integer, r As Random, ByVal walksteps As Integer, ByVal reststeps As Integer, explodesteps As Integer, pixelsperstep As Integer, hp As Integer)   'parameterised constructor
        x = xpos
        y = ypos
        rotation = rot
        stepsToWalk = walksteps
        stepsToRest = reststeps
        ranGen = r
        bIsWalking = True
        bIsDying = False
        stepsToExplode = explodesteps
        stepSize = pixelsperstep
        type = antType
        HealthPoints = hp
    End Sub
End Class
