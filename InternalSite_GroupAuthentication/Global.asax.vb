Imports System.Web.Http
Imports System.Web.Optimization

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

    End Sub

    ' Redirect to https unless it is localhost
    Protected Sub Application_BeginRequest(sender As [Object], e As EventArgs)
        If HttpContext.Current.Request.IsSecureConnection.Equals(False) AndAlso HttpContext.Current.Request.IsLocal.Equals(False) Then
            Response.Redirect("https://" + Request.ServerVariables("HTTP_HOST") + HttpContext.Current.Request.RawUrl)
        End If
    End Sub

End Class
