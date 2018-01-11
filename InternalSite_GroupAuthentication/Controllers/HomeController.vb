Imports System
Imports System.Threading
Imports System.Security.Permissions
Imports System.Security.Principal
Imports System.Data.SqlClient

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        ' to setup Entity Framework with existing database
        Dim db = New UtilityEntities1

        ' Get the user's login credentials
        Dim domainName As AppDomain = Thread.GetDomain()
        domainName.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
        Dim userPrincipal As WindowsPrincipal = CType(Thread.CurrentPrincipal, WindowsPrincipal)
        Dim ADUser = userPrincipal.Identity.Name.ToString()
        ViewData("ADUser") = ADUser
        ' To retrieve the username and omit the domain name
        Dim userName As String() = ADUser.Split(New Char() {"\"c})
        ViewData("userName") = userName(1)  ' We just want position 1 in the array. position 0 is DAEDALUS\

        ' Get query param for which page is being requested, pass this to the stored procedure
        Dim requestedPage = Request.Params("link")
        ViewData("Query") = requestedPage

        ' Call sproc to get length of array returned. 
        ' A User Of an authorized group will Return an array Of at least 1, an UnAuthorized user = 0
        Dim groupsLength = db.spUtility_GetLDAPIsAuthorized(userName(1).ToString, requestedPage).ToArray.Length
        ViewData("groups") = groupsLength

        ' Send authorized users to the page requested or redirect unauthorized users to main page
        If groupsLength > 0 Then
            ViewData("result") = "The user is authorized"
            Dim pageRequested = db.spUtility_GetPageURL(requestedPage)
            Dim redirectPage = pageRequested(0)
            ViewData("redirect") = redirectPage
            ' Set authorization cookie
            Response.Cookies("Auth")(requestedPage) = True
            ' Set cookie to expire in 1 day
            Response.Cookies("Auth").Expires = DateTime.Now.AddDays(1)
            ' Redirect to requested page
            Response.Redirect(redirectPage)

            ' Unauthorized users will get directed to this site's Index page    
        Else
            ' Set authorization cookie to false
            Response.Cookies("Auth")(requestedPage) = False
        End If

        Return View()
    End Function

    ' Home/UnAuthorized handles attempts to access a page directly by its url. This is called from a redirect by the protected page.
    Function UnAuthorized() As ActionResult
        Return View()
    End Function


End Class
