Imports Moca.Web.UI
Imports MocaDemo.UI

Public Class Base
    Inherits System.Web.UI.MasterPage
    Implements UI.IAlerts

#Region " Declare "

    ''' <summary>bootstrap的なアラート</summary>
    Private _bootstrapAlerts As BootstrapAlerts

#End Region

#Region " Property "

    ''' <summary>
    ''' アラート
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Alerts As BootstrapAlerts Implements IAlerts.Alerts
        Get
            Return _bootstrapAlerts
        End Get
    End Property

#End Region

#Region " Handles "

    Private Sub Base_Init(sender As Object, e As EventArgs) Handles Me.Init
        _bootstrapAlerts = New BootstrapAlerts(Me.MessageArea)
    End Sub

    ''' <summary>
    ''' ロード処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

#End Region

End Class