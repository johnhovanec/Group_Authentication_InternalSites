@ModelType Auth_Test.tblUtility_Access
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>tblUtility_Access</h4>
    <hr />
    <dl class="dl-horizontal">
    </dl>
</div>
<p>
    @*@Html.ActionLink("Edit", "Edit", New With {.id = Model.PrimaryKey}) |*@
    @Html.ActionLink("Back to List", "Index")
</p>
