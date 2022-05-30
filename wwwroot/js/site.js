function ButtonClick() {
    alert("hi");
}

function insertPerson() {
    var body = {};
    body.Nome = $('#personName').val();
    body.Cognome = $('#personLastName').val();
    $.ajax({
        method: "POST",
        url: "/api/Person",
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