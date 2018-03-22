
//Get product availability from DetailView.aspx to ListView.aspx

$.ajax({
    type: "GET",
    url: "DetailView.aspx/GetAvailability",
    contentType: "application/json",
    dataType: "json",
    success: function (obj) {
        var json = JSON.parse(obj.d);
        $("p.availability").each(function (index) {
            $(this).html("Availability: " + json[index]);
        });
    }
});
