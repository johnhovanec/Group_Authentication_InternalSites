@Code
    ViewData("Title") = "Home Page"
End Code

<h3>Unauthorized Access</h3>
<h4>Your credentials do not allow you to access this page.</h4>
<p>Please contact the IT Department if you need help with site access.</p>
<br />
<p>Click <a href="http://10.1.2.167">here</a> to return to the Main page </p>  <!-- Note: Replace with live site IP ! -->

@* Below is only for testing, remove when done *@
<br />
<hr />
<div class="row">
    <div class="col-md-4 fineprint">
        <p>Returned credentials:</p>
        <p>AuthGroupsMatch = @ViewData("groups") </p>
        
        <p>ADUser = @ViewData("ADUser")</p>
        <p>userName = @ViewData("userName")</p>

       <hr />
        <p>query value = @ViewData("Query")</p>
        
       

</div>
