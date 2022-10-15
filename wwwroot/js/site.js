function ButtonClick() {
    alert("hi");
}
function ajaxCallPerson() {
    var body = {};
    body.ID = "a3b5d487-0000-0000-0000-14d5c7813c8a";
    body.Nome = "Dante";
    body.Cognome = "Alighieri";
    $.ajax({
        method: "POST",
        url: "/api/Person/Post",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(body),
        dataType: "json",
        success: function (data, status) {
            console.log(body);
            console.log(data);
            console.log(status);
            this.always();
        },
        error: function (error, status) {
            console.log(body);
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () { }
    });
};
function ajaxCallListaStringhe() {
    $.ajax({
        method: "GET",
        url: "/api/API/GetListaStringhe",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {
            console.log(data);
            for (var i = 0; i < data.length; i++) {
                $("#resultDiv").append("<br/><div>" + data[i] + "</div>");
            }
            this.always();
        },
        error: function (error, status) {
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () { }
    });
};
function ajaxCallDDLValue() {
    var value = $("#DDLValue").val();
    var url = "/api/API/GetDDLValue?id=" + value;
    $.ajax({
        method: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data, status) {
            console.log(data);
            $("#resultDivDDLValue").append("<br/><div>" + data.value + "</div>");
            this.always();
        },
        error: function (error, status) {
            console.log(error);
            console.log(status);
            this.always();
        },
        always: function () { }
    });
};
/*
function ajaxCall(url, data) {
    $.ajax({
        type: "POST",
        url: url,
        //contentType: "application/json; charset=utf-8",
        data: data,
        dataType: "json",
        success: function (data, status) {
            this.always();
        },
        error: function (error, status) { this.always(); },
        always: function () { }
    });
}
*/