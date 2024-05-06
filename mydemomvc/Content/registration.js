$(document).ready(function () { 
    GetregistrationList();
    getregistrationbyID();
    Redirectdetails();


});
var Savereg = function () {
    var id = $("#hdnid").val();
    var name = $("#txtname").val();
    var mobileno = $("#txtnumber").val();
    var city = $("#city").val();
    var address = $("#texADD").val();

    if (name == "") {
        alert("Plese Enter Your Name");
    }
    else if (mobileno == "") {
        alert("Plese Enter Your MobileNo");
    }
    else if (city == "") {
        alert("Plese Enter Your City");
    }
    else if (address == "") {
        alert("Plese Enter Your Address");

    }

    var model = { ID:id ,Name: name, MobileNo: mobileno, City: city, Address: address, };
    $.ajax({
        url: "/Home/Savereg",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Successfull");
        }
    })
};

var GetregistrationList = function () {
    debugger;
    $.ajax({
        url: "/Home/GetregistrationList",
        method: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblregistrations tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.srno +
                    "</td><td>" + elementValue.ID +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.MobileNo +
                    "</td><td>" + elementValue.City +
                    "</td><td>" + elementValue.Address +
                    "</td><td><input type='button' value='Delete' onclick='deleteregistration(" + elementValue.ID + ")'class='btn btn-danger'/> &nbsp <input type='button' value='Update' onclick='getregistrationbyID(" + elementValue.ID + ")'class='btn btn-success'/>&nbsp <input type='button' value='Redirectdetails' onclick='details(" + elementValue.ID + ")'class='btn btn-success'/></td></tr>";



                    

            });
            $("#tblregistrations tbody").append(html);
        }
    });

}

var deleteregistration = function (ID) {
    debugger;
    model = {ID:ID}
    $.ajax({
        url: "/Home/deleteregistration",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response.model);
        }
    })
}

var getregistrationbyID = function (ID) {
    debugger;
    model = { ID: ID }
    $.ajax({
        url: "/Home/getregistrationbyID",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#hdnid").val(response.model.ID);
            $("#txtname").val(response.model.Name);
            $("#txtnumber").val(response.model.MobileNo);
            $("#city").val(response.model.City);
            $("#texADD").val(response.model.Address);

          
        }
    });
}
var details = function (ID) {
    window.location.href = "/Home/DetailsIndex?ID=" + ID;

}
var Redirectdetails = function () {
    
    var ID = $("#hdnid").val();
    debugger;
    model = { ID: ID }
    $.ajax({
        url: "/Home/getregistrationbyID",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#hdnid").text(response.model.ID);
            $("#txtname").text(response.model.Name);
            $("#txtnumber").text(response.model.MobileNo);
            $("#city").text(response.model.City);
            $("#texADD").text(response.model.Address);


        }
    });
}








