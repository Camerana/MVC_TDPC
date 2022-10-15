function insertPerson() {
    var body = {};
    body.Nome = $('#personName').val();
    body.Cognome = $('#personLastName').val();
    $.ajax({
        method: "POST",
        url: "/api/Person/InsertPerson",
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

function deletePerson() {
    var body = {};
    body.ID = $('#personID').val();
    $.ajax({
        method: "POST",
        url: "/api/Person/DeletePerson",
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

function deletePersonById(id) {
    var body = {};
    body.ID = id;
    $.ajax({
        method: "POST",
        url: "/api/Person/DeletePerson",
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
        always: function () {
            window.location = window.location;
        }
    });
};

function updatePersonById(id) {
    nameP = document.createElement("p");
    nameP.style.textAlign = "center";
    nameP.innerText = 'Nome';
    document.getElementById("modal-body").appendChild(nameP);
    nameTextArea = document.createElement("input");
    nameP.appendChild(nameTextArea);

    lastNameP = document.createElement("p");
    lastNameP.style.textAlign = "center";
    lastNameP.innerText = 'Cognome';
    document.getElementById("modal-body").appendChild(lastNameP);
    lastNameTextArea = document.createElement("input");
    lastNameP.appendChild(lastNameTextArea);

    OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.id = "modalOKButton";
    OKbutton.classList.add("btn");
    OKbutton.classList.add("btn-success");
    OKbutton.onclick = function () {
        var body = {};
        body.ID = id;
        body.Nome = nameTextArea.value;
        body.Cognome = lastNameTextArea.value;
        $.ajax({
            method: "POST",
            url: "/api/Person/UpdatePerson",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(body),
            dataType: "json",
            success: function (data, status) {
                console.log(body);
                console.log(data);
                console.log(status);
                this.always();
                window.location = window.location;
            },
            error: function (error, status) {
                console.log(body);
                console.log(error);
                console.log(status);
                this.always();
            },
            always: function () {
            }
        });
    }
    $(".modal-footer").append(OKbutton);
    CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.id = "modalCancelButton";
    CancelButton.classList.add("btn");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    document.getElementById("modal").style.display = "block";
};

function hideModal() {
    document.getElementById("modal-header").innerText = "";
    $(".modal-body").empty();
    $(".modal-footer").empty();
    document.getElementById("modal").style.display = "none";
}