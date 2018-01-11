Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Auth_Test

Namespace Controllers
    Public Class tblUtility_AccessController
        Inherits System.Web.Mvc.Controller

        Private db As New UtilityEntities1



        ' GET: tblUtility_Access
        Function Index() As ActionResult
            Return View(db.tblUtility_Access.ToList())
        End Function

        ' GET: tblUtility_Access/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tblUtility_Access As tblUtility_Access = db.tblUtility_Access.Find(id)
            If IsNothing(tblUtility_Access) Then
                Return HttpNotFound()
            End If
            Return View(tblUtility_Access)
        End Function

        ' GET: tblUtility_Access/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: tblUtility_Access/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="RestrictedPageID,GroupID")> ByVal tblUtility_Access As tblUtility_Access) As ActionResult
            If ModelState.IsValid Then
                db.tblUtility_Access.Add(tblUtility_Access)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tblUtility_Access)
        End Function

        ' GET: tblUtility_Access/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tblUtility_Access As tblUtility_Access = db.tblUtility_Access.Find(id)
            If IsNothing(tblUtility_Access) Then
                Return HttpNotFound()
            End If
            Return View(tblUtility_Access)
        End Function

        ' POST: tblUtility_Access/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="RestrictedPageID,GroupID")> ByVal tblUtility_Access As tblUtility_Access) As ActionResult
            If ModelState.IsValid Then
                db.Entry(tblUtility_Access).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(tblUtility_Access)
        End Function

        ' GET: tblUtility_Access/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim tblUtility_Access As tblUtility_Access = db.tblUtility_Access.Find(id)
            If IsNothing(tblUtility_Access) Then
                Return HttpNotFound()
            End If
            Return View(tblUtility_Access)
        End Function

        ' POST: tblUtility_Access/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim tblUtility_Access As tblUtility_Access = db.tblUtility_Access.Find(id)
            db.tblUtility_Access.Remove(tblUtility_Access)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
