Public Class Index
    Inherits UI.CommonPage

#Region " Declare "

#Region " Cookie "

    <Moca.Web.Attr.Cookie(Moca.Web.Attr.CookieType.Request)>
    Protected cookieReq As ICookie

    <Moca.Web.Attr.Cookie(Moca.Web.Attr.CookieType.Response)>
    Protected cookieRes As ICookie

#End Region

#Region " ViewState Interface "

    <Moca.Web.Attr.ViewState()>
    Protected Interface IViewState

        <Moca.Web.Attr.ViewStateName("i")>
        Property ID As String

    End Interface

#End Region

    Protected mySession As ISession
    Protected myViewState As IViewState
    Protected myQueryStrings As IQueryStrings

    Protected dao As Db.IDaoDemo

#End Region

#Region " Handles "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not String.IsNullOrEmpty(myQueryStrings.Count) Then
            mySession.Counter = myQueryStrings.Count
        End If

        If cookieReq.Day IsNot Nothing Then
            lblCookieOld.Text = cookieReq.Day.Value
        End If
        cookieRes.Day.Value = Now.ToString("yyyy/MM/dd hh:mm:ss")
        lblCookie.Text = cookieRes.Day.Value

        lblVSOld.Text = myViewState.ID
        myViewState.ID = txtSearchID.Text
        lblVS.Text = myViewState.ID

        If mySession.Counter Is Nothing Then
            mySession.Counter = 0
        End If
        mySession.Counter += 1
        lblCounter.Text = mySession.Counter

        txtSearchID.Focus()
        _setGrid()
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim value As New DemoEntity

        If Not Me.UpdateEntity(Me, value, AddressOf _validInsert) Then
            Return
        End If

        dao.Ins(value)

        _setGrid()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        _setGrid()
    End Sub

#End Region
#Region " Method "

    Private Sub _validInsert(sender As Object, e As Moca.UpdateEntityValidateArgs)
        Dim webCtrl() As WebControl = New WebControl() {sender}

        ' メッセージ設定
        setErrorMessage(e.Caption, Me.valid, webCtrl, e.Value, e.ValidateResultType, e.Min, e.Max)
    End Sub

    Private Sub _setGrid()
        grdMain.DataSource = dao.Get(txtSearchID.Text)
        grdMain.DataBind()
    End Sub

#End Region

End Class
